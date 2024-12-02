using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace WindowsFormsCore.DTO
{
    public class TaskDTO
    {

        private int idTask;
        private string title;
        private string description;
        private List<Species> species;
        private List<Animal> animals;
        private List<Employee> assignedEmployees;
    }
}
