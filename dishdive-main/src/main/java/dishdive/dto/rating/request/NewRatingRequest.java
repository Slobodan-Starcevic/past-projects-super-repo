package dishdive.dto.rating.request;

import jakarta.validation.constraints.NotNull;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class NewRatingRequest {
    @NotNull
    private UUID posterId;
    @NotNull
    private UUID recipeId;
    @NotNull
    private Integer score;
    private String comment;
}
