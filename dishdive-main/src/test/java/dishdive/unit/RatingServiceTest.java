package dishdive.unit;

import dishdive.business.exception.NotFoundException;
import dishdive.business.service.RatingService;
import dishdive.dto.rating.request.NewRatingRequest;
import dishdive.dto.rating.response.SingleRatingResponse;
import dishdive.persistence.entity.*;
import dishdive.persistence.repository.ChefRepository;
import dishdive.persistence.repository.RatingRepository;
import dishdive.persistence.repository.RecipeRepository;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)

public class RatingServiceTest {
    @InjectMocks
    private RatingService ratingService;

    @Mock
    private RatingRepository ratingRepository;

    @Mock
    private ChefRepository chefRepository;

    @Mock
    private RecipeRepository recipeRepository;
    @Test
    void testGetAllRatingsByRecipeId() {
        // Arrange
        UUID recipeId = UUID.randomUUID();
        when(ratingRepository.findAllByRecipeId(recipeId)).thenReturn(createSampleRatingEntities());

        // Act
        List<SingleRatingResponse> response = ratingService.getAllRatingsByRecipeId(recipeId);

        // Assert
        assertNotNull(response);
        assertFalse(response.isEmpty());
    }

    @Test
    void testCreateRating_SuccessfulCreation() {
        // Arrange
        NewRatingRequest newRating = createSampleNewRatingRequest();
        when(chefRepository.findById(newRating.getPosterId())).thenReturn(Optional.of(createSampleChefEntity()));
        when(recipeRepository.findById(newRating.getRecipeId())).thenReturn(Optional.of(createSampleRecipeEntity()));

        // Act
        Boolean result = ratingService.createRating(newRating);

        // Assert
        assertTrue(result);
        verify(ratingRepository, times(1)).save(any(RatingEntity.class));
    }

    @Test
    void testCreateRating_RaterNotFound() {
        // Arrange
        NewRatingRequest newRating = createSampleNewRatingRequest();
        when(chefRepository.findById(newRating.getPosterId())).thenReturn(Optional.empty());
        when(recipeRepository.findById(any(UUID.class))).thenReturn(Optional.empty());

        // Act and Assert
        assertThrows(NotFoundException.class, () -> ratingService.createRating(newRating));
        verify(chefRepository, times(1)).findById(newRating.getPosterId());
    }

    @Test
    void testCreateRating_RecipeNotFound() {
        // Arrange
        NewRatingRequest newRating = createSampleNewRatingRequest();
        when(chefRepository.findById(newRating.getPosterId())).thenReturn(Optional.of(createSampleChefEntity()));
        when(recipeRepository.findById(newRating.getRecipeId())).thenReturn(Optional.empty());

        // Act and Assert
        assertThrows(NotFoundException.class, () -> ratingService.createRating(newRating));
        verify(ratingRepository, never()).save(any());
    }

    @Test
    void testDeleteRating_SuccessfulDeletion() {
        // Arrange
        UUID ratingId = UUID.randomUUID();
        when(ratingRepository.findById(ratingId)).thenReturn(Optional.of(createSampleRatingEntity()));

        // Act
        Boolean result = ratingService.deleteRating(ratingId);

        // Assert
        assertTrue(result);
        verify(ratingRepository, times(1)).delete(any(RatingEntity.class));
    }

    @Test
    void testDeleteRating_RatingNotFound() {
        // Arrange
        UUID ratingId = UUID.randomUUID();
        when(ratingRepository.findById(ratingId)).thenReturn(Optional.empty());

        // Act and Assert
        assertThrows(NotFoundException.class, () -> ratingService.deleteRating(ratingId));
        verify(ratingRepository, never()).delete(any());
    }

    private List<RatingEntity> createSampleRatingEntities() {
        List<RatingEntity> ratingEntities = new ArrayList<>();

        ChefEntity chef = createSampleChefEntity();
        RecipeEntity recipe = createSampleRecipeEntity();

        ratingEntities.add(
                RatingEntity.builder()
                        .id(UUID.randomUUID())
                        .rater(chef)
                        .recipe(recipe)
                        .score(4)
                        .comment("Great recipe!")
                        .build()
        );

        ratingEntities.add(
                RatingEntity.builder()
                        .id(UUID.randomUUID())
                        .rater(chef)
                        .recipe(recipe)
                        .score(5)
                        .comment("Excellent!")
                        .build()
        );

        return ratingEntities;
    }

    private NewRatingRequest createSampleNewRatingRequest() {
        return new NewRatingRequest(UUID.randomUUID(), UUID.randomUUID(), 5, "Awesome!");
    }

    private ChefEntity createSampleChefEntity() {
        return ChefEntity.builder()
                .id(UUID.randomUUID())
                .username("sampleChef")
                .email("chef@example.com")
                .password("password123")
                .userRole(RoleEnum.CHEF)
                .build();
    }

    private RecipeEntity createSampleRecipeEntity() {
        ChefEntity chef = createSampleChefEntity();

        return RecipeEntity.builder()
                .id(UUID.randomUUID())
                .poster(chef)
                .title("Sample Recipe")
                .description("A delicious recipe")
                .creationTime(LocalDateTime.now())
                .servings(4)
                .prepTime(30)
                .cookTime(45)
                .recipeTag(TagEnum.DINNER)
                .ingredients("Sample ingredients")
                .rating(BigDecimal.valueOf(4.5))
                .build();
    }

    private RatingEntity createSampleRatingEntity() {
        ChefEntity chef = createSampleChefEntity();
        RecipeEntity recipe = createSampleRecipeEntity();

        return RatingEntity.builder()
                .id(UUID.randomUUID())
                .rater(chef)
                .recipe(recipe)
                .score(4)
                .comment("Good recipe")
                .build();
    }

}
