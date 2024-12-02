namespace WindowsFormApp
{
    partial class WindowsForm
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
            components = new System.ComponentModel.Container();
            PnlLogIn = new Panel();
            LblWFName = new Label();
            LblWFFunction = new Label();
            LblRole = new Label();
            LblName = new Label();
            BtnTestAdmin = new Button();
            BtnTestLogin = new Button();
            button1 = new Button();
            Btn = new Button();
            LoginChecker = new System.Windows.Forms.Timer(components);
            BtnLogout = new Button();
            SuspendLayout();
            // 
            // PnlLogIn
            // 
            PnlLogIn.Location = new Point(6, 68);
            PnlLogIn.Margin = new Padding(4, 3, 4, 3);
            PnlLogIn.Name = "PnlLogIn";
            PnlLogIn.Size = new Size(922, 447);
            PnlLogIn.TabIndex = 0;
            // 
            // LblWFName
            // 
            LblWFName.AutoSize = true;
            LblWFName.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblWFName.ForeColor = Color.White;
            LblWFName.Location = new Point(126, 10);
            LblWFName.Margin = new Padding(4, 0, 4, 0);
            LblWFName.Name = "LblWFName";
            LblWFName.Size = new Size(0, 17);
            LblWFName.TabIndex = 1;
            // 
            // LblWFFunction
            // 
            LblWFFunction.AutoSize = true;
            LblWFFunction.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblWFFunction.ForeColor = Color.White;
            LblWFFunction.Location = new Point(126, 35);
            LblWFFunction.Margin = new Padding(4, 0, 4, 0);
            LblWFFunction.Name = "LblWFFunction";
            LblWFFunction.Size = new Size(0, 17);
            LblWFFunction.TabIndex = 2;
            // 
            // LblRole
            // 
            LblRole.AutoSize = true;
            LblRole.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblRole.ForeColor = Color.White;
            LblRole.Location = new Point(63, 35);
            LblRole.Margin = new Padding(4, 0, 4, 0);
            LblRole.Name = "LblRole";
            LblRole.Size = new Size(66, 17);
            LblRole.TabIndex = 3;
            LblRole.Text = "Function:";
            // 
            // LblName
            // 
            LblName.AutoSize = true;
            LblName.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LblName.ForeColor = Color.White;
            LblName.Location = new Point(63, 10);
            LblName.Margin = new Padding(4, 0, 4, 0);
            LblName.Name = "LblName";
            LblName.Size = new Size(52, 17);
            LblName.TabIndex = 4;
            LblName.Text = "Name: ";
            // 
            // BtnTestAdmin
            // 
            BtnTestAdmin.BackColor = Color.FromArgb(46, 51, 73);
            BtnTestAdmin.FlatAppearance.BorderSize = 0;
            BtnTestAdmin.FlatStyle = FlatStyle.Flat;
            BtnTestAdmin.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnTestAdmin.ForeColor = Color.White;
            BtnTestAdmin.Location = new Point(349, 12);
            BtnTestAdmin.Margin = new Padding(4, 3, 4, 3);
            BtnTestAdmin.Name = "BtnTestAdmin";
            BtnTestAdmin.Size = new Size(116, 37);
            BtnTestAdmin.TabIndex = 5;
            BtnTestAdmin.Text = "Admin page";
            BtnTestAdmin.UseVisualStyleBackColor = false;
            BtnTestAdmin.Click += BtnTestAdmin_Click;
            // 
            // BtnTestLogin
            // 
            BtnTestLogin.BackColor = Color.FromArgb(46, 51, 73);
            BtnTestLogin.FlatAppearance.BorderSize = 0;
            BtnTestLogin.FlatStyle = FlatStyle.Flat;
            BtnTestLogin.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnTestLogin.ForeColor = Color.White;
            BtnTestLogin.Location = new Point(225, 12);
            BtnTestLogin.Margin = new Padding(4, 3, 4, 3);
            BtnTestLogin.Name = "BtnTestLogin";
            BtnTestLogin.Size = new Size(116, 37);
            BtnTestLogin.TabIndex = 6;
            BtnTestLogin.Text = "Login page";
            BtnTestLogin.UseVisualStyleBackColor = false;
            BtnTestLogin.Click += BtnTestLogin_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(46, 51, 73);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(473, 12);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(116, 37);
            button1.TabIndex = 7;
            button1.Text = "Planner page";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Btn
            // 
            Btn.BackColor = Color.FromArgb(46, 51, 73);
            Btn.FlatAppearance.BorderSize = 0;
            Btn.FlatStyle = FlatStyle.Flat;
            Btn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Btn.ForeColor = Color.White;
            Btn.Location = new Point(597, 12);
            Btn.Margin = new Padding(4, 3, 4, 3);
            Btn.Name = "Btn";
            Btn.Size = new Size(116, 38);
            Btn.TabIndex = 8;
            Btn.Text = "Manager page";
            Btn.UseVisualStyleBackColor = false;
            Btn.Click += Btn_Click;
            // 
            // LoginChecker
            // 
            LoginChecker.Enabled = true;
            LoginChecker.Tick += LoginChecker_Tick;
            // 
            // BtnLogout
            // 
            BtnLogout.BackColor = Color.FromArgb(46, 51, 73);
            BtnLogout.Enabled = false;
            BtnLogout.FlatAppearance.BorderSize = 0;
            BtnLogout.FlatStyle = FlatStyle.Flat;
            BtnLogout.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnLogout.ForeColor = Color.White;
            BtnLogout.Location = new Point(776, 12);
            BtnLogout.Name = "BtnLogout";
            BtnLogout.Size = new Size(145, 38);
            BtnLogout.TabIndex = 9;
            BtnLogout.Text = "Log out";
            BtnLogout.UseVisualStyleBackColor = false;
            BtnLogout.Visible = false;
            BtnLogout.Click += BtnLogout_Click;
            // 
            // WindowsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(24, 30, 54);
            ClientSize = new Size(933, 519);
            Controls.Add(BtnTestLogin);
            Controls.Add(BtnTestAdmin);
            Controls.Add(button1);
            Controls.Add(BtnLogout);
            Controls.Add(Btn);
            Controls.Add(LblName);
            Controls.Add(LblRole);
            Controls.Add(LblWFFunction);
            Controls.Add(LblWFName);
            Controls.Add(PnlLogIn);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "WindowsForm";
            Text = "Zoo BazaAr";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PnlLogIn;
        private Label LblWFName;
        private Label LblWFFunction;
        private Label LblRole;
        private Label LblName;
        private Button BtnTestAdmin;
        private Button BtnTestLogin;
        private Button button1;
        private Button Btn;
        private System.Windows.Forms.Timer LoginChecker;
        private Button BtnLogout;
    }
}

