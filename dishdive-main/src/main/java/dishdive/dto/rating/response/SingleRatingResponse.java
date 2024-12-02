package dishdive.dto.rating.response;

import com.fasterxml.jackson.annotation.JsonInclude;
import dishdive.persistence.entity.ChefEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class SingleRatingResponse {
    private UUID id;
    private ChefEntity rater;
    private int score;
    @JsonInclude(JsonInclude.Include.ALWAYS)
    private String comment;
}
