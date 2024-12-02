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
public class EmployeeDTO {
    @NotNull
    @Size(min = 1, max = 20, message = "this is to long")
    private String firstName;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String lastName;
    @NotNull
    @Email(message = "Invalid email format")
    @Size(min = 1, max = 40, message = "this is to long")
    private String email;
    @NotNull
    @Pattern(regexp = "^\\+(?:[0-9] ?){6,14}[0-9]$", message = "Invalid phone number format")
    private String phoneNumber;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String role;

}
