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
public class DirectorDTO {
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String directorName;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String recipientName;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String date;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String time;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String caseNumber;
}
