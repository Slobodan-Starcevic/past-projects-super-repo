package com.indigo.ars.DTO;

import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class PreventionDTO {
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String prevent;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String causes;
    @NotNull
    @Size(min = 1, max = 50, message = "this is to long")
    private String futureChanges;
}
