package com.indigo.ars.DTO;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.UUID;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class FormDTO {
    private ReporterDTO reporter;
    private IncidentDTO incident;
    private InjuredPersonDTO injuredPerson;
    private DamageDTO damage;
    private AdvancedDetailsDTO advancedDetails;
    private ProcedureDTO procedure;
}
