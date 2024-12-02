package dishdive.dto.chef.request;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.hibernate.validator.constraints.Length;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class ChefDataRequest {
    @NotBlank
    @Length(max = 30, min = 3)
    private String username;
    @Email
    @NotBlank
    @NotNull
    @Length(max = 254)
    private String email;
    @NotBlank
    private String password;
}
