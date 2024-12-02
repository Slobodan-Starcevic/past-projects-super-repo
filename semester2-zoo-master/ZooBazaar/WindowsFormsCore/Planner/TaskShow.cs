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
using WindowsFormApp;

namespace WindowsFormsCore.Planner
{
    public partial class TaskShow : Form
    {
        private BLL.Models.Task task;
        private TaskService taskService;
        private ShiftsManager shiftsManager;
        public TaskShow()
        {
            shiftsManager = new ShiftsManager();
            taskService = new TaskService(new TaskRepository());
            var retrievedTask = taskService.GetAllTasks().FirstOrDefault(t => t.Id == SheduleAndTask.Taskid);
            if (retrievedTask != null)
            {
                task = retrievedTask;
            }
            var Species = new List<Species>();
            foreach (var s in task.Species)
                if (s is not Animal)
                {
                    Species.Add(s);
                }
            var Animals = new List<Animal>();
            foreach (Species s in task.Species)
                if (s is Animal)
                {
                    Animals.Add((Animal)s);
                }
            TimeSlot timeSlot = shiftsManager.timeSlots(task.ShiftId);
            InitializeComponent();

            Titletxtbx.Text = task.Title;
            TbxTaskDescription.Text = task.Description;

            EmployeesLsbx.DataSource = task.AssignedEmployees;
            EmployeesLsbx.DisplayMember = "FullName";
            AnimalsLsbx.DataSource = Animals;
            AnimalsLsbx.DisplayMember = "animalName";
            SpeciesLsbx.DataSource = Species;
            SpeciesLsbx.DisplayMember = "speciesName";


            ShiftTxtbx.Text = timeSlot.ToString();
            DateTxtbx.Text = task.Date.ToString();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbxTaskDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
