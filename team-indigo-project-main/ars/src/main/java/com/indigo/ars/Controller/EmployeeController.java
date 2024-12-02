package com.indigo.ars.Controller;

import com.indigo.ars.DTO.EmployeeDTO;
import com.indigo.ars.Repository.EmployeeRepository;
import com.indigo.ars.Services.EmployeeService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping("/employee")
public class EmployeeController {
    public final EmployeeService employeeService;

    public EmployeeController(EmployeeService employeeService) {
        this.employeeService = employeeService;
    }

    @GetMapping
    public ResponseEntity<Iterable<EmployeeDTO>> getAllEmployees() {
        return ResponseEntity.ok(employeeService.getAllEmployees());
    }

    @GetMapping("/{firstName}")
    public ResponseEntity<Optional<EmployeeDTO>> getEmployeeByFirstName(@RequestBody String firstName) {
        return ResponseEntity.ok(employeeService.getEmployeeByFirstName(firstName));
    }

    @GetMapping("/{lastName}")
    public ResponseEntity<Optional<EmployeeDTO>> getEmployeeByLastName(@RequestBody String lastName) {
        return ResponseEntity.ok(employeeService.getEmployeeByLastName(lastName));
    }

    @GetMapping("/{firstName}/{lastName}")
    public ResponseEntity<Optional<EmployeeDTO>> getEmployeeByFirstNameAndLastName(@RequestBody String firstName, @RequestBody String lastName) {
        return ResponseEntity.ok(employeeService.getEmployeeByFirstNameAndLastName(firstName, lastName));
    }

    @GetMapping("/{email}")
    public ResponseEntity<Optional<EmployeeDTO>> getEmployeeByEmail(@RequestBody String email) {
        return ResponseEntity.ok(employeeService.getEmployeeByEmail(email));
    }

    //admin dash only
    @GetMapping("/{phoneNumber}")
    public ResponseEntity<Optional<EmployeeDTO>> getEmployeeByPhoneNumber(@RequestBody String phoneNumber) {
        return ResponseEntity.ok(employeeService.getEmployeeByPhoneNumber(phoneNumber));
    }

    @PostMapping
    public ResponseEntity<EmployeeDTO> addEmployee(@RequestBody EmployeeDTO employee) {
        return ResponseEntity.ok(employeeService.createEmployee(employee));
    }
}
