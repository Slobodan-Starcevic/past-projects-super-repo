package dishdive.unit;

import com.fasterxml.jackson.core.JsonProcessingException;
import dishdive.business.exception.InvalidRequestException;
import dishdive.business.exception.NotFoundException;
import dishdive.business.service.RecipeService;
import dishdive.dto.recipe.request.IngredientRequest;
import dishdive.dto.recipe.request.RecipeCreationRequest;
import dishdive.dto.recipe.response.AllRecipeResponse;
import dishdive.dto.recipe.response.SingleRecipeResponse;
import dishdive.persistence.entity.*;
import dishdive.persistence.repository.ChefRepository;
import dishdive.persistence.repository.RatingRepository;
import dishdive.persistence.repository.RecipeRepository;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.data.domain.PageRequest;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.*;

import static dishdive.business.service.RecipeService.convertDTOToJson;
import static org.mockito.Mockito.*;
import static org.junit.jupiter.api.Assertions.*;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.never;
import static org.mockito.Mockito.when;

@ExtendWith(MockitoExtension.class)
public class RecipeServiceTest {
    @Mock
    private RecipeRepository recipeRepository;
    @Mock
    private ChefRepository chefRepository;
    @Mock
    private RatingRepository ratingRepository;
    @InjectMocks
    private RecipeService recipeService;

    @Test
    void testGetAllRecipes() throws JsonProcessingException {
        // Arrange
        ChefEntity chef = ChefEntity.builder()
                .id(UUID.randomUUID())
                .username("John Doe")
                .email("jon@gmail.com")
                .userRole(RoleEnum.CHEF)
                .password("wow")
                .build();
        LocalDateTime now = LocalDateTime.now();
        RecipeEntity recipe = RecipeEntity.builder()
                .id(UUID.randomUUID())
                .poster(chef)
                .title("Test Recipe")
                .description("This is a test recipe.")
                .creationTime(now)
                .servings(4)
                .prepTime(20)
                .cookTime(30)
                .recipeTag(TagEnum.DINNER)
                .ingredients("[{\"name\":\"wow\",\"amount\":1}]")
                .rating(new BigDecimal("4.5"))
                .build();

        List<RecipeEntity> mockRecipeList = Collections.singletonList(recipe);
        when(recipeRepository.findAll(any())).thenReturn(mockRecipeList);

        // Act
        AllRecipeResponse response = recipeService.getAllRecipes(PageRequest.of(1, 10), "This is a test recipe.", now, 4, 30, TagEnum.DINNER, 4);

        // Assert
        List<SingleRecipeResponse> result = response.getRecipes();
        Assertions.assertEquals(1, result.size());
        Assertions.assertEquals("Test Recipe", result.get(0).getTitle());
    }

    @Test
    void testGetRecipeById_ExistingRecipe() throws JsonProcessingException {
        // Arrange
        UUID recipeId = UUID.randomUUID();
        RecipeEntity mockRecipe = RecipeEntity.builder()
                .id(recipeId)
                .title("Test Recipe")
                .description("This is a test recipe.")
                .creationTime(LocalDateTime.now())
                .servings(4)
                .prepTime(20)
                .cookTime(30)
                .recipeTag(TagEnum.DINNER)
                .ingredients("[{\"name\":\"wow\",\"amount\":1}]")
                .rating(new BigDecimal("4.5"))
                .build();

        when(recipeRepository.findById(recipeId)).thenReturn(Optional.of(mockRecipe));
        when(ratingRepository.getRatingSummaryByRecipeId(recipeId)).thenReturn(new BigDecimal("4.5"));

        // Act
        SingleRecipeResponse response = recipeService.getRecipeById(recipeId);

        // Assert
        Assertions.assertEquals(recipeId, response.getId());
        Assertions.assertEquals("Test Recipe", response.getTitle());
        Assertions.assertNotNull(response.getCreationTime());
        Assertions.assertNotNull(response.getIngredients());
        Assertions.assertNotNull(response.getRating());
    }


