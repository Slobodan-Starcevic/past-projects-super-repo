package com.indigo.ars.integration;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.indigo.ars.Controller.BuildingController;
import com.indigo.ars.DTO.BuildingDTO;
import com.indigo.ars.Services.BuildingService;
import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.ResultActions;

import java.util.Collections;
import java.util.Optional;

import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@Disabled
@WebMvcTest(BuildingController.class)
public class BuildingControllerIntegrationTest {

    @Autowired
    private MockMvc mockMvc;

    @Mock
    private BuildingService buildingService;

    @InjectMocks
    private BuildingController buildingController;

    @Autowired
    private ObjectMapper objectMapper;

    public void setup() {
        MockitoAnnotations.openMocks(this);
    }

    @Test
    public void getAllBuildings_ShouldReturnListOfBuildings() throws Exception {
        when(buildingService.getAllBuildings()).thenReturn(Collections.singletonList(new BuildingDTO()));

        mockMvc.perform(get("/building"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$").isArray());
    }

//    @Test
//    public void getBuildingByAddress_ShouldReturnBuilding() throws Exception {
//        String address = "123 Main St";
//        when(buildingService.getBuildingByAddress(address)).thenReturn(Optional.of(new BuildingDTO()));
//
//        mockMvc.perform(get("/building/{address}", address))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").isMap());
//    }
//
//    @Test
//    public void getBuildingByCity_ShouldReturnBuilding() throws Exception {
//        String city = "Springfield";
//        when(buildingService.getBuildingByCity(city)).thenReturn(Optional.of(new BuildingDTO()));
//
//        mockMvc.perform(get("/building/{city}", city))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").isMap());
//    }
//
//    @Test
//    public void getBuildingByAddressAndCity_ShouldReturnBuilding() throws Exception {
//        String address = "123 Main St";
//        String city = "Springfield";
//        when(buildingService.getBuildingByAddressAndCity(address, city)).thenReturn(Optional.of(new BuildingDTO()));
//
//        mockMvc.perform(get("/building/{address}/{city}", address, city))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").isMap());
//    }

    @Test
    public void addBuilding_ShouldReturnAddedBuilding() throws Exception {
        BuildingDTO buildingDTO = new BuildingDTO();
        when(buildingService.createBuilding(any(BuildingDTO.class))).thenReturn(buildingDTO);

        ResultActions resultActions = mockMvc.perform(post("/building")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(buildingDTO)));

        resultActions.andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$").isMap());
    }
}
