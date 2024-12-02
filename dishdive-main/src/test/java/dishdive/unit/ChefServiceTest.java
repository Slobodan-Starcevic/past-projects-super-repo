package dishdive.unit;

import dishdive.business.exception.*;
import dishdive.business.service.ChefService;
import dishdive.configuration.security.token.AccessTokenEncoder;
import dishdive.configuration.security.token.impl.AccessTokenImpl;
import dishdive.dto.chef.request.*;
import dishdive.dto.chef.response.ChefListResponse;
import dishdive.dto.chef.response.LoginResponse;
import dishdive.dto.chef.response.SingleChefResponse;
import dishdive.dto.recipe.response.RecipeListResponse;
import dishdive.dto.shared.response.BooleanResponse;
import dishdive.dto.shared.response.UUIDResponse;
import dishdive.persistence.entity.*;
import dishdive.persistence.repository.ChefRepository;
import dishdive.persistence.repository.RecipeRepository;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.security.crypto.password.PasswordEncoder;

import java.time.LocalDateTime;
import java.util.*;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
class ChefServiceTest {
    @Mock
    private ChefRepository chefRepository;
    @Mock
    private PasswordEncoder passwordEncoder;
    @Mock
    private AccessTokenEncoder accessTokenEncoder;
    @Mock
    private RecipeRepository recipeRepository;
    @InjectMocks
    private ChefService chefService;

    @Test
    void testCreateChef_Success() {
        // Arrange
        ChefDataRequest requestDTO = new ChefDataRequest("testUsername", "test@email.com", "testPassword");
        when(chefRepository.existsByUsernameOrEmail(anyString(), anyString())).thenReturn(false);
        when(passwordEncoder.encode(anyString())).thenReturn("encodedPassword");

        // Act
        UUIDResponse response = chefService.createChef(requestDTO);

        // Assert
        assertNotNull(response);
        assertNotNull(response.getId());
        verify(chefRepository, times(1)).save(any());
    }

    @Test
    void testCreateChef_AlreadyExistsException() {
        // Arrange
        ChefDataRequest requestDTO = new ChefDataRequest("existingUsername", "existing@email.com", "testPassword");
        when(chefRepository.existsByUsernameOrEmail(anyString(), anyString())).thenReturn(true);

        // Act and Assert
        assertThrows(AlreadyExistsException.class, () -> chefService.createChef(requestDTO));
        verify(chefRepository, never()).save(any());
    }

    @Test
    void testCreateAdmin_SuccessfulCreation() {
        // Arrange
        ChefDataRequest requestDTO = new ChefDataRequest("adminUser", "admin@example.com", "adminPassword");
        Mockito.when(chefRepository.existsByUsernameOrEmail(anyString(), anyString())).thenReturn(false);
        Mockito.when(passwordEncoder.encode(anyString())).thenReturn("encodedPassword");
        Mockito.when(chefRepository.save(any(ChefEntity.class))).thenReturn(createSampleAdminEntity());

        // Act
        UUIDResponse response = chefService.createAdmin(requestDTO);

        // Assert
        assertNotNull(response);
        assertNotNull(response.getId());
    }

    @Test
    void testCreateAdmin_AlreadyExistsException() {
        // Arrange
        ChefDataRequest requestDTO = new ChefDataRequest("existingUser", "existing@example.com", "existingPassword");
        Mockito.when(chefRepository.existsByUsernameOrEmail(anyString(), anyString())).thenReturn(true);

        // Act and Assert
        assertThrows(AlreadyExistsException.class, () -> chefService.createAdmin(requestDTO));
        Mockito.verify(chefRepository, Mockito.never()).save(any(ChefEntity.class));
    }

    private ChefEntity createSampleAdminEntity() {
        return ChefEntity.builder()
                .id(UUID.randomUUID())
                .username("adminUser")
                .email("admin@example.com")
                .password("encodedPassword")
                .userRole(RoleEnum.ADMIN)
                .build();
    }

