package com.indigo.ars.unit.Services;

import com.indigo.ars.DTO.response.DateStatisticGraph;
import com.indigo.ars.Entity.Form;
import com.indigo.ars.Repository.FormRepository;
import com.indigo.ars.Services.StatisticService;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.stream.Collectors;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
public class StatisticServiceTest {

    @Mock
    private FormRepository formRepository;

    @InjectMocks
    private StatisticService statisticService;

    @Test
    void testDateStatisticsWeek() {
        List<Form> forms = createMockForms("week");
        when(formRepository.findStatisticByTime(any(LocalDateTime.class))).thenReturn(forms);

        DateStatisticGraph result = statisticService.getDateStatisticMonth("week");

        assertNotNull(result);
        assertNotNull(result.getDates());
        assertEquals(4, result.getDates().size());

        verify(formRepository, times(1)).findStatisticByTime(any(LocalDateTime.class));
    }

    @Test
    void testDateStatisticsMonth() {

        List<Form> forms = createMockForms("month");

        when(formRepository.findStatisticByTime(any(LocalDateTime.class))).thenReturn(forms);

        DateStatisticGraph result = statisticService.getDateStatisticMonth("month");

        assertNotNull(result);
        assertNotNull(result.getDates());
        assertEquals(8, result.getDates().size());
        assertEquals(2, result.getDates().get(1).getIncidents());

        verify(formRepository, times(1)).findStatisticByTime(any(LocalDateTime.class));
    }


    @Test
    void testDateStatisticsYear() {
        List<Form> forms = createMockForms("year");
        when(formRepository.findStatisticByTime(any(LocalDateTime.class))).thenReturn(forms);

        DateStatisticGraph result = statisticService.getDateStatisticMonth("year");

        assertNotNull(result);
        assertNotNull(result.getDates());
//        assertEquals(2, result.getDates().size());

        verify(formRepository, times(1)).findStatisticByTime(any(LocalDateTime.class));
    }

    @Test
    void testDateStatisticsAllTime() {
        List<Form> forms = createMockForms("allTime");
        when(formRepository.findAllStatistic()).thenReturn(forms);

        DateStatisticGraph result = statisticService.getDateStatisticMonth("allTime");

        assertNotNull(result);
        assertNotNull(result.getDates());
//        assertEquals(9, result.getDates().size());

        verify(formRepository, times(1)).findAllStatistic();
    }

    @Test
    void testGetFilterPeriodForWeek() {
        LocalDateTime result = statisticService.getFilterPeriod("week");
        LocalDateTime expected = LocalDateTime.now().minusDays(7);
        assertEquals(expected.toLocalDate(), result.toLocalDate());
    }

    @Test
    void testGetFilterPeriodForMonth() {
        LocalDateTime result = statisticService.getFilterPeriod("month");
        LocalDateTime expected = LocalDateTime.now().minusDays(30);
        assertEquals(expected.toLocalDate(), result.toLocalDate());
    }

    @Test
    void testGetFilterPeriodForYear() {
        LocalDateTime result = statisticService.getFilterPeriod("year");
        LocalDateTime expected = LocalDateTime.now().minusDays(365);
        assertEquals(expected.toLocalDate(), result.toLocalDate());
    }

    @Test
    void testGetFilterPeriodForInvalid() {
        LocalDateTime result = statisticService.getFilterPeriod("invalid");
        LocalDateTime expected = LocalDateTime.now().minusDays(30);
        assertEquals(expected.toLocalDate(), result.toLocalDate());
    }

    private List<Form> createMockForms(String period) {
        List<Form> allForms = Arrays.asList(
                Form.builder().datetime(LocalDateTime.now()).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(2)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(2)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(2)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(2)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(5)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(5)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(6)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(18)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(20)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(22)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(22)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(23)).build(),
                Form.builder().datetime(LocalDateTime.now().minusDays(45)).build(),
                Form.builder().datetime(LocalDateTime.now().minusWeeks(83)).build(),
                Form.builder().datetime(LocalDateTime.now().minusWeeks(93)).build(),
                Form.builder().datetime(LocalDateTime.now().minusMonths(94)).build(),
                Form.builder().datetime(LocalDateTime.now().minusMonths(98)).build(),
                Form.builder().datetime(LocalDateTime.now().minusMonths(99)).build(),
                Form.builder().datetime(LocalDateTime.now().minusYears(1)).build(),
                Form.builder().datetime(LocalDateTime.now().minusYears(1).minusDays(10)).build(),
                Form.builder().datetime(LocalDateTime.now().minusYears(1).minusDays(12)).build(),
                Form.builder().datetime(LocalDateTime.now().minusYears(1).minusDays(22)).build(),
                Form.builder().datetime(LocalDateTime.now().minusYears(1).minusDays(38)).build(),
                Form.builder().datetime(LocalDateTime.now().minusYears(1).minusDays(19)).build()
        );

        LocalDateTime cutoffDate;
        switch (period) {
            case "week":
                cutoffDate = LocalDateTime.now().minusWeeks(1);
                break;
            case "month":
                cutoffDate = LocalDateTime.now().minusMonths(1);
                break;
            case "year":
                cutoffDate = LocalDateTime.now().minusYears(1);
                break;
            case "allTime":
                return allForms;
            default:
                throw new IllegalArgumentException("Invalid period: " + period);
        }

        return allForms.stream()
                .filter(form -> form.getDatetime().isAfter(cutoffDate))
                .collect(Collectors.toList());
    }


    @Test
    void testGetDateStatisticMonthWithEmptyList() {
        when(formRepository.findStatisticByTime(any(LocalDateTime.class))).thenReturn(Collections.emptyList());
        DateStatisticGraph result = statisticService.getDateStatisticMonth("month");

        assertNotNull(result);
        assertTrue(result.getDates().isEmpty());
    }

}
