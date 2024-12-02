package dishdive.business.service;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import dishdive.business.RecipeServiceInterface;
import dishdive.business.exception.InvalidRequestException;
import dishdive.business.exception.NotFoundException;
import dishdive.dto.recipe.request.IngredientRequest;
import dishdive.dto.recipe.request.RecipeCreationRequest;
import dishdive.dto.recipe.response.AllRecipeResponse;
import dishdive.dto.recipe.response.FilterCountsResponse;
import dishdive.dto.recipe.response.SingleRecipeResponse;
import dishdive.persistence.entity.ChefEntity;
import dishdive.persistence.entity.RatingEntity;
import dishdive.persistence.entity.RecipeEntity;
import dishdive.persistence.entity.TagEnum;
import dishdive.persistence.repository.ChefRepository;
import dishdive.persistence.repository.RatingRepository;
import dishdive.persistence.repository.RecipeRepository;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.stereotype.Service;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Service
public class RecipeService implements RecipeServiceInterface {
    private final RecipeRepository recipeRepository;
    private final ChefRepository chefRepository;

    private final RatingRepository ratingRepository;

    static final ObjectMapper objectMapper = new ObjectMapper();

    public RecipeService(RecipeRepository recipeRepository, ChefRepository chefRepository, RatingRepository ratingRepository) {
        this.recipeRepository = recipeRepository;
        this.chefRepository = chefRepository;
        this.ratingRepository = ratingRepository;
    }

    @Override
    public AllRecipeResponse getAllRecipes(Pageable pageable, String title, LocalDateTime creationTime, Integer servings, Integer cookTime, TagEnum recipeTag, Integer rating) throws JsonProcessingException {
        Specification<RecipeEntity> spec = createSpec(title, creationTime, servings, cookTime, recipeTag, rating);

        List<RecipeEntity> allRecipes = recipeRepository.findAll(spec);
        List<RecipeEntity> page = createPage(allRecipes, pageable);


        AllRecipeResponse response = new AllRecipeResponse();

        List<SingleRecipeResponse> recipesResponse = new ArrayList<>();
        for (RecipeEntity recipe: page) {
            BigDecimal averageRating = ratingRepository.getRatingSummaryByRecipeId(recipe.getId());
            SingleRecipeResponse recipeResponse = SingleRecipeResponse.builder()
                    .id(recipe.getId())
                    .poster(recipe.getPoster())
                    .title(recipe.getTitle())
                    .description(recipe.getDescription())
                    .creationTime(recipe.getCreationTime().toString())
                    .servings(recipe.getServings())
                    .prepTime(recipe.getPrepTime())
                    .cookTime(recipe.getCookTime())
                    .recipeTag(recipe.getRecipeTag())
                    .ingredients(convertJsonToDTO(recipe.getIngredients()))
                    .rating(averageRating)
                    .build();

            recipesResponse.add(recipeResponse);
        }
        response.setRecipes(recipesResponse);
        response.setFilterCounts(createFilterHashMaps(allRecipes));
        response.setPage(pageable.getPageNumber());
        response.setTotalItems(allRecipes.size());
        response.setTotalPages((int)Math.ceil((double)allRecipes.size() / pageable.getPageSize()));

        return response;
    }
    private List<RecipeEntity> createPage(List<RecipeEntity> list, Pageable pageable)  {
        int pageSize = pageable.getPageSize();
        int pageNumber = pageable.getPageNumber();

        if (pageSize <= 0 || pageNumber <= 0) {
            throw new InvalidRequestException();
        }

        int start = (pageSize * pageNumber) - pageSize;
        int end = Math.min(pageSize * pageNumber, list.size());
        return list.subList(start, end);
    }

    private Specification<RecipeEntity> createSpec(String title, LocalDateTime creationTime, Integer servings, Integer cookTime, TagEnum recipeTag, Integer rating){
        Specification<RecipeEntity> spec = Specification.where(null);

        if(title != null && !title.isEmpty()){
            spec = spec.and((root, query, cb) ->
                    cb.like(
                            cb.lower(root.get("title")),
                            "%" + title.toLowerCase() + "%"
                    )
            );
        }

        if(creationTime != null){
            spec = spec.and((root, query, cb) ->
                    cb.equal(
                            root.get("creationTime"),
                            creationTime
                    )
            );
        }

        if(servings != null){
            spec = spec.and((root, query, cb) ->
                    cb.equal(
                            root.get("servings"),
                            servings
                    )
            );
        }

        if(cookTime != null){
            spec = spec.and((root, query, cb) ->
                    cb.lessThanOrEqualTo(
                            root.get("cookTime"),
                            cookTime
                    )
            );
        }

        if(recipeTag != null){
            spec = spec.and((root, query, cb) ->
                    cb.equal(
                            root.get("recipeTag"),
                            recipeTag
                    )
            );
        }

        if(rating != null){
            spec = spec.and((root, query, cb) ->
                    cb.greaterThanOrEqualTo(
                            root.get("rating"),
                            rating
                    )
            );
        }

        return spec;
    }

