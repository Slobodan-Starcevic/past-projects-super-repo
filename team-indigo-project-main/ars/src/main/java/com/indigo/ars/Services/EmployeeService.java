package com.indigo.ars.Services;

import com.indigo.ars.Converters.EmployeeConverter;
import com.indigo.ars.DTO.EmployeeDTO;
import com.indigo.ars.Entity.Employee;
import com.indigo.ars.Repository.EmployeeRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.StreamSupport;

@Service
public class EmployeeService {

    private final EmployeeRepository employeeRepository;

    public EmployeeService(EmployeeRepository employeeRepository) {
        this.employeeRepository = employeeRepository;
    }

    public EmployeeDTO createEmployee(EmployeeDTO employeeDTO) {
        Employee employee = EmployeeConverter.EmployeeConverterDTOtoEntity(employeeDTO);
        Employee savedEmployee = employeeRepository.save(employee);
        return EmployeeConverter.EmployeeConverterEntityToDTO(savedEmployee);
    }

    public Optional<EmployeeDTO> getEmployeeByFirstName(String firstName) {
        Employee employee = employeeRepository.getEmployeeByFirstName(firstName);
        return Optional.ofNullable(EmployeeConverter.EmployeeConverterEntityToDTO(employee));
    }

    public Optional<EmployeeDTO> getEmployeeByLastName(String lastName) {
        Employee employee = employeeRepository.getEmployeeByLastName(lastName);
        return Optional.ofNullable(EmployeeConverter.EmployeeConverterEntityToDTO(employee));
    }

    public Optional<EmployeeDTO> getEmployeeByFirstNameAndLastName(String firstName, String lastName) {
        Employee employee = employeeRepository.getEmployeeByFirstNameAndLastName(firstName, lastName);
        return Optional.ofNullable(EmployeeConverter.EmployeeConverterEntityToDTO(employee));
    }

    public Optional<EmployeeDTO> getEmployeeByEmail(String email) {
        Employee employee = employeeRepository.getEmployeeByEmail(email);
        return Optional.ofNullable(EmployeeConverter.EmployeeConverterEntityToDTO(employee));
    }

    //admin dash ONLY!
    public Optional<EmployeeDTO> getEmployeeByPhoneNumber(String phoneNumber) {
        Employee employee = employeeRepository.getEmployeeByPhoneNumber(phoneNumber);
        return Optional.ofNullable(EmployeeConverter.EmployeeConverterEntityToDTO(employee));
    }

    public List<EmployeeDTO> getAllEmployees() {
        Iterable<Employee> employees = employeeRepository.findAll();
        return StreamSupport.stream(employees.spliterator(), false)
                .map(EmployeeConverter::EmployeeConverterEntityToDTO)
                .collect(Collectors.toList());
    }

}
