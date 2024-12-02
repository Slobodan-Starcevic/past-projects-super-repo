package com.indigo.ars.DTO.response;

import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.HashMap;

@Data
public class FilterCountsResponse {
    private HashMap<String, Integer> reporterCounts = new HashMap<>();
    private HashMap<String, Integer> incidentTypeCounts = new HashMap<>();
    private HashMap<String, Integer> severityCounts = new HashMap<>();
    private HashMap<String, Integer> dateCounts = new HashMap<>();
    private HashMap<String, Integer> statusCounts = new HashMap<>();
    private HashMap<String, Integer> buildingCounts = new HashMap<>();

    public FilterCountsResponse(){
        this.incidentTypeCounts.put("Fire", 0);
        this.incidentTypeCounts.put("Evacuation", 0);
        this.incidentTypeCounts.put("Personal Injury", 0);
        this.incidentTypeCounts.put("Damage", 0);

        this.severityCounts.put("Low", 0);
        this.severityCounts.put("Medium", 0);
        this.severityCounts.put("High", 0);

        this.statusCounts.put("Waiting", 0);
        this.statusCounts.put("Edited", 0);
        this.statusCounts.put("Completed", 0);
    }
}
