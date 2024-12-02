using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Interfaces.Repositories;
using BLL.Models;
using BLL.Services;
using DAL.Repositories;

namespace WindowsFormsCore.Planner
{
    public partial class TaskInfo : Form
    {

        private SpeciesService speciesService;
        private AnimalService animalService;
        private TaskService taskService;
        private List<Species> returnSpecies = new List<Species>();
        private List<Employee> returnEmployees = new List<Employee>();
        private EmployeeService employeeService;

        public TaskInfo()
        {
            this.animalService = new AnimalService(new AnimalRepository(), new ContentRepository());
            this.speciesService = new SpeciesService(new SpeciesRepository());
            this.taskService = new TaskService(new TaskRepository());
            this.employeeService = new EmployeeService(new EmployeeRepository());
            InitializeComponent();
            TitleCmbx.DataSource = taskService.GetTaskOptions();
            TitleCmbx.DisplayMember = "title".Trim();
            foreach (TaskOptions t in TitleCmbx.Items)
            {
                if (t == TitleCmbx.SelectedItem)
                {
                    TbxTaskDescription.Text = t.Description;
                }
            }


        }
        public void Reload()
        {

        }

        private void TaskInfo_Load(object sender, EventArgs e)
        {

        }

        private void Filterbtn_Click(object sender, EventArgs e)
        {

        }



        private void AnimalBTN_Click(object sender, EventArgs e)
        {


        }


        private void Addspecies_Click(object sender, EventArgs e)
        {



        }

