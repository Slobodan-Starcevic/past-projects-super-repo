package dishdive.dto.recipe.response;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonInclude;
import dishdive.dto.recipe.request.IngredientRequest;
import dishdive.persistence.entity.ChefEntity;
import dishdive.persistence.entity.TagEnum;
import jakarta.persistence.EnumType;
import jakarta.persistence.Enumerated;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.math.BigDecimal;
import java.util.List;
import java.util.UUID;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class SingleRecipeResponse {
    private UUID id;

    private ChefEntity poster;

    private String title;

    private String description;

    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss.SSSZ")
    private String creationTime;

    private Integer servings;

    private Integer prepTime;

    private Integer cookTime;

    @Enumerated(EnumType.STRING)
    private TagEnum recipeTag;

    private List<IngredientRequest> ingredients;

    @JsonInclude(JsonInclude.Include.ALWAYS)
    private BigDecimal rating;
}
