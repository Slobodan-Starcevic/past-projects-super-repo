package com.indigo.ars.DTO.response;

import com.indigo.ars.DTO.FormDTO;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class FormFullResponseDTO {
    private FormDTO data;private int id;
    private String status;
    private List<String> type;
    private String severity;
    private String employeeName;
    private String date;
}
