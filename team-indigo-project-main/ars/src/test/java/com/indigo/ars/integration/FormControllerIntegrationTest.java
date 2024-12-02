package com.indigo.ars.integration;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.indigo.ars.Controller.FormController;
import com.indigo.ars.DTO.FormDTO;
import com.indigo.ars.DTO.response.PageReportsResponse;
import com.indigo.ars.Services.FormService;
import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;

import java.util.Collections;
import java.util.UUID;

import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@Disabled
@WebMvcTest(FormController.class)
public class FormControllerIntegrationTest {

    @Autowired
    private MockMvc mockMvc;

    @Mock
    private FormService formService;

    @InjectMocks
    private FormController formController;

    @Autowired
    private ObjectMapper objectMapper;

    public void setup() {
        MockitoAnnotations.openMocks(this);
    }

    /*@Test
    public void getAllForms_ShouldReturnPageReportsResponse() throws Exception {
        int page = 0;
        int size = 5;
        Pageable pageable = PageRequest.of(page, size);
        PageReportsResponse response = new PageReportsResponse();

        when(formService.getAllForms(pageable)).thenReturn(response);

        mockMvc.perform(get("/form")
                        .param("page", String.valueOf(page))
                        .param("size", String.valueOf(size)))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$").isMap());
    }*/

//    @Test
//    public void getFormById_ShouldReturnForm() throws Exception {
//        int formId = 1;
//        FormDTO formDTO = new FormDTO();
//
//        when(formService.getFormById(formId)).thenReturn(formDTO);
//
//        mockMvc.perform(get("/form/{id}", formId))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").isMap());
//    }
//
//    @Test
//    public void addForm_ShouldReturnSuccessMessage() throws Exception {
//        FormDTO formDTO = new FormDTO();
//
//        mockMvc.perform(post("/form")
//                        .contentType(MediaType.APPLICATION_JSON)
//                        .content(objectMapper.writeValueAsString(formDTO)))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").value("Report Created"));
//    }
//
//    @Test
//    public void addForm_ShouldReturnErrorMessageOnFailure() throws Exception {
//        FormDTO formDTO = new FormDTO();
//
//        when(formService.save(any(FormDTO.class))).thenThrow(new RuntimeException("Some error occurred"));
//
//        mockMvc.perform(post("/form")
//                        .contentType(MediaType.APPLICATION_JSON)
//                        .content(objectMapper.writeValueAsString(formDTO)))
//                .andExpect(status().isInternalServerError())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").value("Error"));
//    }
}
