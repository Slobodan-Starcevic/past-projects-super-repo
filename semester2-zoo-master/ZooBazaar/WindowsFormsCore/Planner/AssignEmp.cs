using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Models;
using BLL.Services;
using DAL.Repositories;
using WindowsFormsCore.DTO;

namespace WindowsFormApp
{
    public partial class AssignEmp : Form
    {
        private BLL.Models.Task task;
        private TaskService taskService;
        private EmployeeService employeeService;
        private SpeciesService speciesService;
        private AnimalService animalService;

        public AssignEmp()
        {
            employeeService = new EmployeeService(new EmployeeRepository());
            taskService = new TaskService(new TaskRepository());
            speciesService = new SpeciesService(new SpeciesRepository());
            animalService = new AnimalService(new AnimalRepository(), new ContentRepository());
            var retrievedTask = taskService.GetAllTasks().FirstOrDefault(t => t.Id == SheduleAndTask.Taskid);
            if (retrievedTask != null)
            {
                task = retrievedTask;
            }
            else
            {

            }
            InitializeComponent();
            Loademployees();
            BtnRemoveEmployee.Visible = true;
            Shiftcmbx.SelectedIndex = task.ShiftId;
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {

        }

        private void lbxassignedEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Loademployees()
        {
            lbxassignedEmployees.DataSource = null;
            CmbxEmployee.DataSource = null;
            AddLabel.Text = "Add Employees";

            if (task.AssignedEmployees == null)
            {
                lbxassignedEmployees.DataSource = null;
            }
            else
            {
                lbxassignedEmployees.DataSource = task.AssignedEmployees;
            }

            lbxassignedEmployees.DisplayMember = "FullName";

            List<Employee> employees = new List<Employee>();


            foreach (Employee employee in employeeService.GetAllEmployees())
            {
                var EmployeeTask = taskService.GetEmployeesTask(employee.Id);
                if (task.AssignedEmployees.FirstOrDefault(e => e.Id == employee.Id) != null
                    || EmployeeTask.FirstOrDefault(t => t.ShiftId == Shiftcmbx.SelectedIndex) != null && EmployeeTask.FirstOrDefault(t => t.Date == task.Date) != null
                    || (int)employee.Role != RoleCmbox.SelectedIndex)
                {

                }

                else
                {
                    employees.Add(employee);
                }
            }
            CmbxEmployee.DataSource = employees;
            CmbxEmployee.DisplayMember = "FullName";
            RoleCmbox.Enabled = true;


        }
        private void LoadSpecies()
        {
            lbxassignedEmployees.DataSource = null;
            CmbxEmployee.DataSource = null;
            AddLabel.Text = "Add Species";

            if (task.AssignedEmployees == null)
            {
                lbxassignedEmployees.DataSource = null;
            }
            else
            {
                var Species = new List<Species>();
                foreach (var s in task.Species)
                    if (s is not Animal)
                    {
                        Species.Add(s);
                    }
                lbxassignedEmployees.DataSource = Species;
            }

            lbxassignedEmployees.DisplayMember = "speciesName";
            List<Species> SpeciesList = new List<Species>();
            foreach (Species species in speciesService.GetAllSpeciesNames())
            {

                if (task.Species.Contains(species))
                {

                }
                else
                {
                    SpeciesList.Add(species);
                }
            }
            CmbxEmployee.DataSource = SpeciesList;
            CmbxEmployee.DisplayMember = "speciesName";
            RoleCmbox.Enabled = false;
        }
        private void LoadAnimals()
        {
            lbxassignedEmployees.DataSource = null;
            CmbxEmployee.DataSource = null;
            AddLabel.Text = "Add Animals";

            if (task.AssignedEmployees == null)
            {
                lbxassignedEmployees.DataSource = null;
            }
            else
            {
                var Species = new List<Animal>();
                foreach (var s in task.Species)
                    if (s is Animal)
                    {
                        Species.Add((Animal)s);
                    }
                lbxassignedEmployees.DataSource = Species;

            }

            lbxassignedEmployees.DisplayMember = "animalName";
            List<Animal> AnimalList = new List<Animal>();
            foreach (Animal animal in animalService.GetAnimals())
            {

                if (task.Species.Contains(animal))
                {

                }
                else
                {
                    AnimalList.Add(animal);
                }
            }
            CmbxEmployee.DataSource = AnimalList;
            CmbxEmployee.DisplayMember = "animalName";
            RoleCmbox.Enabled = false;
        }

        private void AssignEmp_Load(object sender, EventArgs e)
        {


        }

        private void CmbxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }








