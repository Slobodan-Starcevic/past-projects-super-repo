package com.indigo.ars.unit.Entity;

import com.indigo.ars.Entity.Employee;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class EmployeeTest {

    @Test
    public void testEmployeeBuilder() {
        Employee employee = Employee.builder()
                .id(1)
                .firstName("John")
                .lastName("Doe")
                .phoneNumber("123-456-7890")
                .email("john.doe@example.com")
                .role("Developer")
                .build();

        assertNotNull(employee);
        assertEquals(1, employee.getId());
        assertEquals("John", employee.getFirstName());
        assertEquals("Doe", employee.getLastName());
        assertEquals("123-456-7890", employee.getPhoneNumber());
        assertEquals("john.doe@example.com", employee.getEmail());
        assertEquals("Developer", employee.getRole());
    }

    @Test
    public void testEmployeeEqualsAndHashCode() {
        Employee employee1 = Employee.builder().id(1).build();
        Employee employee2 = Employee.builder().id(1).build();
        Employee employee3 = Employee.builder().id(2).build();

        assertEquals(employee1, employee2);
        assertNotEquals(employee1, employee3);
        assertEquals(employee1.hashCode(), employee2.hashCode());
        assertNotEquals(employee1.hashCode(), employee3.hashCode());
    }

    @Test
    public void testEmployeeToString() {
        Employee employee = Employee.builder()
                .id(1)
                .firstName("John")
                .lastName("Doe")
                .phoneNumber("123-456-7890")
                .email("john.doe@example.com")
                .role("Developer")
                .build();

        String expectedToString = "Employee(id=1, firstName=John, middleName=null, lastName=Doe, phoneNumber=123-456-7890, email=john.doe@example.com, role=Developer)";
        assertEquals(expectedToString, employee.toString());
    }

    @Test
    public void testGettersAndSetters() {
        Employee employee = new Employee();

        // If the getters and setters work, this means @Data is doing it's job
        employee.setFirstName("John");
        assertEquals("John", employee.getFirstName());

        // Test setter and getter for lastName
        employee.setLastName("Doe");
        assertEquals("Doe", employee.getLastName());

        // Test setter and getter for phoneNumber
        employee.setPhoneNumber("123-456-7890");
        assertEquals("123-456-7890", employee.getPhoneNumber());

        // Test setter and getter for email
        employee.setEmail("john.doe@example.com");
        assertEquals("john.doe@example.com", employee.getEmail());

        // Test setter and getter for role
        employee.setRole("Developer");
        assertEquals("Developer", employee.getRole());
    }
}
