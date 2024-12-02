using BLL.Interfaces.Repositories;
using BLL.Models;
using BLL.Services;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCore.DTO
{
	public class EmployeesDTO
	{
		private readonly List<Employee> employees;
		private EmployeeService employeeService;
		private Employee selectedEmployee;

		private string firstName;
		private string lastName;
		private string sSN;
		private string photoURL;
		private string adress;
		private DateOnly birthDate;
		private Gender gender;
		private Role role;
		private decimal hourlyRate;
		private string personalEmail;
		private string workEmail;
		private string bankAccount;
		private string password;


		public EmployeesDTO()
		{
			this.employees = new List<Employee>();
			IEmployeeRepository emprepo = new EmployeeRepository();
			employeeService = new EmployeeService(emprepo);
			GetEmployeeList();
		}

		public List<Employee> Employees { get { return employees; } }
		

		public void GetEmployeeList()
		{
			
			employees.Clear();
			employees.AddRange(employeeService.GetAllEmployees());
		}

		internal void GetEmployee(Guid id)
		{
			selectedEmployee = employeeService.GetEmployeeID(id);
		}

		internal void EdditFname(Guid id, string text)
		{
			employeeService.EditFname(id, text);
		}

		internal void AddEmployeeFname(string text)
		{
			this.firstName= text;
		}

		internal void EdditWorkEmail(Guid id, string text)
		{
			employeeService.EditWorkEmail(id, text);
		}

		internal void AddEmployeeWorkmail(string text)
		{
			this.workEmail = text;
		}

		internal void EdditLastname(Guid id, string text)
		{
			employeeService.EditLname(id, text);
		}

		internal void AddEmployeeLName(string text)
		{
			this.lastName= text;
		}

		internal void EdditBirthdate(Guid id, DateTime date)
		{
			employeeService.EditBirthday(id, date);
		}

		internal void AddEmployeeBirthdate(DateTime date)
		{
			DateOnly dateOnly = DateOnly.FromDateTime(date);
			this.birthDate = dateOnly;
		}

		internal void EdditGender(Guid id, string text)
		{
			Gender gender = (Gender)Enum.Parse(typeof(Gender), text);
			employeeService.EditGender(id,gender);
		}

		internal void AddEmployeeGender(string text)
		{
			Gender gender = (Gender)Enum.Parse(typeof(Gender), text);
			this.gender = gender;
		}

		internal void EdditPersonalEmail(Guid id, string text)
		{
			employeeService.EditEmail(id, text);
		}

		internal void AddEmployeePEmail(string text)
		{
			this.personalEmail = text;
		}

		internal void EdditBanccount(Guid id, string text)
		{
			employeeService.EditBankAccount(id, text);
		}

		internal void AddEmployeeBankaccount(string text)
		{
			this.bankAccount = text;
		}

		internal void EdditPhotoUrl(Guid id, string text)
		{
			employeeService.EditPhotoUrl(id, text);
		}

		internal void AddEmployeePhotoUrl(string text)
		{
			this.photoURL = text;
		}

		internal void EdditSSN(Guid id, string text)
		{
			employeeService.EdditSNN(id,text);
		}

		internal void AddEmployeeSSN(string text)
		{
			this.sSN = text;
		}

		internal void EdditRole(Guid id, string text)
		{
			Role role = (Role)Enum.Parse(typeof(Role), text);
			employeeService.EditRole(id, role);
		}

		internal void AddEmployeeRole(string text)
		{
			Role role = (Role)Enum.Parse(typeof(Role), text);
			this.role = role;
		}

		internal void EdditPassword(Guid id, string text)
		{
			employeeService.EditPassword(id, text);
		}

		internal void AddEmployeePassword(string text)
		{
			this.password = text;
		}

		internal void EdditHourlyRate(Guid id, decimal value)
		{
			employeeService.EditHourlyRate(id, value);
		}

		internal void AddEmployeeHourlyRate(decimal value)
		{
			this.hourlyRate = value;
		}

		internal void AddNewEmployee()
		{
			if(this.photoURL == null)
			{
				photoURL = "empty";
			}
			employeeService.Create(firstName,lastName,personalEmail,workEmail,password,adress,sSN,bankAccount,photoURL,birthDate,gender,role,hourlyRate);
		}

		internal void EdditAdress(Guid id, string text)
		{
			employeeService.Editadress(id, text);
		}

		internal void AddEmployeeAdress(string text)
		{
			this.adress = text;
		}

		internal void RemoveSelectedEmployee()
		{
			employeeService.Remove(selectedEmployee.Id);
			this.selectedEmployee = null;
		}

		internal void SelectEmployee(Employee emp)
		{
			selectedEmployee = emp;
		}

		public Employee SelectedEmployee
		{
			get { return selectedEmployee; }
		}

	}
}
