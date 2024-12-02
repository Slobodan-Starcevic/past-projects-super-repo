namespace WindowsFormApp
{
    partial class ProfileForm
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
            BtnEdditInfo = new Button();
            BtnCancelEddit = new Button();
            TbxAdress = new TextBox();
            LblAdress = new Label();
            label1 = new Label();
            TbxImageLink = new TextBox();
            ((System.ComponentModel.ISupportInitialize)NudHourlyRate).BeginInit();
            SuspendLayout();
            // 
            // TbxWorkemail
            // 
            TbxWorkemail.Enabled = false;
            TbxWorkemail.Location = new Point(387, 288);
            TbxWorkemail.Margin = new Padding(4, 3, 4, 3);
            TbxWorkemail.Name = "TbxWorkemail";
            TbxWorkemail.Size = new Size(232, 23);
            TbxWorkemail.TabIndex = 43;
            // 
            // NudHourlyRate
            // 
            NudHourlyRate.DecimalPlaces = 2;
            NudHourlyRate.Enabled = false;
            NudHourlyRate.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            NudHourlyRate.Location = new Point(388, 241);
            NudHourlyRate.Margin = new Padding(4, 3, 4, 3);
            NudHourlyRate.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            NudHourlyRate.Name = "NudHourlyRate";
            NudHourlyRate.Size = new Size(231, 23);
            NudHourlyRate.TabIndex = 42;
            NudHourlyRate.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // CmbxRole
            // 
            CmbxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbxRole.Enabled = false;
            CmbxRole.FormattingEnabled = true;
            CmbxRole.Items.AddRange(new object[] { "Zoo_CareTaker", "Admin", "Planner", "Manager" });
            CmbxRole.Location = new Point(388, 178);
            CmbxRole.Margin = new Padding(4, 3, 4, 3);
            CmbxRole.Name = "CmbxRole";
            CmbxRole.Size = new Size(231, 23);
            CmbxRole.TabIndex = 41;
            CmbxRole.SelectionChangeCommitted += CmbxRole_SelectionChangeCommitted;
            CmbxRole.Leave += CmbxRole_Leave;
            // 
            // TbxSSN
            // 
            TbxSSN.Location = new Point(387, 119);
            TbxSSN.Margin = new Padding(4, 3, 4, 3);
            TbxSSN.Name = "TbxSSN";
            TbxSSN.Size = new Size(232, 23);
            TbxSSN.TabIndex = 40;
            TbxSSN.TextChanged += TbxSSN_TextChanged;
            // 
            // TbxBankAccount
            // 
            TbxBankAccount.Location = new Point(388, 62);
            TbxBankAccount.Margin = new Padding(4, 3, 4, 3);
            TbxBankAccount.Name = "TbxBankAccount";
            TbxBankAccount.Size = new Size(231, 23);
            TbxBankAccount.TabIndex = 39;
            TbxBankAccount.TextChanged += TbxBankAccount_TextChanged;
            // 
            // TbxPersonalEmail
            // 
            TbxPersonalEmail.Location = new Point(65, 288);
            TbxPersonalEmail.Margin = new Padding(4, 3, 4, 3);
            TbxPersonalEmail.Name = "TbxPersonalEmail";
            TbxPersonalEmail.Size = new Size(232, 23);
            TbxPersonalEmail.TabIndex = 38;
            TbxPersonalEmail.TextChanged += TbxPersonalEmail_TextChanged;
            // 
            // CmbxGender
            // 
            CmbxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbxGender.FormattingEnabled = true;
            CmbxGender.Items.AddRange(new object[] { "Male", "Female", "Other", "Rather_not_say" });
            CmbxGender.Location = new Point(65, 240);
            CmbxGender.Margin = new Padding(4, 3, 4, 3);
            CmbxGender.Name = "CmbxGender";
            CmbxGender.Size = new Size(232, 23);
            CmbxGender.TabIndex = 37;
            CmbxGender.SelectedIndexChanged += CmbxGender_SelectedIndexChanged;
            CmbxGender.SelectionChangeCommitted += CmbxGender_SelectionChangeCommitted;
            // 
            // DtpBirthdate
            // 
            DtpBirthdate.Format = DateTimePickerFormat.Short;
            DtpBirthdate.Location = new Point(65, 178);
            DtpBirthdate.Margin = new Padding(4, 3, 4, 3);
            DtpBirthdate.MaxDate = new DateTime(2023, 3, 14, 10, 54, 47, 0);
            DtpBirthdate.Name = "DtpBirthdate";
            DtpBirthdate.Size = new Size(232, 23);
            DtpBirthdate.TabIndex = 36;
            DtpBirthdate.Value = new DateTime(2023, 3, 14, 0, 0, 0, 0);
            DtpBirthdate.ValueChanged += DtpBirthdate_ValueChanged;
            // 
            // TbxLName
            // 
            TbxLName.Location = new Point(65, 119);
            TbxLName.Margin = new Padding(4, 3, 4, 3);
            TbxLName.Name = "TbxLName";
            TbxLName.Size = new Size(232, 23);
            TbxLName.TabIndex = 35;
            TbxLName.TextChanged += TbxLName_TextChanged;
            // 
            // TbxFName
            // 
            TbxFName.Location = new Point(65, 62);
            TbxFName.Margin = new Padding(4, 3, 4, 3);
            TbxFName.Name = "TbxFName";
            TbxFName.Size = new Size(232, 23);
            TbxFName.TabIndex = 34;
            TbxFName.TextChanged += TbxFName_TextChanged;
            // 
            // LblBankAccount
            // 
            LblBankAccount.AutoSize = true;
            LblBankAccount.ForeColor = Color.White;
            LblBankAccount.Location = new Point(388, 44);
            LblBankAccount.Margin = new Padding(4, 0, 4, 0);
            LblBankAccount.Name = "LblBankAccount";
            LblBankAccount.Size = new Size(79, 15);
            LblBankAccount.TabIndex = 33;
            LblBankAccount.Text = "Bankaccount:";
            // 
            // LblPEmail
            // 
            LblPEmail.AutoSize = true;
            LblPEmail.ForeColor = Color.White;
            LblPEmail.Location = new Point(65, 270);
            LblPEmail.Margin = new Padding(4, 0, 4, 0);
            LblPEmail.Name = "LblPEmail";
            LblPEmail.Size = new Size(39, 15);
            LblPEmail.TabIndex = 32;
            LblPEmail.Text = "Email:";
            // 
            // LblWorkEmail
            // 
            LblWorkEmail.AutoSize = true;
            LblWorkEmail.ForeColor = Color.White;
            LblWorkEmail.Location = new Point(387, 270);
            LblWorkEmail.Margin = new Padding(4, 0, 4, 0);
            LblWorkEmail.Name = "LblWorkEmail";
            LblWorkEmail.Size = new Size(70, 15);
            LblWorkEmail.TabIndex = 31;
            LblWorkEmail.Text = "Work email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(388, 223);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 30;
            label7.Text = "HourlyRate: €";
            // 
            // LblRole
            // 
            LblRole.AutoSize = true;
            LblRole.ForeColor = Color.White;
            LblRole.Location = new Point(388, 160);
            LblRole.Margin = new Padding(4, 0, 4, 0);
            LblRole.Name = "LblRole";
            LblRole.Size = new Size(33, 15);
            LblRole.TabIndex = 29;
            LblRole.Text = "Role:";
            // 
            // LblGender
            // 
            LblGender.AutoSize = true;
            LblGender.ForeColor = Color.White;
            LblGender.Location = new Point(65, 217);
            LblGender.Margin = new Padding(4, 0, 4, 0);
            LblGender.Name = "LblGender";
            LblGender.Size = new Size(48, 15);
            LblGender.TabIndex = 28;
            LblGender.Text = "Gender:";
            LblGender.Click += LblGender_Click;
            // 
            // LblBirthDate
            // 
            LblBirthDate.AutoSize = true;
            LblBirthDate.ForeColor = Color.White;
            LblBirthDate.Location = new Point(65, 159);
            LblBirthDate.Margin = new Padding(4, 0, 4, 0);
            LblBirthDate.Name = "LblBirthDate";
            LblBirthDate.Size = new Size(58, 15);
            LblBirthDate.TabIndex = 27;
            LblBirthDate.Text = "Birthdate:";
            LblBirthDate.Click += LblBirthDate_Click;
            // 
            // LblSSN
            // 
            LblSSN.AutoSize = true;
            LblSSN.ForeColor = Color.White;
            LblSSN.Location = new Point(387, 101);
            LblSSN.Margin = new Padding(4, 0, 4, 0);
            LblSSN.Name = "LblSSN";
            LblSSN.Size = new Size(31, 15);
            LblSSN.TabIndex = 25;
            LblSSN.Text = "SSN:";
            // 
            // LblLName
            // 
            LblLName.AutoSize = true;
            LblLName.ForeColor = Color.White;
            LblLName.Location = new Point(66, 92);
            LblLName.Margin = new Padding(4, 0, 4, 0);
            LblLName.Name = "LblLName";
            LblLName.Size = new Size(64, 15);
            LblLName.TabIndex = 24;
            LblLName.Text = "Last name:";
            // 
            // LblFname
            // 
            LblFname.AutoSize = true;
            LblFname.BackColor = Color.FromArgb(46, 51, 73);
            LblFname.ForeColor = Color.White;
            LblFname.Location = new Point(65, 44);
            LblFname.Margin = new Padding(4, 0, 4, 0);
            LblFname.Name = "LblFname";
            LblFname.Size = new Size(65, 15);
            LblFname.TabIndex = 23;
            LblFname.Text = "First name:";
            // 
            // BtnEdditInfo
            // 
            BtnEdditInfo.BackColor = Color.FromArgb(24, 30, 54);
            BtnEdditInfo.FlatAppearance.BorderSize = 0;
            BtnEdditInfo.FlatStyle = FlatStyle.Flat;
            BtnEdditInfo.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnEdditInfo.ForeColor = Color.White;
            BtnEdditInfo.Location = new Point(678, 276);
            BtnEdditInfo.Margin = new Padding(4, 3, 4, 3);
            BtnEdditInfo.Name = "BtnEdditInfo";
            BtnEdditInfo.Size = new Size(111, 44);
            BtnEdditInfo.TabIndex = 46;
            BtnEdditInfo.Text = "Edit info";
            BtnEdditInfo.UseVisualStyleBackColor = false;
            BtnEdditInfo.Click += BtnEdditInfo_Click;
            // 
            // BtnCancelEddit
            // 
            BtnCancelEddit.BackColor = Color.FromArgb(24, 30, 54);
            BtnCancelEddit.FlatAppearance.BorderSize = 0;
            BtnCancelEddit.FlatStyle = FlatStyle.Flat;
            BtnCancelEddit.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnCancelEddit.ForeColor = SystemColors.Control;
            BtnCancelEddit.Location = new Point(678, 329);
            BtnCancelEddit.Margin = new Padding(4, 3, 4, 3);
            BtnCancelEddit.Name = "BtnCancelEddit";
            BtnCancelEddit.Size = new Size(111, 45);
            BtnCancelEddit.TabIndex = 47;
            BtnCancelEddit.Text = "Cancel";
            BtnCancelEddit.UseVisualStyleBackColor = false;
            BtnCancelEddit.Visible = false;
            BtnCancelEddit.Click += BtnCancelEddit_Click;
            // 
            // TbxAdress
            // 
            TbxAdress.Location = new Point(65, 347);
            TbxAdress.Margin = new Padding(4, 3, 4, 3);
            TbxAdress.Name = "TbxAdress";
            TbxAdress.Size = new Size(232, 23);
            TbxAdress.TabIndex = 49;
            TbxAdress.TextChanged += TbxAdress_TextChanged;
            // 
            // LblAdress
            // 
            LblAdress.AutoSize = true;
            LblAdress.ForeColor = Color.White;
            LblAdress.Location = new Point(66, 325);
            LblAdress.Margin = new Padding(4, 0, 4, 0);
            LblAdress.Name = "LblAdress";
            LblAdress.Size = new Size(45, 15);
            LblAdress.TabIndex = 48;
            LblAdress.Text = "Adress:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(388, 329);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 51;
            label1.Text = "Profile photo link";
            // 
            // TbxImageLink
            // 
            TbxImageLink.Location = new Point(388, 347);
            TbxImageLink.Name = "TbxImageLink";
            TbxImageLink.PlaceholderText = "Please paste image link here";
            TbxImageLink.Size = new Size(231, 23);
            TbxImageLink.TabIndex = 50;
            TbxImageLink.TextChanged += TbxImageLink_TextChanged;
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(812, 448);
            Controls.Add(label1);
            Controls.Add(TbxImageLink);
            Controls.Add(TbxAdress);
            Controls.Add(LblAdress);
            Controls.Add(BtnCancelEddit);
            Controls.Add(BtnEdditInfo);
            Controls.Add(TbxWorkemail);
            Controls.Add(NudHourlyRate);
            Controls.Add(CmbxRole);
            Controls.Add(TbxSSN);
            Controls.Add(TbxBankAccount);
            Controls.Add(TbxPersonalEmail);
            Controls.Add(CmbxGender);
            Controls.Add(DtpBirthdate);
            Controls.Add(TbxLName);
            Controls.Add(TbxFName);
            Controls.Add(LblBankAccount);
            Controls.Add(LblPEmail);
            Controls.Add(LblWorkEmail);
            Controls.Add(label7);
            Controls.Add(LblRole);
            Controls.Add(LblGender);
            Controls.Add(LblBirthDate);
            Controls.Add(LblSSN);
            Controls.Add(LblLName);
            Controls.Add(LblFname);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProfileForm";
            Text = "ProfileForm";
            ((System.ComponentModel.ISupportInitialize)NudHourlyRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TbxWorkemail;
        private NumericUpDown NudHourlyRate;
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
        private Button BtnEdditInfo;
        private Button BtnCancelEddit;
        private TextBox TbxAdress;
        private Label LblAdress;
        private Label label1;
        private TextBox TbxImageLink;
    }
}