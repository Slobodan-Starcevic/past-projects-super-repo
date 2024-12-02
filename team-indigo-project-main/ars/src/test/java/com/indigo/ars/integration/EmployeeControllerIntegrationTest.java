package com.indigo.ars.integration;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.indigo.ars.Controller.EmployeeController;
import com.indigo.ars.DTO.EmployeeDTO;
import com.indigo.ars.Services.EmployeeService;
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
@WebMvcTest(EmployeeController.class)
public class EmployeeControllerIntegrationTest {

    @Autowired
    private MockMvc mockMvc;

    @Mock
    private EmployeeService employeeService;

    @InjectMocks
    private EmployeeController employeeController;

    @Autowired
    private ObjectMapper objectMapper;

    public void setup() {
        MockitoAnnotations.openMocks(this);
    }

    @Test
    public void getAllEmployees_ShouldReturnListOfEmployees() throws Exception {
        when(employeeService.getAllEmployees()).thenReturn(Collections.singletonList(new EmployeeDTO()));

        mockMvc.perform(get("/employee"))
                .andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$").isArray());
    }

//    @Test
//    public void getEmployeeByFirstName_ShouldReturnEmployee() throws Exception {
//        String firstName = "John";
//        when(employeeService.getEmployeeByFirstName(firstName)).thenReturn(Optional.of(new EmployeeDTO()));
//
//        mockMvc.perform(get("/employee/{firstName}", firstName))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").isMap());
//    }
//
//    @Test
//    public void getEmployeeByLastName_ShouldReturnEmployee() throws Exception {
//        String lastName = "Doe";
//        when(employeeService.getEmployeeByLastName(lastName)).thenReturn(Optional.of(new EmployeeDTO()));
//
//        mockMvc.perform(get("/employee/{lastName}", lastName))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").isMap());
//    }
//
//    @Test
//    public void getEmployeeByFirstNameAndLastName_ShouldReturnEmployee() throws Exception {
//        String firstName = "John";
//        String lastName = "Doe";
//        when(employeeService.getEmployeeByFirstNameAndLastName(firstName, lastName)).thenReturn(Optional.of(new EmployeeDTO()));
//
//        mockMvc.perform(get("/employee/{firstName}/{lastName}", firstName, lastName))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").isMap());
//    }
//
//    @Test
//    public void getEmployeeByEmail_ShouldReturnEmployee() throws Exception {
//        String email = "john.doe@example.com";
//        when(employeeService.getEmployeeByEmail(email)).thenReturn(Optional.of(new EmployeeDTO()));
//
//        mockMvc.perform(get("/employee/{email}", email))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").isMap());
//    }
//
//    @Test
//    public void getEmployeeByPhoneNumber_ShouldReturnEmployee() throws Exception {
//        String phoneNumber = "123-456-7890";
//        when(employeeService.getEmployeeByPhoneNumber(phoneNumber)).thenReturn(Optional.of(new EmployeeDTO()));
//
//        mockMvc.perform(get("/employee/{phoneNumber}", phoneNumber))
//                .andExpect(status().isOk())
//                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
//                .andExpect(jsonPath("$").isMap());
//    }

    @Test
    public void addEmployee_ShouldReturnAddedEmployee() throws Exception {
        EmployeeDTO employeeDTO = new EmployeeDTO();
        when(employeeService.createEmployee(any(EmployeeDTO.class))).thenReturn(employeeDTO);

        ResultActions resultActions = mockMvc.perform(post("/employee")
                .contentType(MediaType.APPLICATION_JSON)
                .content(objectMapper.writeValueAsString(employeeDTO)));

        resultActions.andExpect(status().isOk())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$").isMap());
    }
}
