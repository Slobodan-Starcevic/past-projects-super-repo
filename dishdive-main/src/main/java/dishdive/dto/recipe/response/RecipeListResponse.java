package dishdive.dto.recipe.response;

import dishdive.persistence.entity.RecipeEntity;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class RecipeListResponse {
    private List<RecipeEntity> recipeList;
}
