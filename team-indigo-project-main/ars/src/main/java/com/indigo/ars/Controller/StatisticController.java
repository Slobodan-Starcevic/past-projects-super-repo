package com.indigo.ars.Controller;

import com.indigo.ars.DTO.response.DateStatisticGraph;
import com.indigo.ars.DTO.response.StatisticMonthPie;
import com.indigo.ars.Services.StatisticService;
import lombok.AllArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/statistic")
@AllArgsConstructor
public class StatisticController {

    private final StatisticService statisticService;

    @GetMapping("calendar")
    public ResponseEntity<?> getDateStatisticsMonth(@RequestParam(value = "period") String period) {
        DateStatisticGraph response = statisticService.getDateStatisticMonth(period);
        return ResponseEntity.ok(response);
    }

    @GetMapping("type")
    public ResponseEntity<?> getTypeStatisticsMonth(@RequestParam(value = "period") String period) {
        StatisticMonthPie response = statisticService.getTypeStatisticMonth(period);
        return ResponseEntity.ok(response);
    }

    @GetMapping("severity")
    public ResponseEntity<?> getSeverityStatisticsMonth(@RequestParam(value = "period") String period) {
        StatisticMonthPie response = statisticService.getSeverityStatisticMonth(period);
        return ResponseEntity.ok(response);
    }
//    @GetMapping("buildings")
//    public ResponseEntity<?> getBuildingsStatisticsMonth() {
//        StatisticMonthPie response = statisticService.getTypeStatisticMonth();
//        return ResponseEntity.ok(response);
//    }
}