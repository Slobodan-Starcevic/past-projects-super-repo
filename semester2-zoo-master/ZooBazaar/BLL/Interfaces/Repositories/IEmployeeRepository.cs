using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        Employee GetEmployeeWorkMail(string company_email);
        Employee GetEmployeeID(Guid id);
        List<Employee> GetAllEmployees();
        void EditPassword(Guid id, string password);
        void EditEmail(Guid id, string new_personal_email);
        void EditRole(Guid id, Role role);

        void RemoveEmployee(Guid id);
		void EdditEmployeeBankAccount(Guid id, string text);
		void EdditBirthDate(Guid id, DateTime dateOnly);
		void EditFname(Guid id, string text);
		void EdditGender(Guid id, Gender gender);
		void EdditPhotoUrl(Guid id, string text);
		void EdditSSn(Guid id, string sSN);
		void EdditAdress(Guid id, string text);
		void EdditLastname(Guid id, string text);
		void EdditWorkEmail(Guid id, string text);
		void EdditHourlyRate(Guid id, decimal value);

        Employee AuthenticateLogin(string email, string password);
        Employee GetEmployeeByWorkEmail(string emailToFind);
        Employee UpdateEmployee(Employee employee);


    }
}
