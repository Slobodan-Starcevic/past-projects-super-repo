namespace BLL.Models
{
    public class Note
    {
        private Guid id;
        private string text;
        private Employee employee;
        private List<Species>? species;
        private Guid employeeId;
        private Guid speciesId;
        private bool archive;

        //Constructor for new note creation 
        public Note(string text, Employee employee, List<Species> species)
        {
            this.Id = Guid.NewGuid();
            this.Text = text;
            this.Employee = employee;
            this.Species = species;
        }

        //Constructor for note retrieval from database
        public Note(Guid id, string text, Employee employee, List<Species>? species, bool archive)
        {
            this.Id = id;
            this.Text = text;
            this.Employee = employee;
            this.Species = species;
            this.Archive = archive;
        }

        public Note(Guid id, string text, Employee employee, bool archive)
            :this(id, text, employee, null, archive)
        {    
        }

        //TEST CTOR
        public Note(string text, Guid employeeId, Guid speciesId)
        {
            this.Id = Guid.NewGuid();
            this.Text = text;
            this.EmployeeId= employeeId;
            this.SpeciesId = speciesId;
        }

        public override string ToString()
        {
            if (Species != null)
            {
                return $"{Employee.FirstName} - {Species[0].SpeciesName}";
            }
            else
            {
                return Employee.FirstName;
            }
        }

        public Guid Id { get => id; private set => id = value; }
        public string Text { get => text; private set => text = value; }
        public Employee Employee { get => employee; private set => employee = value; }
        public List<Species>? Species { get => species; private set => this.species = value; }
        public Guid EmployeeId { get => employeeId; private set => employeeId = value; }
        public Guid SpeciesId { get => speciesId; private set => speciesId = value; }
        public bool Archive { get => archive; set => archive = value; }
    }
}