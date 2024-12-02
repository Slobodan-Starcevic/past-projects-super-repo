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
public class FormVersionResponseDTO {
    private FormDTO data;
    private int version;
    private String message;
    private String employeeName;
    private String dateTime;
}
