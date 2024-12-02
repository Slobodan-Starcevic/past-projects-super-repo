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
public class EmergencyResponseDTO {
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String emergencyResponseOfficer;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String teamLeaderName;
    @NotNull
    private boolean bandagesUsed;
    @NotNull
    private boolean extinguishersUsed;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String callDetails;
}
