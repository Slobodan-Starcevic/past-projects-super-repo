using BLL.Interfaces.Services;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using WebApp.DTO;
using Task = BLL.Models.Task;

namespace WebApp.Pages
{
    [Authorize]
    public class EmployeeDashboardScheduleModel : PageModel
    {
        private readonly ITaskService taskService;
        private readonly IEmployeeService employeeService;

        public List<TaskDTO> EmployeeTasks { get; private set; }
        public List<TaskDTO> SelectedTasks { get; private set; }

        public EmployeeDashboardScheduleModel(ITaskService _taskService, IEmployeeService _employeeService)
        {
            taskService = _taskService;
            employeeService = _employeeService;
            EmployeeTasks = new List<TaskDTO>();
            SelectedTasks = new List<TaskDTO>();
        }

        public IActionResult OnGet()
        {
            var identity = (ClaimsIdentity)User.Identity;
            string WorkEmail = identity.FindFirst("WorkEmail")?.Value;
            // Get the employee object using the login token
            Employee currentEmployee = employeeService.GetEmployeeWorkMail(WorkEmail);

            // Retrieve the tasks for the current month for the specific employee
            List<Task> allTasks = taskService.GetAllTasks();

            foreach (Task task in allTasks)
            {
                foreach (Employee employee in task.AssignedEmployees)
                {
                    if (employee.WorkEmail != currentEmployee.WorkEmail)
                    {
                        continue;
                    }

                    TaskDTO taskDTO = new TaskDTO(task);

                    EmployeeTasks.Add(taskDTO);
                }
            }

            return Page();
        }

        public IActionResult OnGetShowTasks(int day, int month, int year)
        {
            var identity = (ClaimsIdentity)User.Identity;
            string WorkEmail = identity.FindFirst("WorkEmail")?.Value;
            // Get the employee object using the login token
            Employee currentEmployee = employeeService.GetEmployeeWorkMail(WorkEmail);

            // Retrieve the tasks for the current month for the specific employee
            List<Task> allTasks = taskService.GetAllTasks();


            foreach (Task task in allTasks)
            {
                foreach (Employee employee in task.AssignedEmployees)
                {
                    if (employee.WorkEmail != currentEmployee.WorkEmail)
                        continue;

                    TaskDTO taskDTO = new TaskDTO(task);

                    EmployeeTasks.Add(taskDTO);
                }
            }

            DateOnly selectedDate = new DateOnly(year, month, day); 

            foreach (TaskDTO task in EmployeeTasks)
            {
                if (task.Date == selectedDate)
                {
                    SelectedTasks.Add(task);
                }
            }


            if (SelectedTasks.Count > 0)
            {
                SelectedTasks = SelectedTasks.OrderBy(x => x.ShiftId).ToList();
                ViewData["SelectedTasks"] = SelectedTasks;
            }
                

            return Page();
        }

        public IActionResult OnPostDifferentMonth(int month, int year)
        {
            var identity = (ClaimsIdentity)User.Identity;
            string WorkEmail = identity.FindFirst("WorkEmail")?.Value;
            // Get the employee object using the login token
            Employee currentEmployee = employeeService.GetEmployeeWorkMail(WorkEmail);

            // Retrieve the tasks for the current month for the specific employee
            List<Task> allTasks = taskService.GetAllTasks();

            foreach (Task task in allTasks)
            {
                foreach (Employee employee in task.AssignedEmployees)
                {
                    if (employee.WorkEmail != currentEmployee.WorkEmail)
                        continue;

                    TaskDTO taskDTO = new TaskDTO(task);

                    EmployeeTasks.Add(taskDTO);
                }
            }

            TempData["Month"] = month;
            TempData["Year"] = year;

            return Page();
        }
    }
}
