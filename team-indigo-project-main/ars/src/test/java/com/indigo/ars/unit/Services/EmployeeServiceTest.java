package com.indigo.ars.unit.Services;

import com.indigo.ars.Converters.EmployeeConverter;
import com.indigo.ars.DTO.EmployeeDTO;
import com.indigo.ars.Entity.Employee;
import com.indigo.ars.Repository.EmployeeRepository;
import com.indigo.ars.Services.EmployeeService;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;
import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.*;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
class EmployeeServiceTest {

    @Mock
    private EmployeeRepository employeeRepository;

    @Mock
    private EmployeeConverter employeeConverter;

    @InjectMocks
    private EmployeeService employeeService;

    @Test
    void createEmployee() {
        EmployeeDTO employeeDTO = EmployeeDTO.builder()
                .firstName("John")
                .lastName("Doe")
                .email("john.doe@example.com")
                .phoneNumber("1234567890")
                .role("Developer")
                .build();

        Employee employeeEntity = employeeConverter.EmployeeConverterDTOtoEntity(employeeDTO);
        when(employeeRepository.save(any(Employee.class))).thenReturn(employeeEntity);

        EmployeeDTO result = employeeService.createEmployee(employeeDTO);

        assertEquals(employeeDTO.getFirstName(), result.getFirstName());
        assertEquals(employeeDTO.getLastName(), result.getLastName());
        assertEquals(employeeDTO.getEmail(), result.getEmail());
        assertEquals(employeeDTO.getPhoneNumber(), result.getPhoneNumber());
        assertEquals(employeeDTO.getRole(), result.getRole());

        verify(employeeRepository, times(1)).save(any(Employee.class));
    }

    @Test
    void getEmployeeByFirstName() {
        String firstName = "John";
        Employee employeeEntity = Employee.builder()
                .firstName(firstName)
                .lastName("Doe")
                .email("john.doe@example.com")
                .phoneNumber("1234567890")
                .role("Developer")
                .build();

        when(employeeRepository.getEmployeeByFirstName(eq(firstName))).thenReturn(employeeEntity);

        Optional<EmployeeDTO> result = employeeService.getEmployeeByFirstName(firstName);

        assertEquals(firstName, result.get().getFirstName());
        assertEquals(employeeEntity.getLastName(), result.get().getLastName());
        assertEquals(employeeEntity.getEmail(), result.get().getEmail());
        assertEquals(employeeEntity.getPhoneNumber(), result.get().getPhoneNumber());
        assertEquals(employeeEntity.getRole(), result.get().getRole());

        verify(employeeRepository, times(1)).getEmployeeByFirstName(eq(firstName));
    }

    // Additional test methods...

    @Test
    void getAllEmployees() {
        List<Employee> employeeEntities = Arrays.asList(
                Employee.builder()
                        .firstName("John")
                        .lastName("Doe")
                        .phoneNumber("1234567890")
                        .email("john.doe@example.com")
                        .role("Developer")
                        .build(),

                Employee.builder()
                        .firstName("Jane")
                        .lastName("Smith")
                        .phoneNumber("9876543210")
                        .email("jane.smith@example.com")
                        .role("Manager")
                        .build()
        );

        when(employeeRepository.findAll()).thenReturn(employeeEntities);

        List<EmployeeDTO> result = employeeService.getAllEmployees();

        assertEquals(employeeEntities.size(), result.size());
        assertEquals(employeeEntities.get(0).getFirstName(), result.get(0).getFirstName());
        assertEquals(employeeEntities.get(1).getLastName(), result.get(1).getLastName());

        verify(employeeRepository, times(1)).findAll();
    }
}
