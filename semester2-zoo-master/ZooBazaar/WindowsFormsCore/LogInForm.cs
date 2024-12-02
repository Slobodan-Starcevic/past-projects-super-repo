using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Models;
using WindowsFormsCore;
using WindowsFormsCore.DTO;

namespace WindowsFormApp
{
    public partial class LogInForm : Form
    {
        AccountDTO accountDTO;
        public LogInForm()
        {
            InitializeComponent();
            accountDTO = new AccountDTO();
            Clearform();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            string workemail = this.TxBxLogInEmail.Text;
            string password = this.TxBxLogInPassWord.Text;

            try
            {
                if (accountDTO.LogInAttempt(workemail, password))
                {
                    MessageBox.Show("your logged in");
                }
                else
                {
                    MessageBox.Show("failed to log in");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error incorrect info");
            }
            finally
            {
                Clearform();
            }

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Clearform();
        }

        private void Clearform()
        {
            this.TxBxLogInEmail.Clear();
            this.TxBxLogInPassWord.Clear();
        }


    }
}
