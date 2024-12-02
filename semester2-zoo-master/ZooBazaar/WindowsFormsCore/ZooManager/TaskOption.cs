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

namespace WindowsFormsCore.ZooManager
{
    public partial class TaskOption : Form
    {
        private TaskService taskService;
        public TaskOption()
        {
            taskService = new TaskService(new TaskRepository());
            InitializeComponent();
            OptionListbx.DataSource = taskService.GetTaskOptions();
            OptionListbx.DisplayMember = "title";
        }

        private void TaskOption_Load(object sender, EventArgs e)
        {

        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (TitleTxtbx.Text == string.Empty || TbxTaskDescription.Text == string.Empty)
                {
                    MessageBox.Show("Please fill in all information");
                }
                else
                {
                    TaskOptions taskOptions = new TaskOptions(TitleTxtbx.Text, TbxTaskDescription.Text);

                    taskService.CreateTaskOption(taskOptions);

                    MessageBox.Show("The option is succesfully created");
                    OptionListbx.DataSource = taskService.GetTaskOptions();
                    OptionListbx.DisplayMember = "title";
                }
            }
            if (result == DialogResult.No)
            {

            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (OptionListbx.SelectedItem != null)
            {
                TaskOptions taskOptions = (TaskOptions)OptionListbx.SelectedValue;
                TitleTxtbx.Text = taskOptions.Title;
                TbxTaskDescription.Text = taskOptions.Description;
            }
            else
            {
                MessageBox.Show("Please select something");
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (OptionListbx.SelectedItem != null)
                {
                    TaskOptions taskOptions = (TaskOptions)OptionListbx.SelectedValue;
                    taskService.Delete(taskOptions.Id);
                    OptionListbx.DataSource = taskService.GetTaskOptions();
                    OptionListbx.DisplayMember = "title";
                }
                else
                {
                    MessageBox.Show("Please select something");
                }
            }
            if (result == DialogResult.No)
            {

            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (OptionListbx.SelectedItem != null)
                {
                    TaskOptions taskOptions = (TaskOptions)OptionListbx.SelectedValue;
                    if (TitleTxtbx.Text == string.Empty || TbxTaskDescription.Text == string.Empty)
                    {
                        MessageBox.Show("Please fill in all information");
                    }
                    else
                    {
                        TaskOptions taskOption = new TaskOptions(taskOptions.Id, TitleTxtbx.Text, TbxTaskDescription.Text);

                        taskService.UpdateTaskOption(taskOption);

                        MessageBox.Show("The option is succesfully updated");
                        OptionListbx.DataSource = taskService.GetTaskOptions();
                        OptionListbx.DisplayMember = "title";
                    }
                }
                else
                {
                    MessageBox.Show("Please select something");
                }
            }
            if (result == DialogResult.No)
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TitleTxtbx_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
