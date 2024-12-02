package dishdive.dto.recipe.response;

import dishdive.persistence.entity.TagEnum;
import lombok.Data;

import java.time.LocalDateTime;
import java.util.HashMap;

import static dishdive.persistence.entity.TagEnum.*;

@Data
public class FilterCountsResponse {
    private HashMap<LocalDateTime, Integer> creationTimeCounts = new HashMap<>();
    private HashMap<TagEnum, Integer> recipeTagCounts = new HashMap<>();

    public FilterCountsResponse(){
        this.recipeTagCounts.put(BREAKFAST, 0);
        this.recipeTagCounts.put(LUNCH, 0);
        this.recipeTagCounts.put(DINNER, 0);
        this.recipeTagCounts.put(DESSERT, 0);
        this.recipeTagCounts.put(SNACK, 0);
    }
}