        private void BtnSaveTask_Click(object sender, EventArgs e)
        {

            bool stopProgram = false;

            try
            {
                foreach (Employee employee in returnEmployees)
                {
                    var employeeTask = taskService.GetEmployeesTask(employee.Id);
                    DateOnly date = DateOnly.FromDateTime(DateTaskPicker.Value);
                    bool b = employeeTask.Any(x => x.ShiftId == CmbShifts.SelectedIndex && x.Date == date);
                    if (b)
                    {
                        MessageBox.Show($"This employee has already a task on the same shift: {employee.FirstName}");
                        stopProgram = true;
                        break;
                    }
                }

                if (stopProgram)
                {
                    // Exit the program or perform any necessary cleanup
                    return;
                }

                if (returnSpecies.Count == 0)
                {
                    MessageBox.Show("Please add some Animals or species to the task");
                }
                else
                {
                    if (TitleCmbx.Text == String.Empty ^ TbxTaskDescription.Text == String.Empty ^ CmbShifts.SelectedIndex <= -1)
                    {
                        MessageBox.Show("Please fill in everything");
                    }
                    else
                    {
                        DateTime time = DateTaskPicker.Value.Date;
                        DateOnly taskDate = new DateOnly(time.Year, time.Month, time.Day);

                        // Create and save the task
                        BLL.Models.Task task = new BLL.Models.Task(TitleCmbx.Text, TbxTaskDescription.Text, CmbShifts.SelectedIndex, returnSpecies, taskDate, returnEmployees);
                        taskService.CreateWithEmployee(task);
                        lbxSpecies.DataSource = null;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AnimalBTN_Click_1(object sender, EventArgs e)
        {
            lbxSpecies.DataSource = null;
            if (animalService.GetAnimals().Count == 0)
            {
                MessageBox.Show("There was a problem retrieving data");
            }
            else
            {
                var Animals = new List<Animal>();
                foreach (var a in returnSpecies)
                    if (a is Animal)
                    {
                        Animals.Add((Animal)a);
                    }
                lbxSpecies.DataSource = Animals;
                lbxSpecies.DisplayMember = "animalName".Trim();

                AddCmbx.DataSource = animalService.GetAnimals();
                AddCmbx.DisplayMember = "animalName".Trim();



            }
        }

        private void EmployeeBtn_Click(object sender, EventArgs e)
        {
            if (employeeService.GetAllEmployees().Count == 0)
            {
                MessageBox.Show("There is something wrong with retriving data");
            }
            else
            {
                lbxSpecies.DataSource = null;
                lbxSpecies.DataSource = returnEmployees;
                lbxSpecies.DisplayMember = "FullName".Trim();

                AddCmbx.DataSource = employeeService.GetAllEmployees();
                AddCmbx.DisplayMember = "FullName".Trim();

            }
        }

        private void SpeciesBTN_Click_1(object sender, EventArgs e)
        {
            if (speciesService.GetSpeciesList().Count == 0)
            {
                MessageBox.Show("There is something wrong with retriving data");
            }
            else
            {
                var Species = new List<Species>();
                foreach (var s in returnSpecies)
                    if (s is not Animal)
                    {
                        Species.Add(s);
                    }
                lbxSpecies.DataSource = null;
                lbxSpecies.DataSource = Species;
                lbxSpecies.DisplayMember = "speciesName".Trim();

                AddCmbx.DataSource = speciesService.GetAllSpeciesNames();
                AddCmbx.DisplayMember = "speciesName".Trim();


            }
        }

        private void Addspecies_Click_1(object sender, EventArgs e)
        {
            if (AddCmbx.SelectedItem != null)
            {
                if (AddCmbx.SelectedItem is Species selectedSpecies)
                {

                    if (!returnSpecies.Contains(selectedSpecies))
                    {
                        returnSpecies.Add(selectedSpecies);
                    }
                    if (selectedSpecies is Animal)
                    {
                        var Animals = new List<Animal>();
                        foreach (var a in returnSpecies)
                            if (a is Animal)
                            {
                                Animals.Add((Animal)a);
                            }
                        lbxSpecies.DataSource = Animals;
                        lbxSpecies.DisplayMember = "animalName".Trim();
                    }
                    else
                    {
                        var Species = new List<Species>();
                        foreach (var s in returnSpecies)
                            if (s is not Animal)
                            {
                                Species.Add(s);
                            }
                        lbxSpecies.DataSource = Species;
                        lbxSpecies.DisplayMember = "speciesName".Trim();
                    }

                }
                else if (AddCmbx.SelectedItem is Employee selectedEmployee)
                {
                    if (!returnEmployees.Contains(selectedEmployee))
                    {
                        returnEmployees.Add(selectedEmployee);
                        var employees = returnEmployees.ToList();
                        lbxSpecies.DataSource = employees;
                        lbxSpecies.DisplayMember = "FullName".Trim();
                    }
                }
                else
                {
                    MessageBox.Show("The selected item is of an unrecognizable type.");
                }

            }
            else
            {
                MessageBox.Show("No item is selected.");
            }
        }

        private void TbxTaskDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbxSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (lbxSpecies.SelectedItem != null)
            {
                if (lbxSpecies.SelectedItem is Species selectedSpecies)
                {

                    returnSpecies.Remove(selectedSpecies);
                    if (selectedSpecies is Animal)
                    {
                        var Animals = new List<Animal>();
                        foreach (var a in returnSpecies)
                            if (a is Animal)
                            {
                                Animals.Add((Animal)a);
                            }
                        lbxSpecies.DataSource = Animals;
                        lbxSpecies.DisplayMember = "animalName".Trim();
                    }
                    else
                    {
                        var Species = new List<Species>();
                        foreach (var s in returnSpecies)
                            if (s is not Animal)
                            {
                                Species.Add(s);
                            }
                        lbxSpecies.DataSource = Species;
                        lbxSpecies.DisplayMember = "speciesName".Trim();
                    }
                }
                else if (lbxSpecies.SelectedItem is Employee selectedEmployee)
                {
                    returnEmployees.Remove(selectedEmployee);
                    var employees = returnEmployees.ToList();
                    lbxSpecies.DataSource = employees;
                    lbxSpecies.DisplayMember = "FullName".Trim();
                }
                else
                {
                    MessageBox.Show("The selected item is of an unrecognizable type.");
                }
                TitleCmbx.DataSource = taskService.GetTaskOptions();

            }
            else
            {
                MessageBox.Show("No item is selected.");
            }
        }

        private void TitleCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TitleCmbx.SelectedItem != null)
            {
                TaskOptions taskOptions = (TaskOptions)TitleCmbx.SelectedItem;
                TbxTaskDescription.Text = taskOptions.Description;
            }
        }
    }
}