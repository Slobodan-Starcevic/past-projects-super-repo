using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCore.Planner;

namespace WindowsFormApp
{
    public partial class FormPlanner : Form
    {

        public FormPlanner()
        {
            InitializeComponent();
            this.PnlView.Controls.Clear();
            ProfileForm profileForm = new ProfileForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(profileForm);
            profileForm.Show();
        }

        private void BtnProfileShow_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            ProfileForm profileForm = new ProfileForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(profileForm);
            profileForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            SheduleAndTask taskForm = new SheduleAndTask() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(taskForm);
            taskForm.Show();
        }

        private void PnlView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            TaskInfo Addtask = new TaskInfo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(Addtask);
            Addtask.Show();

        }
    }
}
