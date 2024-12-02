package dishdive.dto.recipe.request;

import dishdive.business.annotation.ValidUuidAnnotation;
import jakarta.validation.constraints.NotNull;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;
@Data
@NoArgsConstructor
@AllArgsConstructor
public class RecipeIdRequest {
    @NotNull
    @ValidUuidAnnotation.ValidUUID
    UUID recipeId;
}
