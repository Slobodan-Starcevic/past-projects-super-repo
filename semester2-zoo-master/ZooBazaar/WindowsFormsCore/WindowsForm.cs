using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCore.DTO;
using WindowsFormsCore;
using BLL.Models;
using BLL.Interfaces.Services;

namespace WindowsFormApp
{
    public partial class WindowsForm : Form
    {
        private AccountDTO dTO;

        public WindowsForm()
        {
            InitializeComponent();
            dTO = new AccountDTO();
            ShowLogInForm();

        }

        private void ShowLogInForm()
        {
            this.PnlLogIn.Controls.Clear();
            LogInForm logInForm = new LogInForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlLogIn.Controls.Add(logInForm);
            logInForm.Show();
        }

        private void BtnTestAdmin_Click(object sender, EventArgs e)
        {
            //Employee employee = new Employee(1,"tim", "martins", "4321-321-4312", "empty", DateOnly.FromDateTime(DateTime.Now), Gender.Male, Role.ADMIN, 22, "tim.martins@test.nl", "workMail@test.com", "NLING 1234567", "password", "salt", "Rachelsmolen 10");
            //dTO.SelectEmployee(employee);
            AdminLogin();
        }

        private void BtnTestLogin_Click(object sender, EventArgs e)
        {
            ShowLogInForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Employee employee = new Employee(2,"tim", "martins", "4321-321-4312", "empty", DateOnly.FromDateTime(DateTime.Now), Gender.Male, Role.PLANNER, 22, "tim.martins@test.nl", "workMail@test.com", "NLING 1234567", "password", "salt", "Rachelsmolen 10");
            //dTO.SelectEmployee(employee);
            PlannerLogin();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //Employee employee = new Employee(3,"tim", "martins", "4321-321-4312", "empty", DateOnly.FromDateTime(DateTime.Now), Gender.Male, Role.MANAGER, 22, "tim.martins@test.nl", "workMail@test.com", "NLING 1234567", "password","salt", "Rachelsmolen 10");
            //dTO.SelectEmployee(employee);
            ManagerLogin();
        }

        private void LoginChecker_Tick(object sender, EventArgs e)
        {
            try
            {
                if (dTO.User != null)
                {
                    this.LblWFName.Text = dTO.User.FirstName;
                    this.LblWFFunction.Text = dTO.User.Role.ToString();
                    this.LoginChecker.Enabled = false;
                    ShowMenu(dTO.User.Role.ToString());

                    this.BtnLogout.Enabled = true;
                    this.BtnLogout.Visible = true;
                }
                else
                {
                    this.BtnLogout.Enabled = false;
                    this.BtnLogout.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }

        }


        private void ChangeScreenBack()
        {
            ShowLogInForm();
        }

        private void ShowMenu(string role)
        {
            switch (role)
            {
                case "ADMIN":
                    AdminLogin();
                    break;
                case "PLANNER":
                    PlannerLogin();
                    break;
                case "MANAGER":
                    ManagerLogin();
                    break;
            }
        }

        private void ManagerLogin()
        {
            this.PnlLogIn.Controls.Clear();
            FormManager formManager = new FormManager() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlLogIn.Controls.Add(formManager);
            formManager.Show();
        }

        private void PlannerLogin()
        {
            this.PnlLogIn.Controls.Clear();
            FormPlanner planner = new FormPlanner() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlLogIn.Controls.Add(planner);
            planner.Show();
        }

        private void AdminLogin()
        {
            this.PnlLogIn.Controls.Clear();
            FormAdmin formAdmin = new FormAdmin() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.PnlLogIn.Controls.Add(formAdmin);
            formAdmin.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            dTO.LogOut();
            this.LoginChecker.Enabled = true;
            ShowLogInForm();

        }
    }
}
