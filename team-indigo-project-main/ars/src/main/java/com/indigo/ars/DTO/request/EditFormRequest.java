package com.indigo.ars.DTO.request;


import com.indigo.ars.DTO.FormDTO;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class EditFormRequest {
    private String email;
    private FormDTO newForm;
    private String message;
}