    @Test
    void testGetRecipeById_NonExistingRecipe() {
        // Arrange
        UUID nonExistingRecipeId = UUID.randomUUID();
        when(recipeRepository.findById(nonExistingRecipeId)).thenReturn(Optional.empty());

        // Act and Assert
        assertThrows(NotFoundException.class, () -> recipeService.getRecipeById(nonExistingRecipeId));
    }


    @Test
    void testCreateRecipe_ValidRequest() throws JsonProcessingException {
        // Arrange
        UUID posterId = UUID.randomUUID();
        ChefEntity mockChef = new ChefEntity();
        mockChef.setId(posterId);
        when(chefRepository.findById(posterId)).thenReturn(Optional.of(mockChef));
        RecipeCreationRequest requestDTO = new RecipeCreationRequest();
        requestDTO.setUserId(posterId);
        requestDTO.setTitle("New Recipe");
        requestDTO.setDescription("Description");
        requestDTO.setCreationTime(LocalDateTime.now());
        requestDTO.setServings(3);
        requestDTO.setPrepTime(30);
        requestDTO.setCookTime(50);
        requestDTO.setRecipeTag(TagEnum.LUNCH);
        List<IngredientRequest> ingredientList = new ArrayList<>();
        ingredientList.add(new IngredientRequest("cucumba", 1));
        ingredientList.add(new IngredientRequest("Ingredient 2", 3));
        requestDTO.setIngredients(ingredientList);

        // Act
        SingleRecipeResponse response = recipeService.createRecipe(requestDTO);

        // Assert
        Assertions.assertNotNull(response);
        Assertions.assertEquals("New Recipe", response.getTitle());
        Assertions.assertEquals(2, response.getIngredients().size());
    }

    @Test
    void testCreateRecipe_InvalidPoster() {
        // Arrange
        UUID invalidPosterId = UUID.randomUUID();
        when(chefRepository.findById(invalidPosterId)).thenReturn(Optional.empty());
        RecipeCreationRequest requestDTO = new RecipeCreationRequest();
        requestDTO.setUserId(invalidPosterId);
        requestDTO.setTitle("New Recipe");
        requestDTO.setDescription("Description");
        requestDTO.setCreationTime(LocalDateTime.now());
        requestDTO.setServings(3);
        requestDTO.setPrepTime(30);
        requestDTO.setCookTime(50);
        requestDTO.setRecipeTag(TagEnum.LUNCH);
        List<IngredientRequest> ingredientList = new ArrayList<>();
        ingredientList.add(new IngredientRequest("cucumba", 1));
        ingredientList.add(new IngredientRequest("Ingredient 2", 3));
        requestDTO.setIngredients(ingredientList);

        // Act and Assert
        assertThrows(InvalidRequestException.class, () -> recipeService.createRecipe(requestDTO));
    }

    @Test
    void testDeleteRecipe_RecipeNotFound() {
        // Arrange
        UUID nonExistentRecipeId = UUID.randomUUID();

        when(recipeRepository.findById(nonExistentRecipeId)).thenReturn(Optional.empty());

        // Act and Assert
        assertThrows(NotFoundException.class, () -> recipeService.deleteRecipe(nonExistentRecipeId));
        verify(ratingRepository, never()).deleteAll(anyList());
    }

    @Test
    void testDeleteRecipe_WithRatings() {
        // Arrange
        UUID recipeId = UUID.randomUUID();
        RecipeEntity mockRecipe = RecipeEntity.builder().id(recipeId).build();
        List<RatingEntity> mockRatings = List.of(
                RatingEntity.builder().id(UUID.randomUUID()).recipe(mockRecipe).score(3).build(),
                RatingEntity.builder().id(UUID.randomUUID()).recipe(mockRecipe).score(3).build()
        );

        when(recipeRepository.findById(recipeId)).thenReturn(Optional.of(mockRecipe));
        when(ratingRepository.findAllByRecipeId(recipeId)).thenReturn(mockRatings);

        // Act
        boolean result = recipeService.deleteRecipe(recipeId);

        // Assert
        assertTrue(result);
        verify(ratingRepository, times(1)).deleteAll(mockRatings);
        verify(recipeRepository, times(1)).delete(mockRecipe);
    }