    private FilterCountsResponse createFilterHashMaps(List<RecipeEntity> recipes){
        FilterCountsResponse filterCountsResponse = new FilterCountsResponse();

        for (RecipeEntity recipe : recipes) {
            filterCountsResponse.getCreationTimeCounts().merge(recipe.getCreationTime(), 1, Integer::sum);

            filterCountsResponse.getRecipeTagCounts().merge(recipe.getRecipeTag(), 1, Integer::sum);
        }

        return filterCountsResponse;
    }

    @Override
    public SingleRecipeResponse getRecipeById(UUID id) throws JsonProcessingException {
        Optional<RecipeEntity> optionalRecipe = recipeRepository.findById(id);

        if(optionalRecipe.isEmpty()){
            throw new NotFoundException();
        }

        BigDecimal averageRating = ratingRepository.getRatingSummaryByRecipeId(id);
        return SingleRecipeResponse.builder()
                .id(optionalRecipe.get().getId())
                .poster(optionalRecipe.get().getPoster())
                .title(optionalRecipe.get().getTitle())
                .description(optionalRecipe.get().getDescription())
                .creationTime(optionalRecipe.get().getCreationTime() != null ? optionalRecipe.get().getCreationTime().toString() : null)
                .servings(optionalRecipe.get().getServings())
                .prepTime(optionalRecipe.get().getPrepTime())
                .cookTime(optionalRecipe.get().getCookTime())
                .recipeTag(optionalRecipe.get().getRecipeTag())
                .ingredients(convertJsonToDTO(optionalRecipe.get().getIngredients()))
                .rating(averageRating)
                .build();
    }

    @Override
    public SingleRecipeResponse createRecipe(RecipeCreationRequest requestDTO) throws JsonProcessingException {
        Optional<ChefEntity> poster = chefRepository.findById(requestDTO.getUserId());
        if (poster.isEmpty()) {
            throw new InvalidRequestException();
        }

        RecipeEntity newRecipe = RecipeEntity.builder()
                .id(UUID.randomUUID())
                .poster(poster.get())
                .title(requestDTO.getTitle())
                .description(requestDTO.getDescription())
                .creationTime(requestDTO.getCreationTime())
                .servings(requestDTO.getServings())
                .prepTime(requestDTO.getPrepTime())
                .cookTime(requestDTO.getCookTime())
                .ingredients(convertDTOToJson(requestDTO.getIngredients()))
                .recipeTag(requestDTO.getRecipeTag())
                .build();

        recipeRepository.save(newRecipe);

        return SingleRecipeResponse.builder()
                .id(newRecipe.getId())
                .poster(newRecipe.getPoster())
                .title(newRecipe.getTitle())
                .description(newRecipe.getDescription())
                .creationTime(newRecipe.getCreationTime().toString())
                .servings(newRecipe.getServings())
                .prepTime(newRecipe.getPrepTime())
                .cookTime(newRecipe.getCookTime())
                .recipeTag(newRecipe.getRecipeTag())
                .ingredients(convertJsonToDTO(newRecipe.getIngredients()))
                .build();
    }

    @Override
    public SingleRecipeResponse editRecipe(UUID recipeId, RecipeCreationRequest requestDTO) throws JsonProcessingException {
        Optional<ChefEntity> poster = chefRepository.findById(requestDTO.getUserId());
        Optional<RecipeEntity> recipe = recipeRepository.findById(recipeId);
        if (poster.isEmpty() || recipe.isEmpty()) {
            throw new InvalidRequestException();
        }

        RecipeEntity newRecipe = RecipeEntity.builder()
                .id(recipe.get().getId())
                .poster(poster.get())
                .title(requestDTO.getTitle())
                .description(requestDTO.getDescription())
                .creationTime(recipe.get().getCreationTime())
                .servings(requestDTO.getServings())
                .prepTime(requestDTO.getPrepTime())
                .cookTime(requestDTO.getCookTime())
                .ingredients(convertDTOToJson(requestDTO.getIngredients()))
                .recipeTag(requestDTO.getRecipeTag())
                .build();

        recipeRepository.save(newRecipe);

        return SingleRecipeResponse.builder()
                .id(newRecipe.getId())
                .poster(newRecipe.getPoster())
                .title(newRecipe.getTitle())
                .description(newRecipe.getDescription())
                .creationTime(newRecipe.getCreationTime().toString())
                .servings(newRecipe.getServings())
                .prepTime(newRecipe.getPrepTime())
                .cookTime(newRecipe.getCookTime())
                .recipeTag(newRecipe.getRecipeTag())
                .ingredients(convertJsonToDTO(newRecipe.getIngredients()))
                .build();
    }

    @Override
    public Boolean deleteRecipe(UUID recipeId) {
        Optional<RecipeEntity> recipe = recipeRepository.findById(recipeId);
        List<RatingEntity> ratings = ratingRepository.findAllByRecipeId(recipeId);
        if (recipe.isEmpty()) {
            throw new NotFoundException();
        }
        if(!ratings.isEmpty()){
            ratingRepository.deleteAll(ratings);
        }
        recipeRepository.delete(recipe.get());

        return true;
    }

    public static String convertDTOToJson(List<IngredientRequest> ingredients) throws JsonProcessingException {

        return objectMapper.writeValueAsString(ingredients);
    }

    private static List<IngredientRequest> convertJsonToDTO(String json) throws JsonProcessingException {
        return objectMapper.readValue(json, new TypeReference<List<IngredientRequest>>() {});
    }

}
