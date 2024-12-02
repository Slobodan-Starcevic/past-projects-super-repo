package com.indigo.ars.DTO;

import lombok.Builder;
import lombok.Data;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;

@Data
@Builder
public class FormListDTO {
    private int id;
    private String status;
    private String building;
    private List<String> type;
    private String severity;
    private String employeeName;
    private String date;
}
