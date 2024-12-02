using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCore.ZooManager;

namespace WindowsFormApp
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();

            this.PnlView.Controls.Clear();
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(addEmployeeForm);
            addEmployeeForm.Show();
            //this.PnlView.Controls.Clear();
            //ProfileForm profileForm = new ProfileForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //this.PnlView.Controls.Add(profileForm);
            //profileForm.Show();
        }

        private void BtnProfileShow_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            ProfileForm profileForm = new ProfileForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(profileForm);
            profileForm.Show();
        }

        private void BtnAddEmployee_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(addEmployeeForm);
            addEmployeeForm.Show();
        }



        private void BtnAddAnimal_Click_1(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            AddAnimalSpeciesForm addAnimalForm = new AddAnimalSpeciesForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(addAnimalForm);
            addAnimalForm.Show();

        }
        private void BtnContentViewable_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            ContentAndViewableForm contentAndViewableForm = new ContentAndViewableForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(contentAndViewableForm);
            contentAndViewableForm.Show();
        }

        private void AddTaskOptionBtn_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            TaskOption taskOption = new TaskOption() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(taskOption);
            taskOption.Show();
        }
    }
}
