using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Create(string firstName, string lastName, string personalEmail, string workEmail, string password,
            string address, string ssn, string bankAccount, string photoURL, DateOnly birthDate, Gender gender, Role role, decimal hourlyRate)
        {
            Employee employee = new Employee(firstName, lastName, personalEmail, workEmail, password, address, ssn, bankAccount, photoURL, birthDate, gender, role, hourlyRate);
        
            _employeeRepository.Create(employee);
        }	

	
		
		public void EditAdress(Guid id, string text)
		{
			_employeeRepository.EdditAdress(id,text);
		}

		public void EditEmail(Guid id, string new_personal_email)
        {
            _employeeRepository.EditEmail(id, new_personal_email);
        }

		public void EditLname(Guid id, string text)
		{
			_employeeRepository.EdditLastname(id,text);
		}

		public void EditPassword(Guid id, string new_password)
        {
            _employeeRepository.EditPassword(id, new_password);
        }

		public void EditPhotoUrl(Guid id, string photo_url)
		{
			_employeeRepository.EdditPhotoUrl(id, photo_url);
		}

		public void EditRole(Guid id, Role role)
        {
            _employeeRepository.EditRole(id, role);
        }

		public void EditWorkEmail(Guid id, string text)
		{
			_employeeRepository.EdditWorkEmail(id,text);
		}

		public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployeeWorkMail(string company_email)
        {
            return _employeeRepository.GetEmployeeWorkMail(company_email);
        }

        public Employee GetEmployeeID(Guid id)
        {
            return _employeeRepository.GetEmployeeID(id);
        }

        /*public bool Login(string company_email, string password)
        {
            Employee employee = GetEmployeeWorkMail(company_email);

            if (employee.Password != SECURITY.GeneratePassword(password, employee.Salt))
            {
                return false;
            }

            return true;
        }*/

        public void Remove(Guid id)
        {
            _employeeRepository.RemoveEmployee(id);
        }

		public void EdditHourlyRate(Guid id, decimal value)
		{
			_employeeRepository.EdditHourlyRate(id, value);
		}

		public void EdditAdress(Guid id, string text)
		{
			_employeeRepository.EdditAdress(id, text);
		}

		public void EdditSNN(Guid id, string new_SNN)
		{
			_employeeRepository.EdditSSn(id, new_SNN);
		}

		public void EditFname(Guid id, string new_Fname)
		{
			_employeeRepository.EditFname(id, new_Fname);
		}

		public void EditGender(Guid id, Gender gender)
		{
			_employeeRepository.EdditGender(id, gender);
		}

		public void EditBankAccount(Guid id, string new_bank_account)
		{
			_employeeRepository.EdditEmployeeBankAccount(id, new_bank_account);
		}

		public void EditHourlyRate(Guid id, decimal hourlyRate)
		{
			_employeeRepository.EdditHourlyRate(id,hourlyRate);
		}

		public void EditBirthday(Guid id, DateTime birthday)
		{
			_employeeRepository.EdditBirthDate(id, birthday);
		}

		public void Editadress(Guid id, string Adress)
		{
			_employeeRepository.EdditAdress(id, Adress);
		}

        public bool Login(string email, string password)
        {
            Employee employee = _employeeRepository.GetEmployeeWorkMail(email);

			if(employee.Password == password)
			{
				return true;
			}
            else
            {
                return false;
            }
        }

        public Employee AuthenticateLogin(string email, string password)
		{
			return _employeeRepository.AuthenticateLogin(email, password);
		}
        public Employee GetEmployeeByWorkEmail(string emailToFind)
		{
			return _employeeRepository.GetEmployeeByWorkEmail(emailToFind);
		}

        public Employee UpdateEmployee(Employee employee)
        {
			return _employeeRepository.UpdateEmployee(employee);
        }
    }
}
