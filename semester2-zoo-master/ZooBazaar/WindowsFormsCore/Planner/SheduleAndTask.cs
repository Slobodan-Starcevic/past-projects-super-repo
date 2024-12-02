using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Interfaces.Services;
using BLL.Services;
using BLL.Models;
using DAL.Repositories;
using WindowsFormsCore;
using WindowsFormsCore.Planner;
using System.Net.Http.Headers;

namespace WindowsFormApp
{
    public partial class SheduleAndTask : Form
    {
        private EmployeeService employeeService;
        private TaskService taskService;
        public static Guid Taskid = Guid.Empty;

        public SheduleAndTask()
        {
            employeeService = new EmployeeService(new EmployeeRepository());
            taskService = new TaskService(new TaskRepository());
            InitializeComponent();

            LsbxTasks.DataSource = taskService.GetAllTasks();

            EmployeeListbox.ValueMember = "FirstName";
            EmployeeListbox.DisplayMember = "FirstName";
            EmployeeListbox.DataSource = employeeService.GetAllEmployees();

            titlecmbx.DataSource = taskService.GetTaskOptions();
            titlecmbx.DisplayMember = "title".Trim();

        }



        private void LsbxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            LsbxTasks.DataSource = null;
            LsbxTasks.DisplayMember = "title";
            LsbxTasks.DataSource = taskService.GetAllTasks();




        }

        private void ReloadBtn_Click(object sender, EventArgs e)
        {
            LsbxTasks.DataSource = taskService.GetAllTasks();

        }

        private void BtnAddTask_Click(object sender, EventArgs e)
        {

            TaskInfo taskInfo = new TaskInfo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            taskInfo.Show();
        }

        private void AssignBtn_Click(object sender, EventArgs e)
        {
            if (LsbxTasks.SelectedItem == null)
            {
                MessageBox.Show("Please select a task");
            }
            else
            {
                BLL.Models.Task task = (BLL.Models.Task)LsbxTasks.SelectedItem;
                Taskid = task.Id;
                AssignEmp assign = new AssignEmp();
                assign.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var searchTerm = titlecmbx.Text;
            var Tasks = LsbxTasks.Items.Cast<BLL.Models.Task>().ToList();

            var ShowTasks = new List<BLL.Models.Task>();
            foreach (BLL.Models.Task t in Tasks)
                if (t.Title.Trim() == searchTerm.Trim())
                {
                    ShowTasks.Add(t);
                }
            LsbxTasks.DataSource = ShowTasks;



        }

        private void EmployeeListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var employees = EmployeeListbox.Items.Cast<Employee>().ToList();

            foreach (Employee employee in employees)
            {
                if (employee == EmployeeListbox.SelectedItem)
                {
                    var task = taskService.GetEmployeesTask(employee.Id);
                    EmployeeTaskLsbx.DataSource = task;

                    break;
                }
            }

        }


        private void EmployeeTaskLsbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var tasks = LsbxTasks.Items.Cast<BLL.Models.Task>().ToList();

            foreach (BLL.Models.Task task in tasks)
            {
                if (task == LsbxTasks.SelectedItem)
                {
                    Taskid = task.Id;
                    TaskShow taskShow = new TaskShow();
                    taskShow.Show();
                }
            }
        }
        private void SearchByEmployeeBtn_Click(object sender, EventArgs e)
        {
            var tasks = new List<BLL.Models.Task>();
            foreach (BLL.Models.Task t in taskService.GetAllTasks())
                if (t.AssignedEmployees.Count == 0)
                {
                    tasks.Add(t);
                }
            LsbxTasks.DataSource = tasks;
        }

        private void SearhNameTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LsbxTasks_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void SelectDate_Click(object sender, EventArgs e)
        {
            DateTime datepicker = dateTimePicker1.Value;
            var date = new DateOnly(datepicker.Year, datepicker.Month, datepicker.Day);
            var DateTasks = new List<BLL.Models.Task>();
            var tasks = taskService.GetAllTasks();
            foreach (BLL.Models.Task t in tasks)
                if (t.Date == date)
                {
                    DateTasks.Add(t);
                }

            LsbxTasks.DataSource = DateTasks;

        }

        private void DateAllBtn_Click(object sender, EventArgs e)
        {
            LsbxTasks.DataSource = taskService.GetAllTasks();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                List<BLL.Models.Task> tasks = LsbxTasks.Items.Cast<BLL.Models.Task>().ToList();

                BLL.Models.Task task = (BLL.Models.Task)LsbxTasks.SelectedItem;
                taskService.Delete(task.Id);
                tasks.Remove(task);

                LsbxTasks.DataSource = tasks;

            }
            else if (result == DialogResult.No)
            {

            }

        }
    }
}