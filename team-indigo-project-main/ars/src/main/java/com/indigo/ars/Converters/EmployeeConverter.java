package com.indigo.ars.Converters;

import com.indigo.ars.DTO.EmployeeDTO;
import com.indigo.ars.Entity.Employee;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

@Service
@AllArgsConstructor
public class EmployeeConverter {

    public static EmployeeDTO EmployeeConverterEntityToDTO(Employee employeeEntity) {
        if (employeeEntity == null) {
            return null;
        }

        return EmployeeDTO.builder()
                .firstName(employeeEntity.getFirstName())
                .lastName(employeeEntity.getLastName())
                .email(employeeEntity.getEmail())
                .phoneNumber(employeeEntity.getPhoneNumber())
                .role(employeeEntity.getRole())
                .build();
    }

    public static Employee EmployeeConverterDTOtoEntity(EmployeeDTO employeeDTO) {
        if (employeeDTO == null) {
            return null;
        }

        Employee employeeEntity = new Employee();
        employeeEntity.setFirstName(employeeDTO.getFirstName());
        employeeEntity.setLastName(employeeDTO.getLastName());
        employeeEntity.setEmail(employeeDTO.getEmail());
        //  employeeEntity.setPassword(employeeDTO.getPassword());
        employeeEntity.setPhoneNumber(employeeDTO.getPhoneNumber());
        employeeEntity.setRole(employeeDTO.getRole());

        return employeeEntity;
    }

    public static String EmployeeConverterToName(Employee employee) {
        if (employee == null) {
            return null;
        }
        return employee.getFirstName() + " " + employee.getLastName() ;
    }
}
