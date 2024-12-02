package dishdive.business.service;

import dishdive.business.ChefServiceInterface;
import dishdive.business.exception.*;
import dishdive.configuration.security.token.AccessToken;
import dishdive.configuration.security.token.AccessTokenEncoder;
import dishdive.configuration.security.token.impl.AccessTokenImpl;
import dishdive.dto.chef.request.*;
import dishdive.dto.chef.response.ChefListResponse;
import dishdive.dto.chef.response.LoginResponse;
import dishdive.dto.chef.response.SingleChefResponse;
import dishdive.dto.recipe.response.RecipeListResponse;
import dishdive.dto.shared.response.BooleanResponse;
import dishdive.dto.shared.response.UUIDResponse;
import dishdive.persistence.entity.ChefEntity;
import dishdive.persistence.entity.RecipeEntity;
import dishdive.persistence.entity.RoleEnum;
import dishdive.persistence.repository.ChefRepository;
import dishdive.persistence.repository.RatingRepository;
import dishdive.persistence.repository.RecipeRepository;
import jakarta.transaction.Transactional;
import lombok.AllArgsConstructor;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.UUID;
import java.util.stream.StreamSupport;

@Service
@AllArgsConstructor
@Transactional
public class ChefService implements ChefServiceInterface {
    private final ChefRepository chefRepository;
    private final PasswordEncoder passwordEncoder;
    private final AccessTokenEncoder accessTokenEncoder;
    private final RecipeRepository recipeRepository;
    private final AccessToken requestAccessToken;
    private final RatingRepository ratingRepository;

    @Override
    public UUIDResponse createChef(ChefDataRequest requestDTO) {
        if(chefRepository.existsByUsernameOrEmail(requestDTO.getUsername(), requestDTO.getEmail())){
            throw new AlreadyExistsException();
        }
        String encodedPassword = passwordEncoder.encode(requestDTO.getPassword());

        ChefEntity newChef = ChefEntity.builder()
                .id(UUID.randomUUID())
                .username(requestDTO.getUsername())
                .email(requestDTO.getEmail())
                .password(encodedPassword)
                .userRole(RoleEnum.CHEF)
                .build();

        chefRepository.save(newChef);

        return new UUIDResponse(newChef.getId());
    }

    @Override
    public UUIDResponse createAdmin(ChefDataRequest requestDTO) {
        if(chefRepository.existsByUsernameOrEmail(requestDTO.getUsername(), requestDTO.getEmail())){
            throw new AlreadyExistsException();
        }
        String encodedPassword = passwordEncoder.encode(requestDTO.getPassword());

        ChefEntity newChef = ChefEntity.builder()
                .id(UUID.randomUUID())
                .username(requestDTO.getUsername())
                .email(requestDTO.getEmail())
                .password(encodedPassword)
                .userRole(RoleEnum.ADMIN)
                .build();

        chefRepository.save(newChef);

        return new UUIDResponse(newChef.getId());
    }

    public LoginResponse loginChef(LoginRequest requestDTO){
        Optional<ChefEntity> optionalChef = chefRepository.findByUsernameOrEmail(requestDTO.getUsername(), requestDTO.getUsername());
        if (optionalChef.isEmpty()) {
            throw new NotFoundException();
        }

        ChefEntity foundChef = optionalChef.get();
        if(!passwordEncoder.matches(requestDTO.getPassword(), foundChef.getPassword())){
            throw new InvalidCredentialsException();
        }

        String accessToken = generateAccessToken(foundChef);
        return new LoginResponse(accessToken);
    }

    @Override
    public ChefListResponse getAllChefs() {
        List<ChefEntity> chefEntitiesList = chefRepository.findAll();

        return new ChefListResponse(chefEntitiesList);
    }

    @Override
    public SingleChefResponse getChefById(ChefIdRequest requestDTO) {
        Optional<ChefEntity> optionalChef = chefRepository.findById(requestDTO.getId());

        if (optionalChef.isEmpty()) {
            throw new NotFoundException();
        }

        return new SingleChefResponse(optionalChef.get());
    }

    @Override
    public SingleChefResponse getChefByUsername(ChefUsernameRequest requestDTO){
        Optional<ChefEntity> optionalChef = chefRepository.findByUsername(requestDTO.getUsername());
        if (optionalChef.isEmpty()) {
            throw new NotFoundException();
        }
        ChefEntity foundChef = optionalChef.get();
        return new SingleChefResponse(foundChef);
    }

    @Override
    public RecipeListResponse getChefRecipes(ChefIdRequest requestDTO) {
        Optional<ChefEntity> optionalChef = chefRepository.findById(requestDTO.getId());
        if (optionalChef.isEmpty()) {
            throw new NotFoundException();
        }
        ChefEntity foundChef = optionalChef.get();
        List<RecipeEntity> recipeEntityList = recipeRepository.findAllByPoster(foundChef);

        for (RecipeEntity recipe: recipeEntityList) {
            recipe.setRating(ratingRepository.getRatingSummaryByRecipeId(recipe.getId()));
        }

        return new RecipeListResponse(recipeEntityList);
    }

    @Override
    public UUIDResponse updateChef(ChefUsernameAndEmailChangeRequest requestDTO) {

        Optional<ChefEntity> optionalChef = chefRepository.findById(requestDTO.getId());
        if (optionalChef.isEmpty()) {
            throw new NotFoundException();
        }
        ChefEntity foundChef = optionalChef.get();

        if(foundChef.getUsername().equals(requestDTO.getUsername()) || foundChef.getEmail().equals(requestDTO.getEmail())){
            throw new NoChangeException();
        }

        foundChef.setUsername(requestDTO.getUsername());
        foundChef.setEmail(requestDTO.getEmail());

        ChefEntity savedChef = chefRepository.save(foundChef);

        return new UUIDResponse(savedChef.getId());
    }

    @Override
    public BooleanResponse updateChefPassword(ChangePasswordChangeRequest requestDTO) {

        Optional<ChefEntity> optionalChef = chefRepository.findById(requestDTO.getId());
        if (optionalChef.isEmpty()) {
            throw new NotFoundException();
        }
        ChefEntity foundChef = optionalChef.get();

        if (!passwordEncoder.matches(requestDTO.getOldPassword(), foundChef.getPassword())) {
            throw new InvalidCredentialsException();
        }

        String encodedPassword = passwordEncoder.encode(requestDTO.getNewPassword());
        foundChef.setPassword(encodedPassword);

        chefRepository.save(foundChef);
        return new BooleanResponse(true);
    }

    @Override
    public BooleanResponse deleteChef(ChefIdRequest requestDTO) {
        try{
            if (requestDTO.getId() == null || !chefRepository.existsById(requestDTO.getId())) {
                throw new InvalidRequestException();
            }

            chefRepository.deleteById(requestDTO.getId());

            return new BooleanResponse(true);
        }catch (InvalidRequestException exception){
            throw exception;
        }catch (Exception exception){
            throw new UnknownErrorException();
        }
    }

    private String generateAccessToken(ChefEntity chef){
        return accessTokenEncoder.encode(
                new AccessTokenImpl(chef.getUsername(), chef.getId(), chef.getUserRole().toString()));
    }
}
