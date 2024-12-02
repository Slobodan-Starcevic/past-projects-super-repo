/* package com.indigo.ars.unit;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.indigo.ars.DTO.BuildingDTO;
import com.indigo.ars.DTO.EmployeeDTO;
import com.indigo.ars.DTO.FormDTO;
import com.indigo.ars.Entity.Building;
import com.indigo.ars.Entity.Employee;
import com.indigo.ars.Entity.Form;
import com.indigo.ars.Repository.FormRepository;
import com.indigo.ars.Converters.ConverterService;
import com.indigo.ars.Services.FormService;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.ArgumentMatchers.eq;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
class FormServiceTest {

    @Mock
    private FormRepository formRepository;

    @InjectMocks
    private FormService formService;

    public FormServiceTest() {
        MockitoAnnotations.openMocks(this);
    }

    @Test
    void getAllForm() throws JsonProcessingException {
        // Mocking repository response
        List<Form> formEntities = new ArrayList<>();
        formEntities.add(new Form());
        when(formRepository.findAll()).thenReturn(formEntities);

        // Invoking the service method
        Iterable<FormDTO> result = formService.getAllForm();

        // Verifying the result
        assertEquals(formEntities.size(), ((List<FormDTO>) result).size());
        verify(formRepository, times(1)).findAll();
    }

    @Test
    void getFormByReporter() throws JsonProcessingException {
        // Mocking repository response
        List<Form> formEntities = new ArrayList<>();
        formEntities.add(new Form());
        when(formRepository.getFormByReporter(any(Employee.class))).thenReturn(formEntities);

        // Invoking the service method
        Iterable<FormDTO> result = formService.getFormByReporter(new EmployeeDTO());

        // Verifying the result
        assertEquals(formEntities.size(), ((List<FormDTO>) result).size());
        verify(formRepository, times(1)).getFormByReporter(any(Employee.class));
    }

    @Test
    void getFormByIncidentLocation() throws JsonProcessingException {
        // Mocking repository response
        List<Form> formEntities = new ArrayList<>();
        formEntities.add(new Form());
        when(formRepository.getFormByIncidentLocation(any(Building.class))).thenReturn(formEntities);

        // Invoking the service method
        Iterable<FormDTO> result = formService.getFormByIncidentLocation(new BuildingDTO());

        // Verifying the result
        assertEquals(formEntities.size(), ((List<FormDTO>) result).size());
        verify(formRepository, times(1)).getFormByIncidentLocation(any(Building.class));
    }

    @Test
    void getFormByData() throws JsonProcessingException {
        // Mocking repository response
        when(formRepository.getFormByData(anyString())).thenReturn(new Form());

        // Invoking the service method
        FormDTO result = formService.getFormByData("test-data");

        // Verifying the result
        verify(formRepository, times(1)).getFormByData(eq("test-data"));
    }

    @Test
    void save() throws JsonProcessingException {
        // Mocking repository response
        when(formRepository.save(any(Form.class))).thenReturn(new Form());

        // Invoking the service method
        FormDTO result = formService.save(new FormDTO());

        // Verifying the result
        verify(formRepository, times(1)).save(any(Form.class));
    }
}

 */