    @Test
    void testLoginChef_Success() {
        //Arrange
        LoginRequest requestDTO = new LoginRequest("existingUsername", "password123");
        ChefEntity existingChef = ChefEntity.builder()
                .id(UUID.randomUUID())
                .username("existingUsername")
                .email("existing@email.com")
                .password("encodedPassword")
                .userRole(RoleEnum.CHEF)
                .build();
        Mockito.when(chefRepository.findByUsernameOrEmail(anyString(), anyString())).thenReturn(Optional.of(existingChef));
        Mockito.when(passwordEncoder.matches(anyString(), anyString())).thenReturn(true);
        Mockito.when(accessTokenEncoder.encode(new AccessTokenImpl(existingChef.getUsername(), existingChef.getId(), existingChef.getUserRole().toString()))).thenReturn("fakeToken");

        //Act
        LoginResponse response = chefService.loginChef(requestDTO);

        //Assert
        assertNotNull(response);
        assertNotNull(response.getAccessToken());
        Assertions.assertEquals("fakeToken", response.getAccessToken());
    }

    @Test
    void testLoginChef_NotFoundException() {
        //Arrange
        LoginRequest requestDTO = new LoginRequest("nonexistentUsername", "password123");
        Mockito.when(chefRepository.findByUsernameOrEmail(anyString(), anyString())).thenReturn(Optional.empty());

        //Act and Assert
        assertThrows(NotFoundException.class, () -> chefService.loginChef(requestDTO));
        Mockito.verify(passwordEncoder, Mockito.never()).matches(anyString(), anyString());
    }

    @Test
    void testLoginChef_InvalidCredentialsException() {
        //Arrange
        LoginRequest requestDTO = new LoginRequest("existingUsername", "incorrectPassword");
        ChefEntity existingChef = ChefEntity.builder()
                .id(UUID.randomUUID())
                .username("existingUsername")
                .email("existing@email.com")
                .password("encodedPassword")
                .userRole(RoleEnum.CHEF)
                .build();
        Mockito.when(chefRepository.findByUsernameOrEmail(anyString(), anyString())).thenReturn(Optional.of(existingChef));
        Mockito.when(passwordEncoder.matches(anyString(), anyString())).thenReturn(false);

        //Act and Assert
        assertThrows(InvalidCredentialsException.class, () -> chefService.loginChef(requestDTO));
        Mockito.verify(passwordEncoder, Mockito.times(1)).matches(anyString(), anyString());
    }

    @Test
    void testGetAllChefs_EmptyList() {
        //Arrange
        when(chefRepository.findAll()).thenReturn(Collections.emptyList());

        //Act
        ChefListResponse response = chefService.getAllChefs();

        //Assert
        assertNotNull(response);
        assertTrue(response.getChefList().stream().noneMatch(chef -> true),
                "List should be empty");
    }


    @Test
    void testGetAllChefs_NonEmptyList() {
        //Arrange
        List<ChefEntity> chefEntities = List.of(
                ChefEntity.builder()
                        .id(UUID.randomUUID())
                        .username("chef1")
                        .email("chef1@example.com")
                        .password("password1")
                        .userRole(RoleEnum.CHEF)
                        .build(),
                ChefEntity.builder()
                        .id(UUID.randomUUID())
                        .username("chef2")
                        .email("chef2@example.com")
                        .password("password2")
                        .userRole(RoleEnum.CHEF)
                        .build(),
                ChefEntity.builder()
                        .id(UUID.randomUUID())
                        .username("chef3")
                        .email("chef3@example.com")
                        .password("password3")
                        .userRole(RoleEnum.CHEF)
                        .build()
        );
        when(chefRepository.findAll()).thenReturn(chefEntities);

        //Act
        ChefListResponse response = chefService.getAllChefs();

        //Assert
        assertNotNull(response);
        Assertions.assertFalse(response.getChefList().isEmpty());
        Assertions.assertEquals(chefEntities.size(), response.getChefList().size());
    }

