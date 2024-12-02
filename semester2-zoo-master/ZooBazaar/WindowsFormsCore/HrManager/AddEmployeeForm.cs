using BLL.Models;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsCore.DTO;
using static System.Net.WebRequestMethods;

namespace WindowsFormApp
{
    public partial class AddEmployeeForm : Form
    {
        private EmployeesDTO employeesDTO = new EmployeesDTO();
        private int selectedIndex = -1;
        private delegate void NewEmployee();
        private NewEmployee newEmployee;
        private int stateNew = 0;

        private delegate void UpdateEmployee(Guid id);
        private delegate void accountEddit(Guid id);
        private accountEddit AccountEddit;

        private UpdateEmployee updateEmployee;
        private int stateEddit = 0;

        private string filepath = GetFilePath(); //@"C:\myFiles\fontys folder\SEM 2 Documents\project_Group\Project\semester2-zoo\ZooBazaar\ZooBazaar_WebApp\wwwroot\media\pfp\";

        public AddEmployeeForm()
        {
            InitializeComponent();
            employeesDTO = new EmployeesDTO();
            FillListBox();


            this.CmbxGender.DataSource = Enum.GetValues(typeof(Gender));
            this.CmbxRole.DataSource = Enum.GetValues(typeof(Role));
        }
        private static string GetFilePath()
        {
            string directoryC = Environment.CurrentDirectory;
            string[] splt = directoryC.Split(new string[] { @"\WindowsFormsCore" }, StringSplitOptions.None);
            string path = Path.Combine(splt[0], @"ZooBazaar_WebApp\wwwroot\media\pfp\");


            return path;
        }

        private void FillListBox()
        {
            this.LsBxEmployees.DataSource = null;
            try
            {
                employeesDTO.GetEmployeeList();


                this.LsBxEmployees.DisplayMember = "FirstName";
                this.LsBxEmployees.ValueMember = "FirstName";
                this.LsBxEmployees.DataSource = employeesDTO.Employees;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex} error");
            }
            this.LsBxEmployees.SelectedItems.Clear();

        }


        private void ClearForm()
        {
            this.LsBxEmployees.SelectedItems.Clear();
            selectedIndex = -1;
            stateEddit = 0;
            stateNew = 0;
            CheckStateNew();
            checkStateUpdate();
            updateEmployee = null;
            newEmployee = null;

            this.BtnAddEmployee.Visible = true;
            this.BtnAddEmployee.Enabled = true;

            this.BtnUpdateEmployee.Enabled = false;
            this.BtnUpdateEmployee.Visible = false;
            this.BtnRemEmpolyee.Visible = false;
            this.BtnRemEmpolyee.Enabled = false;

            this.TbxFName.Clear();
            this.TbxLName.Clear();
            this.CmbxGender.SelectedIndex = -1;
            this.TbxPersonalEmail.Clear();
            this.TbxAdress.Clear();
            this.TbxBankAccount.Clear();
            this.TbxSSN.Clear();
            this.CmbxRole.SelectedIndex = -1;
            this.NudHourlyRate.ResetText();
            this.TbxWorkemail.Clear();
            this.TbxImageLink.PlaceholderText = "Please paste image link here";

            FillListBox();
        }

        private void FilFormWithEmployeeInfo()
        {
            this.TbxFName.Text = employeesDTO.SelectedEmployee.FirstName;
            this.TbxLName.Text = employeesDTO.SelectedEmployee.LastName;
            this.DtpBirthdate.Value = employeesDTO.SelectedEmployee.BirthDate.ToDateTime(TimeOnly.MinValue);
            this.CmbxGender.SelectedItem = employeesDTO.SelectedEmployee.Gender;
            this.TbxPersonalEmail.Text = employeesDTO.SelectedEmployee.PersonalEmail;
            this.TbxAdress.Text = employeesDTO.SelectedEmployee.Address;
            this.TbxBankAccount.Text = employeesDTO.SelectedEmployee.BankAccount;
            this.CmbxRole.SelectedItem = employeesDTO.SelectedEmployee.Role;
            if (employeesDTO.SelectedEmployee.HourlyRate > 1)
            {
                this.NudHourlyRate.Value = employeesDTO.SelectedEmployee.HourlyRate;
            }
            else
            {
                this.NudHourlyRate.Value = 15;
                MessageBox.Show("input valid hourly rate");
            }
            this.TbxWorkemail.Text = employeesDTO.SelectedEmployee.WorkEmail;
            this.TbxSSN.Text = employeesDTO.SelectedEmployee.Ssn;
            this.TbxImageLink.Text = employeesDTO.SelectedEmployee.PhotoURL;
        }
        private void LsBxEmployees_MouseClick(object sender, MouseEventArgs e)
        {

            if (this.LsBxEmployees.SelectedIndex != -1)
            {
                selectedIndex = this.LsBxEmployees.SelectedIndex;
                Employee emp = (Employee)this.LsBxEmployees.Items[selectedIndex];
                employeesDTO.SelectEmployee(emp);
                FilFormWithEmployeeInfo();

                FormForUpdate();
            }
            else
            {

                ClearForm();

            }
        }

