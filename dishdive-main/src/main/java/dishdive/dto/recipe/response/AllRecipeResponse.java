package dishdive.dto.recipe.response;

import com.fasterxml.jackson.annotation.JsonInclude;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@NoArgsConstructor
public class AllRecipeResponse {
    private List<SingleRecipeResponse> recipes;
    @JsonInclude(JsonInclude.Include.ALWAYS)
    private FilterCountsResponse filterCounts;
    private int page;
    private int totalPages;
    private int totalItems;
}
