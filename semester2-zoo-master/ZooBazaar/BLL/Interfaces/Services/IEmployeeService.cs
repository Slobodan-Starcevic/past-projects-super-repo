using BLL.Interfaces.Repositories;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services
{
    public interface IEmployeeService
    {
        void Create(string firstName, string lastName, string personalEmail, string workEmail, string password,
            string address, string ssn, string bankAccount, string photoURL, DateOnly birthDate, Gender gender, Role role, decimal hourlyRate);

        void EditAdress(Guid id, string text);

        void EditEmail(Guid id, string new_personal_email);

        void EditLname(Guid id, string text);

        void EditPassword(Guid id, string new_password);

        void EditPhotoUrl(Guid id, string photo_url);

        void EditRole(Guid id, Role role);

         void EditWorkEmail(Guid id, string text);

        List<Employee> GetAllEmployees();

        Employee GetEmployeeWorkMail(string company_email);

        Employee GetEmployeeID(Guid id);

        //bool Login(string company_email, string password);

        void Remove(Guid id);

        void EdditHourlyRate(Guid id, decimal value);

        void EdditAdress(Guid id, string text);

        void EdditSNN(Guid id, string new_SNN);

        void EditFname(Guid id, string new_Fname);

        void EditGender(Guid id, Gender gender);

        void EditBankAccount(Guid id, string new_bank_account);

        void EditHourlyRate(Guid id, decimal hourlyRate);

        void EditBirthday(Guid id, DateTime birthday);

        void Editadress(Guid id, string Adress);

        Employee AuthenticateLogin(string email, string password);
        Employee GetEmployeeByWorkEmail(string emailToFind);
        Employee UpdateEmployee(Employee employee);
    }
}
