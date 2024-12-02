namespace WindowsFormApp
{
    partial class AddEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LsBxEmployees = new ListBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            TbxImageLink = new TextBox();
            textBox1 = new TextBox();
            TbxAdress = new TextBox();
            LblAdress = new Label();
            TxbxPassword = new TextBox();
            LblPass = new Label();
            TbxWorkemail = new TextBox();
            NudHourlyRate = new NumericUpDown();
            CmbxRole = new ComboBox();
            TbxSSN = new TextBox();
            TbxBankAccount = new TextBox();
            TbxPersonalEmail = new TextBox();
            CmbxGender = new ComboBox();
            DtpBirthdate = new DateTimePicker();
            TbxLName = new TextBox();
            TbxFName = new TextBox();
            LblBankAccount = new Label();
            LblPEmail = new Label();
            LblWorkEmail = new Label();
            label7 = new Label();
            LblRole = new Label();
            LblGender = new Label();
            LblBirthDate = new Label();
            LblSSN = new Label();
            LblLName = new Label();
            LblFname = new Label();
            BtnAddEmployee = new Button();
            BtnCancel = new Button();
            BtnUpdateEmployee = new Button();
            BtnNewEmployee = new Button();
            BtnRemEmpolyee = new Button();
            label1 = new Label();
            TbxSearch = new TextBox();
            BtnClearSearch = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NudHourlyRate).BeginInit();
            SuspendLayout();
            // 
            // LsBxEmployees
            // 
            LsBxEmployees.FormattingEnabled = true;
            LsBxEmployees.ItemHeight = 15;
            LsBxEmployees.Location = new Point(14, 44);
            LsBxEmployees.Margin = new Padding(4, 3, 4, 3);
            LsBxEmployees.Name = "LsBxEmployees";
            LsBxEmployees.Size = new Size(325, 394);
            LsBxEmployees.TabIndex = 0;
            LsBxEmployees.MouseClick += LsBxEmployees_MouseClick;
            LsBxEmployees.MouseDown += LsBxEmployees_MouseDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(TbxImageLink);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(TbxAdress);
            groupBox1.Controls.Add(LblAdress);
            groupBox1.Controls.Add(TxbxPassword);
            groupBox1.Controls.Add(LblPass);
            groupBox1.Controls.Add(TbxWorkemail);
            groupBox1.Controls.Add(NudHourlyRate);
            groupBox1.Controls.Add(CmbxRole);
            groupBox1.Controls.Add(TbxSSN);
            groupBox1.Controls.Add(TbxBankAccount);
            groupBox1.Controls.Add(TbxPersonalEmail);
            groupBox1.Controls.Add(CmbxGender);
            groupBox1.Controls.Add(DtpBirthdate);
            groupBox1.Controls.Add(TbxLName);
            groupBox1.Controls.Add(TbxFName);
            groupBox1.Controls.Add(LblBankAccount);
            groupBox1.Controls.Add(LblPEmail);
            groupBox1.Controls.Add(LblWorkEmail);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(LblRole);
            groupBox1.Controls.Add(LblGender);
            groupBox1.Controls.Add(LblBirthDate);
            groupBox1.Controls.Add(LblSSN);
            groupBox1.Controls.Add(LblLName);
            groupBox1.Controls.Add(LblFname);
            groupBox1.Location = new Point(360, 14);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(438, 362);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Employee info form";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(227, 33);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 52;
            label2.Text = "Profile photo link";
            // 
            // TbxImageLink
            // 
            TbxImageLink.Location = new Point(227, 60);
            TbxImageLink.Name = "TbxImageLink";
            TbxImageLink.PlaceholderText = "Please paste image link here";
            TbxImageLink.Size = new Size(195, 23);
            TbxImageLink.TabIndex = 27;
            TbxImageLink.TextChanged += TbxImageLink_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(133, 396);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 26;
            // 
            // TbxAdress
            // 
            TbxAdress.Location = new Point(92, 180);
            TbxAdress.Margin = new Padding(4, 3, 4, 3);
            TbxAdress.Name = "TbxAdress";
            TbxAdress.Size = new Size(223, 23);
            TbxAdress.TabIndex = 6;
            TbxAdress.TextChanged += TbxAdress_TextChanged;
            // 
            // LblAdress
            // 
            LblAdress.AutoSize = true;
            LblAdress.Location = new Point(8, 185);
            LblAdress.Margin = new Padding(4, 0, 4, 0);
            LblAdress.Name = "LblAdress";
            LblAdress.Size = new Size(45, 15);
            LblAdress.TabIndex = 25;
            LblAdress.Text = "Adress:";
            // 
            // TxbxPassword
            // 
            TxbxPassword.Location = new Point(305, 273);
            TxbxPassword.Name = "TxbxPassword";
            TxbxPassword.Size = new Size(100, 23);
            TxbxPassword.TabIndex = 10;
            TxbxPassword.TextChanged += TxbxPassword_TextChanged;
            // 
            // LblPass
            // 
            LblPass.AutoSize = true;
            LblPass.Location = new Point(239, 275);
            LblPass.Name = "LblPass";
            LblPass.Size = new Size(60, 15);
            LblPass.TabIndex = 23;
            LblPass.Text = "Password:";
            // 
            // TbxWorkemail
            // 
            TbxWorkemail.Enabled = false;
            TbxWorkemail.Location = new Point(92, 333);
            TbxWorkemail.Margin = new Padding(4, 3, 4, 3);
            TbxWorkemail.Name = "TbxWorkemail";
            TbxWorkemail.Size = new Size(313, 23);
            TbxWorkemail.TabIndex = 12;
            // 
            // NudHourlyRate
            // 
            NudHourlyRate.DecimalPlaces = 2;
            NudHourlyRate.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            NudHourlyRate.Location = new Point(93, 303);
            NudHourlyRate.Margin = new Padding(4, 3, 4, 3);
            NudHourlyRate.Minimum = new decimal(new int[] { 14, 0, 0, 0 });
            NudHourlyRate.Name = "NudHourlyRate";
            NudHourlyRate.Size = new Size(140, 23);
            NudHourlyRate.TabIndex = 11;
            NudHourlyRate.Value = new decimal(new int[] { 14, 0, 0, 0 });
            NudHourlyRate.ValueChanged += NudHourlyRate_ValueChanged;
            // 
            // CmbxRole
            // 
            CmbxRole.AllowDrop = true;
            CmbxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbxRole.FormattingEnabled = true;
            CmbxRole.Location = new Point(92, 272);
            CmbxRole.Margin = new Padding(4, 3, 4, 3);
            CmbxRole.Name = "CmbxRole";
            CmbxRole.Size = new Size(140, 23);
            CmbxRole.TabIndex = 9;
            CmbxRole.SelectionChangeCommitted += CmbxRole_SelectionChangeCommitted;
            // 
            // TbxSSN
            // 
            TbxSSN.Location = new Point(92, 242);
            TbxSSN.Margin = new Padding(4, 3, 4, 3);
            TbxSSN.Name = "TbxSSN";
            TbxSSN.Size = new Size(223, 23);
            TbxSSN.TabIndex = 8;
            TbxSSN.TextChanged += TbxSSN_TextChanged;
            // 
            // TbxBankAccount
            // 
            TbxBankAccount.Location = new Point(92, 212);
            TbxBankAccount.Margin = new Padding(4, 3, 4, 3);
            TbxBankAccount.Name = "TbxBankAccount";
            TbxBankAccount.Size = new Size(223, 23);
            TbxBankAccount.TabIndex = 7;
            TbxBankAccount.TextChanged += TbxBankAccount_TextChanged;
            // 
            // TbxPersonalEmail
            // 
            TbxPersonalEmail.Location = new Point(92, 151);
            TbxPersonalEmail.Margin = new Padding(4, 3, 4, 3);
            TbxPersonalEmail.Name = "TbxPersonalEmail";
            TbxPersonalEmail.Size = new Size(223, 23);
            TbxPersonalEmail.TabIndex = 5;
            TbxPersonalEmail.Leave += TbxPersonalEmail_Leave;
            // 
            // CmbxGender
            // 
            CmbxGender.AutoCompleteCustomSource.AddRange(new string[] { "Male", "Female", "Other", "Rather not say" });
            CmbxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbxGender.FormattingEnabled = true;
            CmbxGender.Items.AddRange(new object[] { "Male", "Female", "Other", "Rather not say" });
            CmbxGender.Location = new Point(92, 120);
            CmbxGender.Margin = new Padding(4, 3, 4, 3);
            CmbxGender.Name = "CmbxGender";
            CmbxGender.Size = new Size(116, 23);
            CmbxGender.TabIndex = 4;
            CmbxGender.SelectionChangeCommitted += CmbxGender_SelectionChangeCommitted;
            // 
            // DtpBirthdate
            // 
            DtpBirthdate.Format = DateTimePickerFormat.Short;
            DtpBirthdate.Location = new Point(92, 90);
            DtpBirthdate.Margin = new Padding(4, 3, 4, 3);
            DtpBirthdate.MaxDate = new DateTime(2023, 3, 14, 10, 54, 47, 0);
            DtpBirthdate.Name = "DtpBirthdate";
            DtpBirthdate.Size = new Size(116, 23);
            DtpBirthdate.TabIndex = 3;
            DtpBirthdate.Value = new DateTime(2023, 3, 14, 0, 0, 0, 0);
            DtpBirthdate.Leave += DtpBirthdate_Leave;
            // 
            // TbxLName
            // 
            TbxLName.Location = new Point(92, 60);
            TbxLName.Margin = new Padding(4, 3, 4, 3);
            TbxLName.Name = "TbxLName";
            TbxLName.Size = new Size(116, 23);
            TbxLName.TabIndex = 2;
            TbxLName.TextChanged += TbxLName_TextChanged;
            // 
            // TbxFName
            // 
            TbxFName.Location = new Point(92, 30);
            TbxFName.Margin = new Padding(4, 3, 4, 3);
            TbxFName.Name = "TbxFName";
            TbxFName.Size = new Size(116, 23);
            TbxFName.TabIndex = 1;
            TbxFName.TextChanged += TbxFName_TextChanged;
            // 
            // LblBankAccount
            // 
            LblBankAccount.AutoSize = true;
            LblBankAccount.Location = new Point(7, 216);
            LblBankAccount.Margin = new Padding(4, 0, 4, 0);
            LblBankAccount.Name = "LblBankAccount";
            LblBankAccount.Size = new Size(79, 15);
            LblBankAccount.TabIndex = 10;
            LblBankAccount.Text = "Bankaccount:";
            // 
            // LblPEmail
            // 
            LblPEmail.AutoSize = true;
            LblPEmail.Location = new Point(7, 155);
            LblPEmail.Margin = new Padding(4, 0, 4, 0);
            LblPEmail.Name = "LblPEmail";
            LblPEmail.Size = new Size(39, 15);
            LblPEmail.TabIndex = 9;
            LblPEmail.Text = "Email:";
            // 
            // LblWorkEmail
            // 
            LblWorkEmail.AutoSize = true;
            LblWorkEmail.Location = new Point(7, 337);
            LblWorkEmail.Margin = new Padding(4, 0, 4, 0);
            LblWorkEmail.Name = "LblWorkEmail";
            LblWorkEmail.Size = new Size(70, 15);
            LblWorkEmail.TabIndex = 8;
            LblWorkEmail.Text = "Work email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 306);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 7;
            label7.Text = "HourlyRate: €";
            // 
            // LblRole
            // 
            LblRole.AutoSize = true;
            LblRole.Location = new Point(7, 276);
            LblRole.Margin = new Padding(4, 0, 4, 0);
            LblRole.Name = "LblRole";
            LblRole.Size = new Size(33, 15);
            LblRole.TabIndex = 6;
            LblRole.Text = "Role:";
            // 
            // LblGender
            // 
            LblGender.AutoSize = true;
            LblGender.Location = new Point(7, 123);
            LblGender.Margin = new Padding(4, 0, 4, 0);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(48, 15);
            LblGender.TabIndex = 5;
            LblGender.Text = "Gender:";
            // 
            // LblBirthDate
            // 
            LblBirthDate.AutoSize = true;
            LblBirthDate.Location = new Point(7, 97);
            LblBirthDate.Margin = new Padding(4, 0, 4, 0);
            LblBirthDate.Name = "LblBirthDate";
            LblBirthDate.Size = new Size(58, 15);
            LblBirthDate.TabIndex = 4;
            LblBirthDate.Text = "Birthdate:";
            // 
            // LblSSN
            // 
            LblSSN.AutoSize = true;
            LblSSN.Location = new Point(7, 246);
            LblSSN.Margin = new Padding(4, 0, 4, 0);
            LblSSN.Name = "LblSSN";
            LblSSN.Size = new Size(31, 15);
            LblSSN.TabIndex = 2;
            LblSSN.Text = "SSN:";
            // 
            // LblLName
            // 
            LblLName.AutoSize = true;
            LblLName.Location = new Point(7, 63);
            LblLName.Margin = new Padding(4, 0, 4, 0);
            LblLName.Name = "LblLName";
            LblLName.Size = new Size(64, 15);
            LblLName.TabIndex = 1;
            LblLName.Text = "Last name:";
            // 
            // LblFname
            // 
            LblFname.AutoSize = true;
            LblFname.BackColor = Color.FromArgb(46, 51, 73);
            LblFname.Location = new Point(7, 33);
            LblFname.Margin = new Padding(4, 0, 4, 0);
            LblFname.Name = "LblFname";
            LblFname.Size = new Size(65, 15);
            LblFname.TabIndex = 0;
            LblFname.Text = "First name:";
            // 
            // BtnAddEmployee
            // 
            BtnAddEmployee.BackColor = Color.FromArgb(24, 30, 54);
            BtnAddEmployee.Enabled = false;
            BtnAddEmployee.FlatAppearance.BorderSize = 0;
            BtnAddEmployee.FlatStyle = FlatStyle.Flat;
            BtnAddEmployee.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddEmployee.ForeColor = SystemColors.Control;
            BtnAddEmployee.Location = new Point(360, 382);
            BtnAddEmployee.Margin = new Padding(4, 3, 4, 3);
            BtnAddEmployee.Name = "BtnAddEmployee";
            BtnAddEmployee.Size = new Size(127, 27);
            BtnAddEmployee.TabIndex = 22;
            BtnAddEmployee.Text = "Add employee";
            BtnAddEmployee.UseVisualStyleBackColor = false;
            BtnAddEmployee.Click += BtnAddEmployee_Click_1;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.FromArgb(24, 30, 54);
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatStyle = FlatStyle.Flat;
            BtnCancel.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnCancel.ForeColor = SystemColors.Control;
            BtnCancel.Location = new Point(671, 382);
            BtnCancel.Margin = new Padding(4, 3, 4, 3);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(127, 27);
            BtnCancel.TabIndex = 23;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click_1;
            // 
            // BtnUpdateEmployee
            // 
            BtnUpdateEmployee.BackColor = Color.FromArgb(24, 30, 54);
            BtnUpdateEmployee.Enabled = false;
            BtnUpdateEmployee.FlatAppearance.BorderSize = 0;
            BtnUpdateEmployee.FlatStyle = FlatStyle.Flat;
            BtnUpdateEmployee.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnUpdateEmployee.ForeColor = SystemColors.Control;
            BtnUpdateEmployee.Location = new Point(495, 382);
            BtnUpdateEmployee.Margin = new Padding(4, 3, 4, 3);
            BtnUpdateEmployee.Name = "BtnUpdateEmployee";
            BtnUpdateEmployee.Size = new Size(135, 27);
            BtnUpdateEmployee.TabIndex = 24;
            BtnUpdateEmployee.Text = "Update employee";
            BtnUpdateEmployee.UseVisualStyleBackColor = false;
            BtnUpdateEmployee.Visible = false;
            BtnUpdateEmployee.Click += BtnUpdateEmployee_Click;
            // 
            // BtnNewEmployee
            // 
            BtnNewEmployee.BackColor = Color.FromArgb(24, 30, 54);
            BtnNewEmployee.Enabled = false;
            BtnNewEmployee.FlatAppearance.BorderSize = 0;
            BtnNewEmployee.FlatStyle = FlatStyle.Flat;
            BtnNewEmployee.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnNewEmployee.ForeColor = SystemColors.Control;
            BtnNewEmployee.Location = new Point(360, 411);
            BtnNewEmployee.Margin = new Padding(4, 3, 4, 3);
            BtnNewEmployee.Name = "BtnNewEmployee";
            BtnNewEmployee.Size = new Size(127, 27);
            BtnNewEmployee.TabIndex = 25;
            BtnNewEmployee.Text = "New employee";
            BtnNewEmployee.UseVisualStyleBackColor = false;
            BtnNewEmployee.Visible = false;
            BtnNewEmployee.Click += BtnNewEmployee_Click;
            // 
            // BtnRemEmpolyee
            // 
            BtnRemEmpolyee.BackColor = Color.FromArgb(24, 30, 54);
            BtnRemEmpolyee.Enabled = false;
            BtnRemEmpolyee.FlatAppearance.BorderSize = 0;
            BtnRemEmpolyee.FlatStyle = FlatStyle.Flat;
            BtnRemEmpolyee.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnRemEmpolyee.ForeColor = SystemColors.Control;
            BtnRemEmpolyee.Location = new Point(495, 411);
            BtnRemEmpolyee.Margin = new Padding(4, 3, 4, 3);
            BtnRemEmpolyee.Name = "BtnRemEmpolyee";
            BtnRemEmpolyee.Size = new Size(135, 27);
            BtnRemEmpolyee.TabIndex = 26;
            BtnRemEmpolyee.Text = "Remove employee";
            BtnRemEmpolyee.UseVisualStyleBackColor = false;
            BtnRemEmpolyee.Visible = false;
            BtnRemEmpolyee.Click += BtnRemEmpolyee_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 18);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 28;
            label1.Text = "Search :";
            // 
            // TbxSearch
            // 
            TbxSearch.Location = new Point(69, 15);
            TbxSearch.Name = "TbxSearch";
            TbxSearch.Size = new Size(100, 23);
            TbxSearch.TabIndex = 27;
            TbxSearch.TextChanged += TbxSearch_TextChanged;
            // 
            // BtnClearSearch
            // 
            BtnClearSearch.BackColor = Color.FromArgb(24, 30, 54);
            BtnClearSearch.FlatAppearance.BorderSize = 0;
            BtnClearSearch.FlatStyle = FlatStyle.Flat;
            BtnClearSearch.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnClearSearch.ForeColor = SystemColors.Control;
            BtnClearSearch.Location = new Point(175, 15);
            BtnClearSearch.Name = "BtnClearSearch";
            BtnClearSearch.Size = new Size(75, 23);
            BtnClearSearch.TabIndex = 29;
            BtnClearSearch.Text = "Clear";
            BtnClearSearch.UseVisualStyleBackColor = false;
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(812, 448);
            Controls.Add(BtnClearSearch);
            Controls.Add(label1);
            Controls.Add(TbxSearch);
            Controls.Add(BtnRemEmpolyee);
            Controls.Add(BtnNewEmployee);
            Controls.Add(BtnUpdateEmployee);
            Controls.Add(BtnCancel);
            Controls.Add(BtnAddEmployee);
            Controls.Add(groupBox1);
            Controls.Add(LsBxEmployees);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddEmployeeForm";
            Text = "AddEmployeeForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NudHourlyRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox LsBxEmployees;
        private GroupBox groupBox1;
        private ComboBox CmbxRole;
        private TextBox TbxSSN;
        private TextBox TbxBankAccount;
        private TextBox TbxPersonalEmail;
        private ComboBox CmbxGender;
        private DateTimePicker DtpBirthdate;
        private TextBox TbxLName;
        private TextBox TbxFName;
        private Label LblBankAccount;
        private Label LblPEmail;
        private Label LblWorkEmail;
        private Label label7;
        private Label LblRole;
        private Label LblGender;
        private Label LblBirthDate;
        private Label LblSSN;
        private Label LblLName;
        private Label LblFname;
        private TextBox TbxWorkemail;
        private NumericUpDown NudHourlyRate;
        private Button BtnAddEmployee;
        private Button BtnCancel;
        private Button BtnUpdateEmployee;
        private TextBox TxbxPassword;
        private Label LblPass;
        private Button BtnNewEmployee;
        private TextBox TbxAdress;
        private Label LblAdress;
        private Button BtnRemEmpolyee;
        private Label label1;
        private TextBox TbxSearch;
        private Button BtnClearSearch;
        private TextBox TbxImageLink;
        private TextBox textBox1;
        private Label label2;
    }
}