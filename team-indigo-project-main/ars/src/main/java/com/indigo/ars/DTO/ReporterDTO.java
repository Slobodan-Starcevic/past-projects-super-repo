package com.indigo.ars.DTO;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Pattern;
import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class ReporterDTO {
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String name;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String department;
    @NotNull
    @Pattern(regexp = "^\\+(?:[0-9] ?){6,14}[0-9]$", message = "Invalid phone number format")
    private String phone;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    @Email(message = "Invalid email format")
    private String email;
}
