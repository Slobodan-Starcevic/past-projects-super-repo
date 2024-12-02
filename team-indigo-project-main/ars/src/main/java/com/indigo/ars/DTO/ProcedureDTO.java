package com.indigo.ars.DTO;

import jakarta.validation.Valid;
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
public class ProcedureDTO {
    @NotNull
    private boolean isprocedure;
    @NotNull
    private boolean procedureFollowed;
    @NotNull
    private boolean personFamiliar;
    @NotNull
    @Size(min = 1, max = 30, message = "this is to long")
    private String howLikely;
    @Valid
    private PreventionDTO prevention;
    @NotNull
    private boolean reportHR;
    @Valid
    private DirectorDTO director;
}
