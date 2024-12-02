package com.indigo.ars.Repository;

import com.indigo.ars.DTO.EmployeeDTO;
import com.indigo.ars.Entity.Employee;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.UUID;

@Repository
public interface EmployeeRepository extends CrudRepository<Employee, Integer> {
    Employee getEmployeeByFirstName(String firstName);
    Employee getEmployeeByLastName(String lastName);
    Employee getEmployeeByFirstNameAndLastName(String firstName, String lastName);
    Employee getEmployeeByEmail(String email);

    //admin dash only
    Employee getEmployeeByPhoneNumber(String phoneNumber);

}
