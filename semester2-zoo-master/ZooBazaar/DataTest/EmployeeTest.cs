using BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTask = BLL.Models.Task; // Renamed the Task class to EmployeeTask


namespace DataTest
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void CreateNewEmployee()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";
            string personalEmail = "john.doe@example.com";
            string workEmail = "jdoe@example.com";
            string password = "password123";
            string address = "123 Main Street";
            string ssn = "123-45-6789";
            string bankAccount = "0123456789";
            string photoURL = "https://example.com/photo.jpg";
            DateOnly birthDate = new DateOnly(1990, 1, 1);
            Gender gender = Gender.MALE;
            Role role = Role.PLANNER;
            decimal hourlyRate = 20.5m;

            // Act
            Employee employee = new Employee(firstName, lastName, personalEmail, workEmail, password, address, ssn,
                bankAccount, photoURL, birthDate, gender, role, hourlyRate);

            // Assert
            Assert.IsNotNull(employee);
            Assert.AreNotEqual(Guid.Empty, employee.Id);
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(personalEmail, employee.PersonalEmail);
            Assert.AreEqual(workEmail, employee.WorkEmail);
            Assert.AreEqual(password, employee.Password);
            Assert.AreEqual(address, employee.Address);
            Assert.AreEqual(ssn, employee.Ssn);
            Assert.AreEqual(bankAccount, employee.BankAccount);
            Assert.AreEqual(photoURL, employee.PhotoURL);
            Assert.AreEqual(birthDate, employee.BirthDate);
            Assert.AreEqual(gender, employee.Gender);
            Assert.AreEqual(role, employee.Role);
            Assert.AreEqual(hourlyRate, employee.HourlyRate);

            Assert.IsNotNull(employee.Notes);
            Assert.AreEqual(0, employee.Notes.Count);

            Assert.IsNotNull(employee.Tasks);
            Assert.AreEqual(0, employee.Tasks.Count);

        }

        [TestMethod]
        public void RetrieveEmployeeFromDatabase()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            string firstName = "Jane";
            string lastName = "Smith";
            string personalEmail = "jane.smith@example.com";
            string workEmail = "jsmith@example.com";
            string password = "password456";
            string address = "456 Oak Street";
            string ssn = "987-65-4321";
            string bankAccount = "9876543210";
            int photoURL = 1;
            DateOnly birthDate = new DateOnly(1985, 5, 10);
            Gender gender = Gender.FEMALE;
            Role role = Role.MANAGER;
            decimal hourlyRate = 25.75m;

            // Act
            Employee employee = new Employee(id, firstName, lastName, personalEmail, workEmail, password, address, ssn,
                bankAccount, birthDate, gender, role, hourlyRate, photoURL);

            // Assert
            Assert.IsNotNull(employee);
            Assert.AreEqual(id, employee.Id);
            Assert.AreEqual(firstName, employee.FirstName);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(personalEmail, employee.PersonalEmail);
            Assert.AreEqual(workEmail, employee.WorkEmail);
            Assert.AreEqual(password, employee.Password);
            Assert.AreEqual(address, employee.Address);
            Assert.AreEqual(ssn, employee.Ssn);
            Assert.AreEqual(bankAccount, employee.BankAccount);
            Assert.AreEqual(photoURL, employee.PhotoURL);
            Assert.AreEqual(birthDate, employee.BirthDate);
            Assert.AreEqual(gender, employee.Gender);
            Assert.AreEqual(role, employee.Role);
            Assert.AreEqual(hourlyRate, employee.HourlyRate);

            Assert.IsNotNull(employee.Notes);
            Assert.AreEqual(0, employee.Notes.Count);

            Assert.IsNull(employee.Tasks);
            Assert.AreEqual(null, employee.Tasks?.Count);

        }

        [TestMethod]
        public void AddTask_AddsTaskToList()
        {
            // Arrange
            Employee employee = new Employee("John", "Doe", "john.doe@example.com", "jdoe@example.com", "password123",
                "123 Main Street", "123-45-6789", "0123456789", "https://example.com/photo.jpg",
                new DateOnly(1990, 1, 1), Gender.MALE, Role.Employee, 20.5m);

            Guid GuidID = Guid.NewGuid();
            int shiftid = 2;

            BLL.Models.Task task = new BLL.Models.Task(GuidID, "Task 1", "Description 1", shiftid, new List<Species>(), new DateOnly(1990, 1, 1), new List<Employee>());

            // Act
            employee.AddTask(task);

            // Assert
            Assert.IsNotNull(employee.Tasks);
            Assert.AreEqual(1, employee.Tasks.Count);
            Assert.AreEqual(task, employee.Tasks[0]);

            // need ?
            Assert.AreEqual(shiftid, employee.Tasks);
            Assert.IsTrue(employee.Tasks.Contains(task));
            Assert.AreEqual(employee, task.AssignedEmployees);
        }

        [TestMethod]
        public void AddNote_AddsNoteToList()
        {
            // Arrange
            Employee employee = new Employee("Jane", "Smith", "jane.smith@example.com", "jsmith@example.com", "password456",
                "456 Oak Street", "987-65-4321", "9876543210", "https://example.com/photo2.jpg",
                new DateOnly(1985, 5, 10), Gender.FEMALE, Role.MANAGER, 25.75m);

            Note note = new Note("text", employee, new List<Species>());

            // Act
            employee.AddNote(note);

            // Assert
            Assert.IsNotNull(employee.Notes);
            Assert.AreEqual(1, employee.Notes.Count);
            Assert.AreEqual(note, employee.Notes[0]);

            Assert.IsTrue(employee.Notes.Contains(note));
            Assert.AreEqual(employee, note.Employee);
        }


    }
}