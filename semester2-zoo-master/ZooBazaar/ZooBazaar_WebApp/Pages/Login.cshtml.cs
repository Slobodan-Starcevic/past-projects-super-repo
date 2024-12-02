using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using BLL.Models;
using WebApp.DTO;
using BLL.Interfaces.Services;
using BLL.Exceptions;

namespace WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        [BindProperty]
        public UserAuthenticateDTO UserLogin { get; set; }

        public LoginModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            UserLogin = new UserAuthenticateDTO();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Employee employee = _employeeService.AuthenticateLogin(UserLogin.Username, UserLogin.Password);

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

                    return Redirect("/Index");
                }
                catch (UserNotFoundException ex)
                {
                    var errorMessage = ex.Message;
                    TempData["ErrorMessage"] = errorMessage;
                    return Page();
                }
            }
            return Page();
        }
    }
}
