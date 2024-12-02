package dishdive.dto.recipe.request;

import dishdive.business.annotation.ValidUuidAnnotation;
import dishdive.persistence.entity.TagEnum;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.NotNull;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;
import java.util.List;
import java.util.UUID;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class RecipeCreationRequest {
    @NotNull
    @ValidUuidAnnotation.ValidUUID
    private UUID userId;

    @NotBlank
    private String title;

    @NotBlank
    private String description;

    @NotNull
    private LocalDateTime creationTime;

    @NotNull
    private Integer servings;

    @NotNull
    private Integer prepTime;

    @NotNull
    private Integer cookTime;

    @NotNull
    private TagEnum recipeTag;

    @NotEmpty
    private List<IngredientRequest> ingredients;
}
