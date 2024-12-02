package dishdive.dto.chef.response;

import dishdive.persistence.entity.ChefEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class SingleChefResponse {
    ChefEntity chef;
}
