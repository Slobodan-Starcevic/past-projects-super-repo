package com.indigo.ars.DTO;

import jakarta.validation.constraints.NotEmpty;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;
@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class IncidentDTO {
    @NotEmpty
    @NotNull
    private List<String> typeOfIncident;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String  date;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String time;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String location;
    @NotNull
    private boolean workHours;
    @NotNull
    private boolean whileWorking;
    @NotNull
    @Size(min = 1, max = 50, message = "this is to long")
    private String description;
    @NotNull
    @Size(min = 1, max = 50, message = "this is to long")
    private String environment;
}
