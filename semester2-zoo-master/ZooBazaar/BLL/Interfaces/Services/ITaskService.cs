using BLL.Interfaces.Repositories;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Services
{
    public interface ITaskService
    {
        void CreateWithEmployee(BLL.Models.Task task);

        void CreateWithoutEmployee(BLL.Models.Task task);

        void Delete(Guid id);

        void Edit(Guid id, string new_description);

        void Edit(Guid id, List<Species> species);

        void Edit(Guid id, List<Employee> employees);

        void Edit(Guid id, int shift_id);

        List<Models.Task> GetAllTasks();

        Models.Task GetTask(Guid id);
    }
}
