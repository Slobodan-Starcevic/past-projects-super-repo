package dishdive.dto.chef.request;

import dishdive.business.annotation.ValidUuidAnnotation;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class ChefIdRequest {
    @ValidUuidAnnotation.ValidUUID
    private UUID id;
}
