using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCore;
using WindowsFormsCore.DTO;
using WindowsFormsCore.HrManager;

namespace WindowsFormApp
{
    public partial class FormManager : Form
    {
        AccountDTO account;
        public FormManager()
        {
            InitializeComponent();
            ShowProfile();

        }

        private void ShowProfile()
        {
            this.PnlView.Controls.Clear();
            ProfileForm profileForm = new ProfileForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(profileForm);
            profileForm.Show();
        }

        private void BtnAddEmployeeShown_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(addEmployeeForm);
            addEmployeeForm.Show();
        }

        private void BtnProfileShow_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            ProfileForm profileForm = new ProfileForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(profileForm);
            profileForm.Show();
        }

        private void buttonNotes_Click(object sender, EventArgs e)
        {
            this.PnlView.Controls.Clear();
            Notes profileForm = new Notes() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlView.Controls.Add(profileForm);
            profileForm.Show();
        }
    }
}
