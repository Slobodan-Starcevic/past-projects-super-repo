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
using WindowsFormsCore;
using WindowsFormsCore.DTO;
namespace WindowsFormApp
{
    public partial class ProfileForm : Form
    {
        private delegate void EdditAccount(Guid id);
        private EdditAccount accountEddit;
        private AccountDTO accountDTO = new AccountDTO();
        private int stateEddit = 0;
        private delegate void EditAcount(Guid id);
        private EditAcount updateEmployee;

        private string filepath = GetFilePath(); //@"C:\myFiles\fontys folder\SEM 2 Documents\project_Group\Project\semester2-zoo\ZooBazaar\ZooBazaar_WebApp\wwwroot\media\pfp\";
        public ProfileForm()
        {
            InitializeComponent();
            this.DtpBirthdate.MaxDate = DateTime.Now;
            this.CmbxGender.DataSource = Enum.GetValues(typeof(Gender));
            this.CmbxRole.DataSource = Enum.GetValues(typeof(Role));

            //FillInForm();



        }
        private static string GetFilePath()
        {
            string directoryC = Environment.CurrentDirectory;
            string[] splt = directoryC.Split(new string[] { @"\WindowsFormsCore" }, StringSplitOptions.None);
            string path = Path.Combine(splt[0], @"ZooBazaar_WebApp\wwwroot\media\pfp\");


            return path;
        }

        private void FillInForm()
        {
            accountDTO.GetAccount(accountDTO.User.Id);
            this.TbxFName.Text = accountDTO.User.FirstName;
            this.TbxLName.Text = accountDTO.User.LastName;
            this.DtpBirthdate.Value = accountDTO.User.BirthDate.ToDateTime(TimeOnly.MinValue);
            this.CmbxGender.SelectedItem = accountDTO.User.Gender;
            this.TbxPersonalEmail.Text = accountDTO.User.PersonalEmail;
            this.TbxAdress.Text = accountDTO.User.Address;
            this.TbxBankAccount.Text = accountDTO.User.BankAccount;
            this.TbxSSN.Text = accountDTO.User.Ssn;
            this.CmbxRole.SelectedItem = accountDTO.User.Role;
            this.NudHourlyRate.Value = accountDTO.User.HourlyRate;
            this.TbxWorkemail.Text = accountDTO.User.WorkEmail;
            this.TbxImageLink.Text = accountDTO.User.PhotoURL;
        }

        private void BtnEdditInfo_Click(object sender, EventArgs e)
        {
            if (stateEddit != 0)
            {
                accountEddit(accountDTO.User.Id);
                MessageBox.Show($"{stateEddit} changes made");
                this.BtnEdditInfo.Enabled = false;
            }
            else
            {
                MessageBox.Show("no changes made");
            }

        }


        private void EdditPhotoUrl(Guid id)
        {
            accountDTO.EdditPhotoUrl(id, this.TbxImageLink.Text);
        }

        private void TbxSSN_Leave(object sender, EventArgs e)
        {

        }




        private void EdditSSN(Guid id)
        {
            accountDTO.EdditSSN(id, this.TbxSSN.Text);
        }

        private void TbxFName_Leave(object sender, EventArgs e)
        {


        }

        private void EdditWorkEmail()
        {

            this.TbxWorkemail.Text = $"{this.TbxFName.Text.Substring(0, 0)}.{this.TbxLName.Text}@Zoobazaar.nl";
            if (this.TbxWorkemail.Text != accountDTO.User.WorkEmail)
            {

                if (accountEddit == null || !accountEddit.GetInvocationList().Contains(EdditAccountWorkEmail))
                {
                    updateEmployee += EdditAccountWorkEmail;
                    stateEddit += 1;
                }
            }

            else
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditAccountWorkEmail))
                {
                    accountEddit -= EdditAccountWorkEmail;
                    stateEddit -= 1;
                }
            }
            CheckEdditState();

        }

        private void EdditAccountWorkEmail(Guid id)
        {
            accountDTO.EdditWorkEmail(id, this.TbxWorkemail.Text);
        }

        private void EdditFname(Guid id)
        {
            accountDTO.EdditFname(id, this.TbxFName.Text);
        }

        private void TbxLName_Leave(object sender, EventArgs e)
        {


        }

        private void EdditLname(Guid id)
        {
            accountDTO.EdditLname(id, this.TbxLName.Text);
        }

        private void EdditBirhtDate(Guid id)
        {
            accountDTO.EdditBirthDate(id, this.DtpBirthdate.Value.Date);
        }

        private void CmbxGender_Leave(object sender, EventArgs e)
        {
        }

        private void EdditGender(Guid id)
        {
            Gender gender = (Gender)this.CmbxGender.SelectedItem;
            accountDTO.EdditGender(id, gender)
        ;
        }


        private void EdditBankAccount(Guid id)
        {
            accountDTO.EdditBankAccount(id, this.TbxBankAccount.Text);
        }

        private void CmbxRole_Leave(object sender, EventArgs e)
        {

        }

        private void EdditRole(Guid id)
        {
            Role role = (Role)this.CmbxRole.SelectedItem;
            accountDTO.EdditRole(id, role);
        }

        private void BtnCancelEddit_Click(object sender, EventArgs e)
        {
            FillInForm();
        }

        private void LblPictureurl_TextChanged(object sender, EventArgs e)
        {


        }



        private void CheckEdditState()
        {
            if (stateEddit == 0)
            {
                this.BtnEdditInfo.Enabled = false;
            }
            else
            {
                this.BtnEdditInfo.Enabled = true;
            }
        }

        private void TbxFName_TextChanged(object sender, EventArgs e)
        {
            if (this.TbxFName.Text.Length == 0)
            {
                this.TbxFName.Text = accountDTO.User.FirstName;


            }
            if (this.TbxFName.Text != accountDTO.User.FirstName)
            {
                if (accountEddit == null || !accountEddit.GetInvocationList().Contains(EdditFname))
                {
                    accountEddit += EdditFname;
                    stateEddit += 1;
                }
            }
            else
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditFname))
                {
                    accountEddit -= EdditFname;
                    stateEddit -= 1;
                }
            }
            CheckEdditState();
            EdditWorkEmail();

        }

        private void TbxLName_TextChanged(object sender, EventArgs e)
        {
            if (this.TbxLName.Text.Length == 0)
            {
                this.TbxLName.Text = accountDTO.User.LastName;


            }
            if (this.TbxLName.Text != accountDTO.User.LastName)
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditLname))
                {
                    accountEddit += EdditLname;
                    stateEddit += 1;
                }
            }
            else
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditLname))
                {
                    accountEddit -= EdditLname;
                    stateEddit -= 1;
                }
            }
            CheckEdditState();
            EdditWorkEmail();

        }

        private void DtpBirthdate_ValueChanged(object sender, EventArgs e)
        {
            if (this.DtpBirthdate.Value.Date != accountDTO.User.BirthDate.ToDateTime(TimeOnly.MinValue).Date)
            {
                if (accountEddit == null || !accountEddit.GetInvocationList().Contains(EdditBirhtDate))
                {
                    accountEddit += EdditBirhtDate;
                    stateEddit += 1;
                }
            }
            else
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditBirhtDate))
                {
                    accountEddit -= EdditBirhtDate;
                    stateEddit -= 1;
                }
                CheckEdditState();
            }

        }

        private void CmbxGender_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Gender gender = (Gender)this.CmbxGender.SelectedItem;

            if (this.CmbxGender.Text.Length == 0)
            {
                this.CmbxGender.SelectedItem = accountDTO.User.Gender;


            }
            if (gender != accountDTO.User.Gender)
            {
                if (accountEddit == null || !accountEddit.GetInvocationList().Contains(EdditGender))
                {
                    accountEddit += EdditGender;
                    stateEddit += 1;
                }
            }
            else
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditGender))
                {
                    accountEddit -= EdditGender;
                    stateEddit -= 1;
                }
            }
            CheckEdditState();

        }

        private void TbxPersonalEmail_TextChanged(object sender, EventArgs e)
        {
            if (this.TbxPersonalEmail.Text.Length == 0)
            {
                this.TbxPersonalEmail.Text = accountDTO.User.PersonalEmail;


            }
            if (this.TbxPersonalEmail.Text != accountDTO.User.PersonalEmail)
            {
                if (accountEddit == null || !accountEddit.GetInvocationList().Contains(EdditPersonalEmail))
                {
                    accountEddit += EdditPersonalEmail;
                    stateEddit += 1;
                }
            }
            else
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditPersonalEmail))
                {
                    accountEddit -= EdditPersonalEmail;
                    stateEddit -= 1;
                }
                CheckEdditState();
            }
        }

        private void EdditPersonalEmail(Guid id)
        {
            string personalEmail = this.TbxPersonalEmail.Text;
            accountDTO.EdditPersonalEmail(personalEmail, id);
        }

        private void TbxAdress_TextChanged(object sender, EventArgs e)
        {
            if (this.TbxAdress.Text.Length == 0)
            {
                this.TbxAdress.Text = accountDTO.User.Address;


            }
            if (this.TbxAdress.Text != accountDTO.User.Address)
            {
                if (accountEddit == null || !accountEddit.GetInvocationList().Contains(EdditAdress))
                {
                    accountEddit += EdditAdress;
                    stateEddit += 1;
                }
            }
            else
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditAdress))
                {
                    accountEddit -= EdditAdress;
                    stateEddit -= 1;
                }

            }
            CheckEdditState();
        }

        private void EdditAdress(Guid id)
        {
            string adress = this.TbxAdress.Text;
            accountDTO.EdditPersonalEmail(adress, id);
        }

        private void TbxBankAccount_TextChanged(object sender, EventArgs e)
        {
            if (this.TbxBankAccount.Text.Length == 0)
            {
                this.TbxBankAccount.Text = accountDTO.User.BankAccount;


            }
            if (this.TbxBankAccount.Text != accountDTO.User.BankAccount)
            {
                if (accountEddit == null || !accountEddit.GetInvocationList().Contains(EdditBankAccount))
                {
                    accountEddit += EdditBankAccount;
                    stateEddit += 1;
                }
            }
            else
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditBankAccount))
                {
                    accountEddit -= EdditBankAccount;
                    stateEddit -= 1;
                }

            }
            CheckEdditState();
        }

        private void TbxSSN_TextChanged(object sender, EventArgs e)
        {
            if (this.TbxSSN.Text.Length == 0)
            {
                this.TbxSSN.Text = accountDTO.User.Ssn;


            }
            if (this.TbxSSN.Text != accountDTO.User.Ssn)
            {
                if (accountEddit == null || !accountEddit.GetInvocationList().Contains(EdditSSN))
                {
                    accountEddit += EdditSSN;
                    stateEddit += 1;
                }
            }
            else
            {

                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditSSN))
                {
                    accountEddit -= EdditSSN;
                    stateEddit -= 1;
                }
            }
            CheckEdditState();

        }

        private void CmbxRole_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Role role = (Role)this.CmbxRole.SelectedItem;

            if (this.CmbxRole.SelectedIndex == -1)
            {
                this.CmbxRole.SelectedItem = accountDTO.User.Role;


            }
            if (role != accountDTO.User.Role)
            {
                if (accountEddit == null || !accountEddit.GetInvocationList().Contains(EdditRole))
                {
                    accountEddit += EdditRole;
                    stateEddit += 1;
                }
            }
            else
            {
                if (accountEddit != null && accountEddit.GetInvocationList().Contains(EdditRole))
                {
                    accountEddit -= EdditRole;
                    stateEddit -= 1;
                }
            }
            CheckEdditState();


        }

        private void TbxImageLink_TextChanged(object sender, EventArgs e)
        {
            string url = this.TbxImageLink.Text;
            if (url != accountDTO.User.PhotoURL)
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
            CheckEdditState();

        }

        private void LblBirthDate_Click(object sender, EventArgs e)
        {

        }

        private void LblGender_Click(object sender, EventArgs e)
        {

        }

        private void CmbxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
