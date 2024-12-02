package dishdive.dto.chef.request;

import dishdive.business.annotation.ValidUuidAnnotation.ValidUUID;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class ChangePasswordChangeRequest {
    @NotNull
    @ValidUUID
    private UUID id;
    @NotBlank
    private String oldPassword;
    @NotBlank
    private String newPassword;
}
