package dishdive.dto.chef.request;

import jakarta.validation.constraints.NotBlank;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.hibernate.validator.constraints.Length;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class ChefUsernameRequest {
    @NotBlank
    @Length(max = 30, min = 3)
    public String username;
}