    @Test
    void testGetChefById_ChefFound() {
        //Arrange
        UUID chefId = UUID.randomUUID();
        ChefIdRequest requestDTO = new ChefIdRequest(chefId);
        ChefEntity foundChef = ChefEntity.builder()
                .id(chefId)
                .username("testChef")
                .email("test@example.com")
                .password("password123")
                .userRole(RoleEnum.CHEF)
                .build();
        when(chefRepository.findById(chefId)).thenReturn(Optional.of(foundChef));

        //Act
        SingleChefResponse response = chefService.getChefById(requestDTO);

        //Assert
        assertNotNull(response);
        Assertions.assertEquals(foundChef.getId(), response.getChef().getId());
        Assertions.assertEquals(foundChef.getUsername(), response.getChef().getUsername());
        Assertions.assertEquals(foundChef.getEmail(), response.getChef().getEmail());
        Assertions.assertEquals(foundChef.getUserRole(), response.getChef().getUserRole());
    }

    @Test
    void testGetChefById_ChefNotFound() {
        //Arrange
        UUID chefId = UUID.randomUUID();
        ChefIdRequest requestDTO = new ChefIdRequest(chefId);
        when(chefRepository.findById(chefId)).thenReturn(Optional.empty());

        //Act and Assert
        assertThrows(NotFoundException.class, () -> chefService.getChefById(requestDTO));
    }

    @Test
    void testGetChefByUsername_Success(){
        //Arrange
        String chefUsername = "Chef";
        ChefEntity existingChef = new ChefEntity(UUID.randomUUID(), chefUsername, "chef@mail.com", "password", RoleEnum.CHEF);
        ChefUsernameRequest request = new ChefUsernameRequest(chefUsername);
        when(chefRepository.findByUsername(chefUsername)).thenReturn(Optional.of(existingChef));

        //Act
        SingleChefResponse response = chefService.getChefByUsername(request);

        //Assert
        assertNotNull(response);
        Assertions.assertEquals(response.getChef().getId(), existingChef.getId());
    }

    @Test
    void testGetChefByUsername_NoChefFound(){
        //Arrange
        String chefUsername = "Chef";
        ChefUsernameRequest request = new ChefUsernameRequest(chefUsername);
        when(chefRepository.findByUsername(chefUsername)).thenReturn(Optional.empty());

        //Act and Assert
        assertThrows(NotFoundException.class, () -> chefService.getChefByUsername(request));
    }

//    @Test
//    void testGetChefRecipes_ChefFoundWithRecipes() {
//        // Arrange
//        UUID chefId = UUID.randomUUID();
//        ChefIdRequest requestDTO = new ChefIdRequest(chefId);
//        ChefEntity foundChef = createSampleChefEntity(chefId);
//        List<String> ingredients = new ArrayList<>();
//        ingredients.add("[{\"name\":\"wow\",\"amount\":1}]");
//        List<RecipeEntity> recipes = createSampleRecipeEntities(foundChef, ingredients);
//
//        when(chefRepository.findById(chefId)).thenReturn(Optional.of(foundChef));
//        when(recipeRepository.findAllByPoster(foundChef)).thenReturn(recipes);
//
//        // Act
//        RecipeListResponse response = chefService.getChefRecipes(requestDTO);
//
//        // Assert
//        assertNotNull(response);
//        assertEquals(recipes.size(), response.getRecipeList().size());
//        assertEquals(recipes.get(0).getId(), response.getRecipeList().get(0).getId());
//    }
//
//    @Test
//    void testGetChefRecipes_ChefFoundNoRecipes() {
//        // Arrange
//        UUID chefId = UUID.randomUUID();
//        ChefIdRequest requestDTO = new ChefIdRequest(chefId);
//        ChefEntity foundChef = createSampleChefEntity(chefId);
//
//        when(chefRepository.findById(chefId)).thenReturn(Optional.of(foundChef));
//        when(recipeRepository.findAllByPoster(foundChef)).thenReturn(Collections.emptyList());
//
//        // Act
//        RecipeListResponse response = chefService.getChefRecipes(requestDTO);
//
//        // Assert
//        assertNotNull(response);
//        assertTrue(response.getRecipeList().isEmpty());
//    }
//
//    @Test
//    void testGetChefRecipes_ChefNotFound() {
//        // Arrange
//        UUID chefId = UUID.randomUUID();
//        ChefIdRequest requestDTO = new ChefIdRequest(chefId);
//        when(chefRepository.findById(chefId)).thenReturn(Optional.empty());
//
//        // Act and Assert
//        assertThrows(NotFoundException.class, () -> chefService.getChefRecipes(requestDTO));
//    }

