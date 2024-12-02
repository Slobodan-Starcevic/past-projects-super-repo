package com.indigo.ars.unit.Converter;

import com.indigo.ars.Converters.EmployeeConverter;
import com.indigo.ars.DTO.EmployeeDTO;
import com.indigo.ars.Entity.Employee;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class EmployeeConverterTest {

    @Test
    void employeeConverterEntityToDTO() {
        Employee employeeEntity = Employee.builder()
                .firstName("John")
                .lastName("Doe")
                .email("john.doe@example.com")
                .phoneNumber("1234567890")
                .role("Developer")
                .build();

        EmployeeDTO result = EmployeeConverter.EmployeeConverterEntityToDTO(employeeEntity);

        assertEquals(employeeEntity.getFirstName(), result.getFirstName());
        assertEquals(employeeEntity.getLastName(), result.getLastName());
        assertEquals(employeeEntity.getEmail(), result.getEmail());
        assertEquals(employeeEntity.getPhoneNumber(), result.getPhoneNumber());
        assertEquals(employeeEntity.getRole(), result.getRole());
    }

    @Test
    void employeeConverterDTOToEntity() {
        EmployeeDTO employeeDTO = EmployeeDTO.builder()
                .firstName("John")
                .lastName("Doe")
                .email("john.doe@example.com")
                .phoneNumber("1234567890")
                .role("Developer")
                .build();

        Employee result = EmployeeConverter.EmployeeConverterDTOtoEntity(employeeDTO);

        assertEquals(employeeDTO.getFirstName(), result.getFirstName());
        assertEquals(employeeDTO.getLastName(), result.getLastName());
        assertEquals(employeeDTO.getEmail(), result.getEmail());
        assertEquals(employeeDTO.getPhoneNumber(), result.getPhoneNumber());
        assertEquals(employeeDTO.getRole(), result.getRole());
    }
}
