using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Task
    {
        private Guid id;
        private string title;
        private string description;
        private int shiftId;
        private DateOnly date;
        private List<Species> species;
        private List<Employee>? assignedEmployees;

        //Constructor for new task creation WITH EMPLOYEE ASSIGNED
        public Task(string title, string description, int shiftid, List<Species> species,DateOnly date, List<Employee>? AssignedEmployees)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = description;
            this.ShiftId = shiftid;
            this.Species = species;
            this.AssignedEmployees = AssignedEmployees;
            this.date = date;
        }

        //Constructor for new task creation WITHOUT EMPLOYEE ASSIGNED
        public Task(string title, string description, int shiftid, List<Species> species, DateOnly date)          
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = description;
            this.ShiftId = shiftid;
            this.Species = species;
            this.date = date;
        }

        //Constructor for task retrieval from database WITH EMPLOYEE ASSIGNED
        public Task(Guid id, string title, string description, int shiftid, List<Species> species,DateOnly date ,List<Employee>? AssignedEmployees)
            :this(title, description, shiftid, species,date ,AssignedEmployees)
        {
            this.Id = id;
        }

        //Constructor for task retrieval from database WITHOUT EMPLOYEE ASSIGNED
        public Task(Guid id, string title, string description, int shiftid, List<Species> species,DateOnly date)
            : this(title, description, shiftid, species,date)
        {
            this.Id = id;
        }

        public void AddEmployee(Employee employee)
        {
            if (this.assignedEmployees.FirstOrDefault(e=>e.Id == employee.Id)!= null)
            {

            }
            else
            {
				AssignedEmployees?.Add(employee);
			}
          
        }
        public void RemoveEmployee(Employee employee)
        {
            assignedEmployees?.Remove(employee);
        }

		public override string ToString()
		{
            foreach (Species s in species)
            {
                if(s is Animal)
                {
                    return $"{title}-{((Animal)s).AnimalName}-{date.ToString()} ";
                }
                else
                {
                    return $"{title}-{s.SpeciesName}-{date.ToString()}";
				}  
            }
            return title;
		}
		public Guid Id { get => id; private set => id = value; }
        public string Title { get => title; private set => title = value; }
        public string Description { get => description; private set => description = value; }
        public int ShiftId { get => shiftId; private set => shiftId = value; }
        public List<Species> Species { get => species; private set => species = value; }
        public List<Employee>? AssignedEmployees { get => assignedEmployees; private set => assignedEmployees = value; }
        public DateOnly Date { get => date; private set => date = value; }
        public TimeSlot GetTimeSlot()
        {
            ShiftsManager sm = new ShiftsManager();

            return sm.timeSlots(this.shiftId);
        }
    }
}
