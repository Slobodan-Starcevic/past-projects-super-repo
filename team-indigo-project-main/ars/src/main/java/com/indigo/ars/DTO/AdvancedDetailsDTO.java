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
public class AdvancedDetailsDTO {
    @NotNull
    @NotEmpty
    private List<String> circumstances;
    @NotNull
    @NotEmpty
    private List<String> actions;
    @NotNull
    @NotEmpty
    private List<String> organization;
    @NotNull
    @Size(min = 1, max = 50, message = "this is to long")
    private String explanation;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String reoccurrence;
    @NotNull
    @NotEmpty
    private List<String> severity;
}
