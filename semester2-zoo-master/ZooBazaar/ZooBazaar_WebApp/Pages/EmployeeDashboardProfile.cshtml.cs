using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.DTO;
using BLL.Interfaces.Services;
using System.Security.Claims;
using BLL.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Reflection;

namespace WebApp.Pages
{
    [Authorize]
    public class EmployeeDashboardProfileModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        [BindProperty]
        public UserProfileDTO UserProfile { get; set; }

        public EmployeeDashboardProfileModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            UserProfile = new UserProfileDTO();
            
        }
        public void OnGet()
        {
            UserProfile = new UserProfileDTO
            {
                FirstName = User.FindFirstValue("GivenName"),
                LastName = User.FindFirstValue("Surname"),
                PersonalEmail = User.FindFirstValue("Email"),
                WorkEmail = User.FindFirstValue("WorkEmail"),
                PostalCode = User.FindFirstValue("PostalCode"),
                SSN = User.FindFirstValue("SSN"),
                IBAN = User.FindFirstValue("BankAccount"),
                BirthDate = User.FindFirstValue("BirthDate"),
                Gender = User.FindFirstValue("Gender")
            };
        }

        public IActionResult OnPostPost()
        {
            if(ModelState.IsValid)
            {
                Guid id = Guid.Parse(User.FindFirstValue("NameIdentifier"));
                string firstName = UserProfile.FirstName;
                string lastName = UserProfile.LastName;
                string personalEmail = UserProfile.PersonalEmail;
                string postalCode = UserProfile.PostalCode.Replace(" ", string.Empty);
                Gender gender = (Gender)Enum.Parse(typeof(Gender), UserProfile.Gender, true);

                Employee updatedEmployee = new Employee(id, firstName, lastName, personalEmail, postalCode, gender);

                Employee employee = _employeeService.UpdateEmployee(updatedEmployee);

                HttpContext.SignOutAsync();

                List<Claim> claims = new List<Claim>
                    {
                        new Claim("NameIdentifier", employee.Id.ToString()),
                        new Claim("GivenName", employee.FirstName),
                        new Claim("Surname", employee.LastName),
                        new Claim("Email", employee.PersonalEmail),
                        new Claim("WorkEmail", employee.WorkEmail),
                        new Claim("PostalCode", employee.Address),
                        new Claim("SSN", employee.Ssn),
                        new Claim("BankAccount", employee.BankAccount),
                        new Claim("BirthDate", employee.BirthDate.ToString()),
                        new Claim("Gender", employee.Gender.ToString()),
                        new Claim("Role", employee.Role.ToString()),
                        new Claim("PfpURL", employee.PhotoURL)
                    };
                ClaimsIdentity cid = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(cid));

                return Redirect(Statics.Routes.EMPLOYEEDASHBOARDPROFILE);
            }
            return Page();
        }
    }
}