    private ChefEntity createSampleChefEntity(UUID chefId) {
        return ChefEntity.builder()
                .id(chefId)
                .username("testChef")
                .email("test@example.com")
                .password("password123")
                .userRole(RoleEnum.CHEF)
                .build();
    }

    private List<RecipeEntity> createSampleRecipeEntities(ChefEntity chefEntity, List<String> ingredients) {
        return List.of(
                RecipeEntity.builder()
                        .id(UUID.randomUUID())
                        .poster(chefEntity)
                        .title("Recipe1")
                        .description("Description1")
                        .creationTime(LocalDateTime.now())
                        .servings(4)
                        .prepTime(20)
                        .cookTime(30)
                        .recipeTag(TagEnum.BREAKFAST)
                        .ingredients("[{\"name\":\"wow\",\"amount\":1}]")
                        .build(),
                RecipeEntity.builder()
                        .id(UUID.randomUUID())
                        .poster(chefEntity)
                        .title("Recipe2")
                        .description("Description2")
                        .creationTime(LocalDateTime.now())
                        .servings(2)
                        .prepTime(15)
                        .cookTime(25)
                        .recipeTag(TagEnum.DESSERT)
                        .ingredients("[{\"name\":\"wow\",\"amount\":1}]")
                        .build()
        );
    }

    @Test
    void testUpdateChef_SuccessfulUpdate() {
        //Arrange
        UUID chefId = UUID.randomUUID();
        ChefUsernameAndEmailChangeRequest requestDTO = new ChefUsernameAndEmailChangeRequest(chefId, "newUsername", "newEmail");
        ChefEntity foundChef = ChefEntity.builder()
                .id(chefId)
                .username("oldUsername")
                .email("oldEmail@example.com")
                .password("oldPassword")
                .userRole(RoleEnum.CHEF)
                .build();
        when(chefRepository.findById(chefId)).thenReturn(Optional.of(foundChef));
        when(chefRepository.save(foundChef)).thenReturn(foundChef);

        //Act
        UUIDResponse response = chefService.updateChef(requestDTO);

        //Assert
        assertNotNull(response);
        Assertions.assertEquals(chefId, response.getId());
        Assertions.assertEquals(requestDTO.getUsername(), foundChef.getUsername());
        Assertions.assertEquals(requestDTO.getEmail(), foundChef.getEmail());
    }

    @Test
    void testUpdateChef_NoChangeException() {
        //Arrange
        UUID chefId = UUID.randomUUID();
        ChefUsernameAndEmailChangeRequest requestDTO = new ChefUsernameAndEmailChangeRequest(chefId, "oldUsername", "oldEmail@example.com");
        ChefEntity foundChef = ChefEntity.builder()
                .id(chefId)
                .username("oldUsername")
                .email("oldEmail@example.com")
                .password("oldPassword")
                .userRole(RoleEnum.CHEF)
                .build();
        when(chefRepository.findById(chefId)).thenReturn(Optional.of(foundChef));

        //Act and Assert
        assertThrows(NoChangeException.class, () -> chefService.updateChef(requestDTO));
    }

    @Test
    void testUpdateChef_ChefNotFound() {
        //Arrange
        UUID chefId = UUID.randomUUID();
        ChefUsernameAndEmailChangeRequest requestDTO = new ChefUsernameAndEmailChangeRequest(chefId, "newUsername", "newEmail");
        when(chefRepository.findById(chefId)).thenReturn(Optional.empty());

        //Act and Assert
        assertThrows(NotFoundException.class, () -> chefService.updateChef(requestDTO));
    }

