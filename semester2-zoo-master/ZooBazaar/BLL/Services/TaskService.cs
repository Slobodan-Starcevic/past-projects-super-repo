using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = BLL.Models.Task;

namespace BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateWithEmployee(Task task)
        {
           
           _taskRepository.Create(task);
        }

        public void CreateWithoutEmployee(Task task)
        {
         
            _taskRepository.Create(task);
        }

        public void Delete(Guid id)
        {
            _taskRepository.Delete(id);
        }

        public void Edit(Guid id, string new_description)
        {
            _taskRepository.Edit(id, new_description);
        }

        public void Edit(Guid id, List<Species> species)
        {
            _taskRepository.Edit(id, species);
        }

        public void Edit(Guid id, List<Employee> employees)
        {
            _taskRepository.Edit(id, employees);
        }

        public void Edit(Guid id, int shift_id)
        {
            _taskRepository.Edit(id, shift_id);
        }

        public List<Task> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public Task GetTask(Guid id)
        {
            return _taskRepository.GetTask(id);
        }
        public List<Task> GetEmployeesTask(Guid id)
        {
            return _taskRepository.GetEmployeeTasks(id);
        }
        public List<TaskOptions> GetTaskOptions()
        {
            return _taskRepository.GetTaskOptions();
        }
        public void CreateTaskOption(TaskOptions taskOptions)
        {
            _taskRepository.CreateTaskOption(taskOptions.Id,taskOptions.Title,taskOptions.Description);
        }
        public void DeleteTaskOption(Guid id)
        {
            _taskRepository.DeleteTaskOption(id);
        }
        public void UpdateTaskOption(TaskOptions taskOptions)
        {
            _taskRepository.UpdateTaskOption(taskOptions.Id,taskOptions.Title,taskOptions.Description);
        }
    }
}
