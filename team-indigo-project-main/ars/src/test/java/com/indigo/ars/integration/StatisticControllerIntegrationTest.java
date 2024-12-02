package com.indigo.ars.integration;

import com.indigo.ars.Controller.StatisticController;
import com.indigo.ars.DTO.response.DateStatisticGraph;
import com.indigo.ars.DTO.response.StatisticMonthPie;
import com.indigo.ars.Services.StatisticService;
import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;

import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@Disabled
@WebMvcTest(StatisticController.class)
public class StatisticControllerIntegrationTest {

    @Autowired
    private MockMvc mockMvc;

    @Mock
    private StatisticService statisticService;

    @InjectMocks
    private StatisticController statisticController;

    public void setup() {
        MockitoAnnotations.openMocks(this);
    }

    @Test
    public void getDateStatisticsMonth_ShouldReturnDateStatisticMonthGraph() throws Exception {
        DateStatisticGraph response = new DateStatisticGraph();
        when(statisticService.getDateStatisticMonth("month")).thenReturn(response);

        mockMvc.perform(get("/statistic/calendar?period=month"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$").isMap());
    }

    @Test
    public void getTypeStatisticsMonth_ShouldReturnTypeStatisticMonthBar() throws Exception {
        StatisticMonthPie response = new StatisticMonthPie();
        when(statisticService.getTypeStatisticMonth("month")).thenReturn(response);

        mockMvc.perform(get("/statistic/type?period=month"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$").isMap());
    }
}
