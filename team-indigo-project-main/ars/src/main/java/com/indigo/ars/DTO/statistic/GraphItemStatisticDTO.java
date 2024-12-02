package com.indigo.ars.DTO.statistic;


import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class GraphItemStatisticDTO {
    private String name;
    private int incidents;
}
