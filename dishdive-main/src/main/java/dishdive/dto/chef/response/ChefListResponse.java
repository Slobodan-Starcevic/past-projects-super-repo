package dishdive.dto.chef.response;

import dishdive.persistence.entity.ChefEntity;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class ChefListResponse {
    List<ChefEntity> chefList;
}
