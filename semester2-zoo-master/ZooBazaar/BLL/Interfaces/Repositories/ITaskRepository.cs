using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        void Create(Models.Task task);
        Models.Task GetTask(Guid id);
        List<Models.Task> GetAllTasks();
        List<Models.Task> GetEmployeeTasks(Guid employee_id);
        void Edit(Guid id, string new_description);
        void Edit(Guid id, List<Species> species);
        void Edit(Guid id, List<Employee> employees);
        void Edit(Guid id, int shift_id);
        void Delete(Guid id);
        List<TaskOptions> GetTaskOptions();
        void CreateTaskOption(Guid id,string title,string description);
        void DeleteTaskOption(Guid id);
		void UpdateTaskOption(Guid id, string title, string description);
		List<Animal> GetTaskAnimals(Guid taskid);

	}
}