        private void FormForUpdate()
        {
            this.BtnAddEmployee.Visible = false;
            this.BtnAddEmployee.Enabled = false;

            this.BtnUpdateEmployee.Visible = true;

            this.BtnNewEmployee.Enabled = true;
            this.BtnNewEmployee.Visible = true;
            this.BtnRemEmpolyee.Visible = true;
            this.BtnRemEmpolyee.Enabled = true;

        }

        private void BtnUpdateEmployee_Click(object sender, EventArgs e)
        {
            updateEmployee(employeesDTO.SelectedEmployee.Id);
            ClearForm();
        }

        private void BtnCancel_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnAddEmployee_Click_1(object sender, EventArgs e)
        {
            newEmployee();
            employeesDTO.AddNewEmployee();
            ClearForm();

        }

        private void EdditPhotoUrl(Guid id)
        {
            employeesDTO.EdditPhotoUrl(id, this.TbxImageLink.Text);
        }


        private void EdditWorkEmail()
        {
            if (this.TbxFName.Text.Length > 0 && this.TbxLName.Text.Length > 0)
            {
                if (selectedIndex != -1)
                {
                    this.TbxWorkemail.Text = $"{this.TbxFName.Text.Substring(0, 1)}.{this.TbxLName.Text}@Zoobazaar.nl";
                    if (this.TbxWorkemail.Text != employeesDTO.SelectedEmployee.WorkEmail)
                    {
                        if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditAccountWorkEmail))
                        {
                            updateEmployee += EdditAccountWorkEmail;
                            stateEddit += 1;
                        }
                    }
                    else
                    {
                        if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditAccountWorkEmail))
                        {
                            updateEmployee -= EdditAccountWorkEmail;
                            stateEddit -= 1;
                        }
                    }
                    checkStateUpdate();
                }
                else
                {
                    if (this.TbxFName.Text.Length > 0 && this.TbxLName.Text.Length > 0 && this.CmbxRole.SelectedIndex != -1)
                    {
                        this.TbxWorkemail.Text = $"{this.TbxFName.Text.Substring(0, 1)}.{this.TbxLName.Text}@Zoobazaar.nl";
                        if (newEmployee == null || !newEmployee.GetInvocationList().Contains(AddNewEmployeeWorMail))
                        {
                            newEmployee += AddNewEmployeeWorMail;
                            stateNew += 1;
                        }
                        CheckStateNew();
                    }

                }
            }
        }

        private void AddNewEmployeeWorMail()
        {
            employeesDTO.AddEmployeeWorkmail(this.TbxWorkemail.Text);
        }

        private void EdditAccountWorkEmail(Guid id)
        {
            employeesDTO.EdditWorkEmail(id, this.TbxWorkemail.Text);

        }

        private void NewEmployeeFName()
        {
            employeesDTO.AddEmployeeFname(this.TbxFName.Text);
        }

        private void EdditFname(Guid id)
        {
            employeesDTO.EdditFname(id, this.TbxFName.Text);
        }


        private void NewEmployeeLName()
        {
            employeesDTO.AddEmployeeLName(this.TbxLName.Text);
        }

        private void EdditLname(Guid id)
        {
            employeesDTO.EdditLastname(id, this.TbxLName.Text);
        }

        private void DtpBirthdate_Leave(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                if (this.DtpBirthdate.Value.Date != employeesDTO.SelectedEmployee.BirthDate.ToDateTime(TimeOnly.MinValue).Date)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditBirhtDate))
                    {
                        updateEmployee += EdditBirhtDate;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditBirhtDate))
                    {
                        updateEmployee -= EdditBirhtDate;
                        stateEddit -= 1;
                    }
                }
                checkStateUpdate();
            }
            else
            {
                var today = DateTime.Today;
                var age = today.Year - this.DtpBirthdate.Value.Year;
                if (this.DtpBirthdate.Value.Date > today.AddYears(-age))
                {
                    age--;
                }
                if (age > 80)
                {
                    MessageBox.Show("this person should retire");
                    MinusAddBirthdate();
                }
                else if (age < 21)
                {
                    MessageBox.Show("this person is not old enough");
                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(AddNewEmployeeBirthdate))
                    {
                        newEmployee += AddNewEmployeeBirthdate;
                        stateNew += 1;
                    }
                }
                CheckStateNew();

            }
        }

        private void EdditBirhtDate(Guid id)
        {
            employeesDTO.EdditBirthdate(id, this.DtpBirthdate.Value.Date);
        }


        private void MinusAddBirthdate()
        {
            if (newEmployee != null && newEmployee.GetInvocationList().Contains(AddNewEmployeeBirthdate))
            {
                newEmployee -= AddNewEmployeeBirthdate;
                stateNew -= 1;

            }
            CheckStateNew();
        }

        private void AddNewEmployeeBirthdate()
        {
            employeesDTO.AddEmployeeBirthdate(this.DtpBirthdate.Value.Date);
        }


        private void CheckStateNew()
        {
            if (stateNew <= 11)
            {
                this.BtnAddEmployee.Enabled = false;
            }
            else
            {
                this.BtnAddEmployee.Enabled = true;
            }

        }

        private void NewEmployeeGender()
        {
            employeesDTO.AddEmployeeGender(this.CmbxGender.Text);
        }

        private void EdditGender(Guid id)
        {
            employeesDTO.EdditGender(id, this.CmbxGender.Text);
        }



        private void checkStateUpdate()
        {
            if (stateEddit == 0)
            {
                this.BtnUpdateEmployee.Enabled = false;
            }
            else
            {
                this.BtnUpdateEmployee.Enabled = true;
            }
        }

        private void NewEmployeePEmail()
        {
            employeesDTO.AddEmployeePEmail(this.TbxPersonalEmail.Text);
        }
        private void EdditPersonalEmail(Guid id)
        {
            employeesDTO.EdditPersonalEmail(id, this.TbxPersonalEmail.Text);
        }


        private void NewEmployeeBankaccount()
        {
            employeesDTO.AddEmployeeBankaccount(this.TbxBankAccount.Text);
        }

        private void EdditBankaccount(Guid id)
        {
            employeesDTO.EdditBanccount(id, this.TbxBankAccount.Text);
        }


        private void AddEmployeePicture()
        {
            employeesDTO.AddEmployeePhotoUrl(this.TbxImageLink.Text);
        }



        private void NewEmployeeSSN()
        {
            employeesDTO.AddEmployeeSSN(this.TbxSSN.Text);
        }

        private void EdditSSN(Guid id)
        {
            employeesDTO.EdditSSN(id, this.TbxSSN.Text);
        }



        private void NewEmployeeRole()
        {
            employeesDTO.AddEmployeeRole(this.CmbxRole.Text);
        }

        private void EdditRole(Guid id)
        {
            employeesDTO.EdditRole(id, this.CmbxRole.Text);
        }


        private void NewEmployeePassword()
        {
            employeesDTO.AddEmployeePassword(this.TxbxPassword.Text);
        }

        private void EdditPassword(Guid id)
        {
            employeesDTO.EdditPassword(id, this.TxbxPassword.Text);
        }

        private void NudHourlyRate_Leave(object sender, EventArgs e)
        {

        }

        private void NewEmployeeHourlyRate()
        {
            employeesDTO.AddEmployeeHourlyRate(this.NudHourlyRate.Value);
        }

        private void EdditHourlyRate(Guid id)
        {
            employeesDTO.EdditHourlyRate(id, this.NudHourlyRate.Value);
        }



        private void NewEmployeeAdress()
        {
            employeesDTO.AddEmployeeAdress(this.TbxAdress.Text);
        }

        private void EdditAdress(Guid id)
        {

            employeesDTO.EdditAdress(id, this.TbxAdress.Text);
        }

        private void BtnRemEmpolyee_Click(object sender, EventArgs e)
        {
            employeesDTO.RemoveSelectedEmployee();
            ClearForm();
        }

        private void BtnNewEmployee_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void LsBxEmployees_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            int index = LsBxEmployees.IndexFromPoint(pt);

            if (index <= -1)
            {
                LsBxEmployees.SelectedItems.Clear();

            }

        }

        private void TbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (this.TbxSearch.Text.Length > 0)
            {
                List<Employee> filterEmployees = new List<Employee>();
                foreach (Employee employee in employeesDTO.Employees)
                {

                    if (employee.FirstName.ToLower().Contains(this.TbxSearch.Text.ToLower()))
                    {
                        filterEmployees.Add(employee);
                    }
                }
                this.LsBxEmployees.DataBindings.Clear();


                this.LsBxEmployees.DataSource = filterEmployees;
            }
            else
            {
                FillListBox();
            }
        }

        private void TbxFName_TextChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                if (this.TbxFName.Text.Length == 0)
                {
                    this.TbxFName.Text = employeesDTO.SelectedEmployee.FirstName;


                }
                if (this.TbxFName.Text != employeesDTO.SelectedEmployee.FirstName)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditFname))
                    {
                        updateEmployee += EdditFname;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditFname))
                    {
                        updateEmployee -= EdditFname;
                        stateEddit -= 1;
                    }
                }
                checkStateUpdate();

            }
            else
            {
                if (this.TbxFName.Text.Length == 0 || this.TbxFName.PlaceholderText == "please fill in a name")
                {
                    this.TbxFName.PlaceholderText = "please fill in a name";
                    if (newEmployee != null && newEmployee.GetInvocationList().Contains(NewEmployeeFName))
                    {
                        newEmployee -= NewEmployeeFName;
                        stateNew -= 1;
                    }
                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeeFName))
                    {
                        newEmployee += NewEmployeeFName;
                        stateNew += 1;
                    }
                }
                CheckStateNew();
            }
            EdditWorkEmail();
        }

        private void TbxLName_TextChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                if (this.TbxLName.Text.Length == 0)
                {
                    this.TbxLName.Text = employeesDTO.SelectedEmployee.LastName;


                }
                if (this.TbxLName.Text != employeesDTO.SelectedEmployee.LastName)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditLname))
                    {
                        updateEmployee += EdditLname;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditLname))
                    {
                        updateEmployee -= EdditLname;
                        stateEddit -= 1;
                    }
                }
                checkStateUpdate();
            }
            else
            {
                if (this.TbxLName.Text.Length == 0 || this.TbxLName.PlaceholderText == "please fill in a last name")
                {
                    this.TbxLName.PlaceholderText = "please fill in a last name";
                    if (newEmployee != null && newEmployee.GetInvocationList().Contains(NewEmployeeLName))
                    {
                        newEmployee -= NewEmployeeLName;
                        stateNew -= 1;
                    }
                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeeLName))
                    {
                        newEmployee += NewEmployeeLName;
                        stateNew += 1;
                    }
                }
                CheckStateNew();
            }
            EdditWorkEmail();
        }

        private void CmbxGender_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Gender gender = (Gender)this.CmbxGender.SelectedItem;
            if (selectedIndex != -1)
            {
                if (this.CmbxGender.SelectedIndex == -1)
                {
                    gender = employeesDTO.SelectedEmployee.Gender;


                }
                if (gender != employeesDTO.SelectedEmployee.Gender)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditGender))
                    {
                        updateEmployee += EdditGender;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditGender))
                    {
                        updateEmployee -= EdditGender;
                        stateEddit -= 1;
                    }

                }
                checkStateUpdate();
            }
            else
            {
                if (this.CmbxGender.SelectedIndex == -1)
                {
                    this.CmbxGender.Text = "please Select a gender";
                    if (newEmployee != null && newEmployee.GetInvocationList().Contains(NewEmployeeGender))
                    {
                        newEmployee -= NewEmployeeGender;
                        stateNew -= 1;
                    }

                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeeGender))
                    {
                        newEmployee += NewEmployeeGender;
                        stateNew += 1;
                    }
                }
                CheckStateNew();
            }
        }

        private void TbxPersonalEmail_TextChanged(object sender, EventArgs e)
        {



        }

        private void TbxAdress_TextChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                if (this.TbxAdress.Text.Length == 0)
                {
                    this.TbxAdress.Text = employeesDTO.SelectedEmployee.Address;


                }
                if (this.TbxAdress.Text != employeesDTO.SelectedEmployee.Address)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditAdress))
                    {
                        updateEmployee += EdditAdress;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditAdress))
                    {
                        updateEmployee -= EdditAdress;
                        stateEddit -= 1;
                    }

                }
                checkStateUpdate();

            }
            else
            {
                if (this.TbxAdress.Text.Length == 0 || this.TbxAdress.PlaceholderText == "please fill in proper adress")
                {
                    this.TbxAdress.PlaceholderText = "please fill in proper adress";
                    if (newEmployee != null && newEmployee.GetInvocationList().Contains(NewEmployeeAdress))
                    {
                        newEmployee -= NewEmployeeAdress;
                        stateNew -= 1;
                    }

                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeeAdress))
                    {
                        newEmployee += NewEmployeeAdress;
                        stateNew += 1;
                    }

                }
                CheckStateNew();
            }
        }

        private void TbxBankAccount_TextChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                if (this.TbxBankAccount.Text.Length == 0)
                {
                    this.TbxBankAccount.Text = employeesDTO.SelectedEmployee.BankAccount;


                }
                if (this.TbxBankAccount.Text != employeesDTO.SelectedEmployee.BankAccount)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditBankaccount))
                    {
                        updateEmployee += EdditBankaccount;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditBankaccount))
                    {
                        updateEmployee -= EdditBankaccount;
                        stateEddit -= 1;
                    }

                }
                checkStateUpdate();

            }
            else
            {
                if (this.TbxBankAccount.Text.Length == 0 || this.TbxBankAccount.PlaceholderText == "please fill in bank info")
                {
                    this.TbxBankAccount.PlaceholderText = "please fill in bank info";
                    if (newEmployee != null && newEmployee.GetInvocationList().Contains(NewEmployeeBankaccount))
                    {
                        newEmployee -= NewEmployeeBankaccount;
                        stateNew -= 1;
                    }

                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeeBankaccount))
                    {
                        newEmployee += NewEmployeeBankaccount;
                        stateNew += 1;
                    }
                }
                CheckStateNew();
            }
        }

        private void TbxSSN_TextChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                if (this.TbxSSN.Text.Length == 0)
                {
                    this.TbxSSN.Text = employeesDTO.SelectedEmployee.BankAccount;


                }
                if (this.TbxSSN.Text != employeesDTO.SelectedEmployee.Ssn)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditSSN))
                    {
                        updateEmployee += EdditSSN;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditSSN))
                    {
                        updateEmployee -= EdditSSN;
                        stateEddit -= 1;
                    }

                }
                checkStateUpdate();

            }
            else
            {
                if (this.TbxSSN.Text.Length == 0 || this.TbxSSN.PlaceholderText == "please fill in SSN")
                {
                    this.TbxSSN.PlaceholderText = "please fill in SSN";
                    if (newEmployee != null && newEmployee.GetInvocationList().Contains(NewEmployeeSSN))
                    {
                        newEmployee -= NewEmployeeSSN;
                        stateNew -= 1;
                    }

                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeeSSN))
                    {
                        newEmployee += NewEmployeeSSN;
                        stateNew += 1;
                    }

                }
                CheckStateNew();
            }
        }

        private void CmbxRole_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Role role = (Role)this.CmbxRole.SelectedItem;
            if (selectedIndex != -1)
            {
                if (this.CmbxRole.SelectedIndex == -1)
                {
                    role = employeesDTO.SelectedEmployee.Role;


                }
                if (role != employeesDTO.SelectedEmployee.Role)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditRole))
                    {
                        updateEmployee += EdditRole;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditRole))
                    {
                        updateEmployee -= EdditRole;
                        stateEddit -= 1;
                    }

                }
                checkStateUpdate();

            }
            else
            {
                if (this.CmbxRole.SelectedIndex == -1)
                {
                    this.CmbxRole.Text = "please fill in Role";
                    if (newEmployee != null && newEmployee.GetInvocationList().Contains(NewEmployeeRole))
                    {
                        newEmployee -= NewEmployeeRole;
                        stateNew -= 1;
                    }

                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeeRole))
                    {
                        newEmployee += NewEmployeeRole;
                        stateNew += 1;
                    }

                }
                CheckStateNew();
            }

        }

        private void NudHourlyRate_ValueChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                if (this.NudHourlyRate.Value < 14)
                {
                    this.NudHourlyRate.Value = employeesDTO.SelectedEmployee.HourlyRate;


                }
                if (this.NudHourlyRate.Value != employeesDTO.SelectedEmployee.HourlyRate)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditHourlyRate))
                    {
                        updateEmployee += EdditHourlyRate;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditHourlyRate))
                    {
                        updateEmployee -= EdditHourlyRate;
                        stateEddit -= 1;
                    }

                }
                checkStateUpdate();

            }
            else
            {
                if (this.NudHourlyRate.Value < 14)
                {
                    MessageBox.Show("please fill in proper salery");
                    if (newEmployee != null && newEmployee.GetInvocationList().Contains(NewEmployeeHourlyRate))
                    {
                        newEmployee -= NewEmployeeHourlyRate;
                        stateNew -= 1;
                    }

                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeeHourlyRate))
                    {
                        newEmployee += NewEmployeeHourlyRate;
                        stateNew += 1;
                    }

                }
                CheckStateNew();
            }
        }

        private void TxbxPassword_TextChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                if (this.TxbxPassword.Text.Length == 0)
                {
                    this.TxbxPassword.Text = "hidden";


                }
                if (this.TxbxPassword.Text != "hidden")
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditPassword))
                    {
                        updateEmployee += EdditPassword;
                        stateEddit += 1;
                    }
                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditPassword))
                    {
                        updateEmployee -= EdditPassword;
                        stateEddit -= 1;
                    }

                }
                checkStateUpdate();

            }
            else
            {
                if (this.TxbxPassword.Text.Length < 5 || this.TxbxPassword.Text.Contains(" "))
                {
                    this.TxbxPassword.PlaceholderText = "please fill in password";
                    if (newEmployee != null && newEmployee.GetInvocationList().Contains(NewEmployeePassword))
                    {
                        newEmployee -= NewEmployeePassword;
                        stateNew -= 1;
                    }

                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeePassword))
                    {
                        newEmployee += NewEmployeePassword;
                        stateNew += 1;
                    }

                }
                CheckStateNew();
            }
        }

        private void TbxPersonalEmail_Leave(object sender, EventArgs e)
        {
            Regex mailMatch = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = mailMatch.Match(this.TbxPersonalEmail.Text);
            if (match.Success)
            {
                if (selectedIndex != -1)
                {
                    if (this.TbxPersonalEmail.Text.Length == 0)
                    {
                        this.TbxPersonalEmail.Text = employeesDTO.SelectedEmployee.PersonalEmail;


                    }
                    if (this.TbxPersonalEmail.Text != employeesDTO.SelectedEmployee.PersonalEmail)
                    {
                        updateEmployee += EdditPersonalEmail;
                        stateEddit += 1;
                    }
                    else
                    {
                        if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditPersonalEmail))
                        {
                            updateEmployee -= EdditPersonalEmail;
                            stateEddit -= 1;
                        }

                    }
                    checkStateUpdate();

                }
                else
                {
                    if (newEmployee == null || !newEmployee.GetInvocationList().Contains(NewEmployeePEmail))
                    {


                        newEmployee += NewEmployeePEmail;
                        stateNew += 1;
                    }
                    CheckStateNew();
                }


            }
            else
            {
                if (this.TbxPersonalEmail.Text.Length != 0)
                {
                    MessageBox.Show("invalid email");
                }

            }
        }

        private void TbxImageLink_TextChanged(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                string url = this.TbxImageLink.Text;
                if (url != employeesDTO.SelectedEmployee.PhotoURL)
                {
                    if (updateEmployee == null || !updateEmployee.GetInvocationList().Contains(EdditPhotoUrl))
                    {

                        updateEmployee += EdditPhotoUrl;
                        stateEddit += 1;
                    }

                }
                else
                {
                    if (updateEmployee != null && updateEmployee.GetInvocationList().Contains(EdditPhotoUrl))
                    {
                        updateEmployee -= EdditPhotoUrl;
                        stateEddit -= 1;
                    }

                }
                checkStateUpdate();
            }
            else
            {
                if (newEmployee == null || !newEmployee.GetInvocationList().Contains(AddEmployeePicture))
                {
                    newEmployee += AddEmployeePicture;
                    stateNew += 1;
                }
                CheckStateNew();
            }
        }
    }
}