    @Test
    public void testEditRecipe() throws JsonProcessingException {
        // Arrange
        UUID recipeId = UUID.randomUUID();
        RecipeCreationRequest requestDTO = createSampleRecipeCreationRequest();
        ChefEntity chefEntity = createSampleChefEntity();
        RecipeEntity existingRecipe = createSampleRecipeEntity();

        when(chefRepository.findById(requestDTO.getUserId())).thenReturn(Optional.of(chefEntity));
        when(recipeRepository.findById(recipeId)).thenReturn(Optional.of(existingRecipe));
        when(recipeRepository.save(any())).thenAnswer(invocation -> invocation.getArgument(0));

        // Act
        SingleRecipeResponse result = recipeService.editRecipe(recipeId, requestDTO);

        // Assert
        assertNotNull(result);
        verify(chefRepository, times(1)).findById(requestDTO.getUserId());
        verify(recipeRepository, times(1)).findById(recipeId);
        verify(recipeRepository, times(1)).save(any());
    }

    @Test
    public void testEditRecipe_InvalidRequestException() throws JsonProcessingException {
        // Arrange
        UUID recipeId = UUID.randomUUID();
        RecipeCreationRequest requestDTO = createSampleRecipeCreationRequest();
        Optional<ChefEntity> emptyChef = Optional.empty();
        Optional<RecipeEntity> emptyRecipe = Optional.empty();

        when(chefRepository.findById(requestDTO.getUserId())).thenReturn(emptyChef);
        when(recipeRepository.findById(recipeId)).thenReturn(emptyRecipe);

        // Act and Assert
        assertThrows(InvalidRequestException.class, () -> recipeService.editRecipe(recipeId, requestDTO));
        verify(chefRepository, times(1)).findById(requestDTO.getUserId());
        verify(recipeRepository, times(1)).findById(recipeId);
        verify(recipeRepository, never()).save(any()); // Ensure save method is not called in this scenario
    }

    private RecipeCreationRequest createSampleRecipeCreationRequest() {
        RecipeCreationRequest request = new RecipeCreationRequest();
        request.setUserId(UUID.randomUUID());
        request.setTitle("Sample Title");
        request.setDescription("Sample Description");
        request.setCreationTime(LocalDateTime.now());
        request.setServings(4);
        request.setPrepTime(30);
        request.setCookTime(60);
        request.setRecipeTag(TagEnum.DINNER);

        List<IngredientRequest> ingredients = new ArrayList<>();
        IngredientRequest ingredient1 = new IngredientRequest("Ingredient 1", 1);
        IngredientRequest ingredient2 = new IngredientRequest("Ingredient 2", 1);
        ingredients.add(ingredient1);
        ingredients.add(ingredient2);

        request.setIngredients(ingredients);

        return request;
    }

    private ChefEntity createSampleChefEntity() {
        ChefEntity chefEntity = new ChefEntity();
        chefEntity.setId(UUID.randomUUID());
        chefEntity.setUsername("sampleChef");
        chefEntity.setEmail("sample@example.com");
        chefEntity.setPassword("samplePassword");
        chefEntity.setUserRole(RoleEnum.CHEF);

        return chefEntity;
    }

    private RecipeEntity createSampleRecipeEntity() throws JsonProcessingException {
        RecipeEntity recipeEntity = new RecipeEntity();
        recipeEntity.setId(UUID.randomUUID());
        recipeEntity.setPoster(createSampleChefEntity());
        recipeEntity.setTitle("Sample Recipe");
        recipeEntity.setDescription("Sample Recipe Description");
        recipeEntity.setCreationTime(LocalDateTime.now());
        recipeEntity.setServings(4);
        recipeEntity.setPrepTime(30);
        recipeEntity.setCookTime(60);
        recipeEntity.setRecipeTag(TagEnum.SNACK);

        List<IngredientRequest> ingredients = new ArrayList<>();
        IngredientRequest ingredient1 = new IngredientRequest("Ingredient 1", 1);
        IngredientRequest ingredient2 = new IngredientRequest("Ingredient 2", 1);
        recipeEntity.setIngredients(convertDTOToJson(Arrays.asList(ingredient1, ingredient2)));

        recipeEntity.setRating(BigDecimal.valueOf(4.5));

        return recipeEntity;
    }

}
