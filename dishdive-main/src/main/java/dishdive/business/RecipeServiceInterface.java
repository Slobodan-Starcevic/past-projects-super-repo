package dishdive.business;

import com.fasterxml.jackson.core.JsonProcessingException;
import dishdive.dto.recipe.request.RecipeCreationRequest;
import dishdive.dto.recipe.response.AllRecipeResponse;
import dishdive.dto.recipe.response.SingleRecipeResponse;
import dishdive.persistence.entity.TagEnum;
import org.springframework.data.domain.Pageable;

import java.time.LocalDateTime;
import java.util.UUID;

public interface RecipeServiceInterface {
    AllRecipeResponse getAllRecipes(Pageable pageable, String title, LocalDateTime creationTime, Integer servings, Integer cookTime, TagEnum recipeTag, Integer rating) throws JsonProcessingException;
    SingleRecipeResponse getRecipeById(UUID requestDTO) throws JsonProcessingException;
    SingleRecipeResponse createRecipe(RecipeCreationRequest requestDTO) throws JsonProcessingException;
    SingleRecipeResponse editRecipe(UUID recipeId, RecipeCreationRequest requestDTO) throws JsonProcessingException;
    Boolean deleteRecipe(UUID recipeId);
}
