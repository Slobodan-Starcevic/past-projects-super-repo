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
	public class AccountDTO
	{
		private static AccountDTO instance;
		private static readonly object _lock = new object();
	
		private static Employee? user = null;
		private EmployeeService employeeService;
		public AccountDTO() 
		{
			IEmployeeRepository employeeRepository = new EmployeeRepository();
			employeeService = new EmployeeService(employeeRepository);
		}

		public bool LogInAttempt(string email, string password)
		{
			bool login = employeeService.Login(email, password);
			if(login )
			{
				user = employeeService.GetEmployeeWorkMail(email);
			}
			return login;
		}

		internal void EdditSSN(Guid id, string sSN)
		{
			employeeService.EdditSNN(id, sSN);
		}

		internal void EdditFname(Guid id, string firstName)
		{
			employeeService.EditFname(id, firstName);
		}

		internal void EdditLname(Guid id, string lastName)
		{
			employeeService.EditLname(id, lastName);
		}

		internal void EdditGender(Guid id, Gender gender)
		{			
			employeeService.EditGender(id, gender);
		}

		internal void EdditBankAccount(Guid id, string banAccount)
		{
			employeeService.EditBankAccount(id, banAccount);
		}

		internal void EdditRole(Guid id, Role role)
		{
			employeeService.EditRole(id, role);
		}

		internal void EdditPhotoUrl(Guid id, string photoUrl)
		{
			employeeService.EditPhotoUrl(id,photoUrl);
		}

		internal void GetAccount(Guid id)
		{
			user = employeeService.GetEmployeeID(id);
		}

		internal void EdditBirthDate(Guid id, DateTime date)
		{
			employeeService.EditBirthday(id,date);
		}

		internal void EdditWorkEmail(Guid id, string email)
		{
			employeeService.EditWorkEmail(id,email);
		}

		internal void EdditAdress(Guid id, string adress)
		{
			employeeService.EditAdress(id,adress);
		}

		internal void LogOut()
		{
			user = null;
		}

		internal void SelectEmployee(Employee employee)
		{
			user = employee;
		}

		internal void EdditPersonalEmail(string personalEmail, Guid id)
		{
			throw new NotImplementedException();
		}

		public Employee User
		{
			get {	
				{
					return user;
				}	
			}
		}
	}
}