    @Test
    void testUpdateChefPassword_SuccessfulUpdate() {
        //Arrange
        UUID chefId = UUID.randomUUID();
        ChangePasswordChangeRequest requestDTO = new ChangePasswordChangeRequest(chefId, "currentPassword", "newPassword");
        ChefEntity foundChef = ChefEntity.builder()
                .id(chefId)
                .username("testChef")
                .email("test@example.com")
                .password(passwordEncoder.encode("currentPassword")) // Assuming current password is encoded
                .userRole(RoleEnum.CHEF)
                .build();
        when(chefRepository.findById(chefId)).thenReturn(Optional.of(foundChef));
        when(passwordEncoder.matches(requestDTO.getOldPassword(), foundChef.getPassword())).thenReturn(true);
        when(passwordEncoder.encode(requestDTO.getNewPassword())).thenReturn("encodedNewPassword");
        when(chefRepository.save(foundChef)).thenReturn(foundChef);

        //Act
        BooleanResponse response = chefService.updateChefPassword(requestDTO);

        //Assert
        assertNotNull(response);
        assertTrue(response.getABoolean());
        Assertions.assertEquals("encodedNewPassword", foundChef.getPassword());
    }

    @Test
    void testUpdateChefPassword_InvalidCredentialsException() {
        //Arrange
        UUID chefId = UUID.randomUUID();
        ChangePasswordChangeRequest requestDTO = new ChangePasswordChangeRequest(chefId, "currentPassword", "newPassword");
        ChefEntity foundChef = ChefEntity.builder()
                .id(chefId)
                .username("testChef")
                .email("test@example.com")
                .password(passwordEncoder.encode("incorrectPassword"))
                .userRole(RoleEnum.CHEF)
                .build();

        when(chefRepository.findById(chefId)).thenReturn(Optional.of(foundChef));
        when(passwordEncoder.matches(requestDTO.getOldPassword(), foundChef.getPassword())).thenReturn(false);

        //Act and Assert
        assertThrows(InvalidCredentialsException.class, () -> chefService.updateChefPassword(requestDTO));
    }

    @Test
    void testUpdateChefPassword_ChefNotFound() {
        //Arrange
        UUID chefId = UUID.randomUUID();
        ChangePasswordChangeRequest requestDTO = new ChangePasswordChangeRequest(chefId, "currentPassword", "newPassword");

        when(chefRepository.findById(chefId)).thenReturn(Optional.empty());

        //Act and Assert
        assertThrows(NotFoundException.class, () -> chefService.updateChefPassword(requestDTO));
    }

    @Test
    void testDeleteChef_SuccessfulDeletion() {
        // Arrange
        UUID chefId = UUID.randomUUID();
        ChefIdRequest requestDTO = new ChefIdRequest(chefId);

        when(chefRepository.existsById(chefId)).thenReturn(true);

        // Act
        BooleanResponse response = chefService.deleteChef(requestDTO);

        // Assert
        assertNotNull(response);
        assertTrue(response.getABoolean());
        verify(chefRepository, times(1)).deleteById(chefId);
    }

    @Test
    void testDeleteChef_InvalidRequestException() {
        // Arrange
        UUID chefId = UUID.randomUUID();
        ChefIdRequest requestDTO = new ChefIdRequest(chefId);

        when(chefRepository.existsById(chefId)).thenReturn(false);

        // Act and Assert
        assertThrows(InvalidRequestException.class, () -> chefService.deleteChef(requestDTO));
        verify(chefRepository, never()).deleteById(chefId);
    }

    @Test
    void testDeleteChef_UnknownErrorException() {
        // Arrange
        UUID chefId = UUID.randomUUID();
        ChefIdRequest requestDTO = new ChefIdRequest(chefId);

        when(chefRepository.existsById(chefId)).thenThrow(new RuntimeException("Some unexpected error"));

        // Act and Assert
        assertThrows(UnknownErrorException.class, () -> chefService.deleteChef(requestDTO));
        verify(chefRepository, never()).deleteById(chefId);
    }
}
