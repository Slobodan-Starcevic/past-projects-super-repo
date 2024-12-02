package com.indigo.ars.DTO.response;

import com.indigo.ars.DTO.FormListDTO;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.HashMap;
import java.util.List;

@Data
@NoArgsConstructor
public class PageReportsResponse {
    private List<FormListDTO> reports;
    private FilterCountsResponse filterCounts;
    private int currentPage;
    private int totalPage;
    private long totalElements;
}
