using BLL.Models;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Task = BLL.Models.Task;

namespace WebApp.DTO
{
    public class TaskDTO
    {
        private Guid id;
        private string title;
        private string description;
        private int shiftId;
        private DateOnly date;
        private List<Species> species;

        public TaskDTO()
        {
            /*
            this.title = title;
            this.description = description;
            this.shiftId = shiftId;
            this.date = date;
            */
        }

        public TaskDTO(Task task)
        {
            this.id = task.Id;
            this.title = task.Title;
            this.description = task.Description;
            this.shiftId = task.ShiftId;
            this.date = task.Date;
            this.species = task.Species;
        }

        public Guid ID { get { return this.id; } }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public int ShiftId { get => shiftId; set => shiftId = value; }
        public DateOnly Date { get => date; set => date = value; }
        public List<Species> Species { get => species; set => species = value; }

        public TimeSlot GetTimeSlot()
        {
            ShiftsManager sm = new ShiftsManager();

            return sm.timeSlots(this.shiftId);
        }
    }
}
