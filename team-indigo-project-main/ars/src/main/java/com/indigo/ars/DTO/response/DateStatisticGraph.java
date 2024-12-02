package com.indigo.ars.DTO.response;

import com.indigo.ars.DTO.statistic.GraphItemStatisticDTO;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class DateStatisticGraph {
    private List<GraphItemStatisticDTO> dates;
}