        private void reloadBtn_Click(object sender, EventArgs e)
        {
            Loademployees();
        }

        private void RoleCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Employee> employees = new List<Employee>();
            foreach (Employee employee in employeeService.GetAllEmployees())
            {
                if (RoleCmbox.SelectedIndex < 0 || (int)employee.Role == RoleCmbox.SelectedIndex)
                {
                    employees.Add(employee);
                }
            }
            CmbxEmployee.DataSource = null;
            CmbxEmployee.DataSource = employees;
            CmbxEmployee.DisplayMember = "FullName";


        }

        private void Shiftcmbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void BtnAddEmployee_Click_2(object sender, EventArgs e)
        {
            if (CmbxEmployee.SelectedItem != null)
            {
                if (CmbxEmployee.SelectedItem is Employee selectedEmployee)
                {
                    task.AddEmployee(selectedEmployee);
                    Loademployees();
                }
                if (CmbxEmployee.SelectedItem is Species selectedSpecies)
                {
                    if (selectedSpecies is Animal)
                    {
                        var animals = new List<Animal>();
                        foreach (Species s in task.Species)
                            if (s is Animal)
                            {
                                animals.Add((Animal)s);
                            }
                        if (animals.FirstOrDefault(a => a.AnimalId == ((Animal)selectedSpecies).AnimalId) != null)
                        {

                        }
                        else
                        {
                            task.Species.Add(selectedSpecies);
                            LoadAnimals();

                        }
                    }
                    else
                    {
                        task.Species.Add(selectedSpecies);
                        LoadSpecies();
                    }
                }



            }
            else
            {
                MessageBox.Show("The selected item is not a valid Employee.");
            }

        }

        private void SpeciesBtn_Click_1(object sender, EventArgs e)
        {
            LoadSpecies();
        }

        private void EmployeeBtn_Click_1(object sender, EventArgs e)
        {
            Loademployees();
        }

        private void AnimalBtn_Click_1(object sender, EventArgs e)
        {
            LoadAnimals();
        }

        private void BtnRemoveEmployee_Click_1(object sender, EventArgs e)
        {
            if (lbxassignedEmployees.SelectedItem != null)
            {
                if (lbxassignedEmployees.SelectedItem is Employee selectedEmployee)
                {
                    task.RemoveEmployee(selectedEmployee);
                    Loademployees();
                }
                if (lbxassignedEmployees.SelectedItem is Species selectedSpecies)
                    if (task.Species.Count == 1)
                    {
                        MessageBox.Show("A task cannot have no species or animals");
                    }
                    else
                    {
                        if (selectedSpecies is Animal)
                        {

                            task.Species.Remove(selectedSpecies);
                            LoadAnimals();

                        }
                        else
                        {
                            task.Species.Remove(selectedSpecies);
                            LoadSpecies();
                        }
                    }
                else
                {
                    MessageBox.Show("Please choose something first.");
                }
            }

        }
        private void Savebtn_Click_1(object sender, EventArgs e)
        {
            taskService.Edit(task.Id, task.AssignedEmployees);
            taskService.Edit(task.Id, task.Species);
            if (Shiftcmbx.SelectedIndex < 0)
            {

            }
            else
            {
                taskService.Edit(task.Id, Shiftcmbx.SelectedIndex);
            }
            this.Close();
        }

        private void Shiftcmbx_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List<Employee> BoxList = lbxassignedEmployees.Items.Cast<Employee>().ToList();
            bool ShiftEmloyees = false;
            foreach (Employee employee in BoxList)
            {
                var EmployeeTask = taskService.GetEmployeesTask(employee.Id);
                if (EmployeeTask.FirstOrDefault(x => x.ShiftId == Shiftcmbx.SelectedIndex && x.Date == task.Date && x.Id != task.Id) != null)
                {
                    ShiftEmloyees = true;
                    break;
                }
            }
            if (ShiftEmloyees)
            {
                MessageBox.Show("There is a employee with the same shift");
                Shiftcmbx.SelectedIndex = task.ShiftId;
            }
            else
            {
                Loademployees();
            }
        }

        private void CmbxEmployee_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void RoleCmbox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            Loademployees();

        }

        private void AssignEmp_Load_1(object sender, EventArgs e)
        {

        }
    }
}
