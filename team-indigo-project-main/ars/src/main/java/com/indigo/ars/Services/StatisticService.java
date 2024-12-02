package com.indigo.ars.Services;

import com.indigo.ars.DTO.response.StatisticMonthPie;
import com.indigo.ars.DTO.statistic.GraphItemStatisticDTO;
import com.indigo.ars.DTO.response.DateStatisticGraph;
import com.indigo.ars.DTO.statistic.PieStatisticItem;
import com.indigo.ars.Entity.Form;
import com.indigo.ars.Repository.FormRepository;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.function.Function;
import java.util.stream.Collectors;
import java.util.stream.StreamSupport;

@Service
@AllArgsConstructor
public class StatisticService {

    private final FormRepository formRepository;

    public LocalDateTime getFilterPeriod(String period){
        int filterPeriod = Objects.equals(period, "week") ? 7 : Objects.equals(period, "month") ? 30 : Objects.equals(period, "year") ? 365 : 30;

        return LocalDateTime.now().minusDays(filterPeriod);
    }

    public DateStatisticGraph getDateStatisticMonth(String period) {
        LocalDateTime datePeriod = getFilterPeriod(period);
        List<Form> formsList = "allTime".equals(period)
                ? formRepository.findAllStatistic()
                : formRepository.findStatisticByTime(datePeriod);

        Map<LocalDate, Long> incidentsByDate = new HashMap<>();

        formsList.forEach(form -> {
                    LocalDateTime date = getGroupingDate(form.getDatetime(), period);
                    incidentsByDate.merge(LocalDate.from(date), 1L, Long::sum);
                });

        DateTimeFormatter formatter = getFormatterForPeriod(period);

        List<GraphItemStatisticDTO> dayStatistics = incidentsByDate.entrySet().stream()
                .sorted(Map.Entry.comparingByKey())
                .map(entry -> new GraphItemStatisticDTO(entry.getKey().format(formatter), entry.getValue().intValue()))
                .collect(Collectors.toList());

        return DateStatisticGraph.builder()
                .dates(dayStatistics)
                .build();
    }

    private LocalDateTime getGroupingDate(LocalDateTime dateTime, String period) {
        if ("year".equals(period) || "allTime".equals(period)) {
            return dateTime.withDayOfMonth(1);
        }
        return dateTime.toLocalDate().atStartOfDay();
    }

    private DateTimeFormatter getFormatterForPeriod(String period) {
        if ("year".equals(period) || "allTime".equals(period)) {
            return DateTimeFormatter.ofPattern("MM/yyyy");
        }
        return DateTimeFormatter.ofPattern("dd/MM");
    }

    public StatisticMonthPie getTypeStatisticMonth(String period) {

        LocalDateTime datePeriod = getFilterPeriod(period);

        List<Form> formsList = "allTime".equals(period)
                ? formRepository.findAllStatistic()
                : formRepository.findStatisticByTime(datePeriod);

        Map<String, Integer> incidentTypeCounts = formsList.stream()
                .flatMap(form -> form.getType().stream())
                .collect(Collectors.toMap(type -> type, type -> 1, Integer::sum));

        List<PieStatisticItem> typeStatistics = incidentTypeCounts.entrySet().stream()
                .map(entry -> PieStatisticItem.builder()
                        .name(entry.getKey())
                        .incidents(entry.getValue())
                        .build())
                .collect(Collectors.toList());

        return StatisticMonthPie.builder()
                .types(typeStatistics)
                .build();
    }

    public StatisticMonthPie getSeverityStatisticMonth(String period) {
        LocalDateTime datePeriod = getFilterPeriod(period);

        List<Form> formsList = "allTime".equals(period)
                ? formRepository.findAllStatistic()
                : formRepository.findStatisticByTime(datePeriod);

        Map<String, Integer> incidentSeverityCount = formsList.stream()
                .map(Form::getSeverity)
                .collect(Collectors.groupingBy(Function.identity(), Collectors.reducing(0, e -> 1, Integer::sum)));

        List<PieStatisticItem> severityStatistics = incidentSeverityCount.entrySet().stream()
                .map(entry -> new PieStatisticItem(entry.getKey(), entry.getValue()))
                .collect(Collectors.toList());

        return StatisticMonthPie.builder()
                .types(severityStatistics)
                .build();
    }
}
