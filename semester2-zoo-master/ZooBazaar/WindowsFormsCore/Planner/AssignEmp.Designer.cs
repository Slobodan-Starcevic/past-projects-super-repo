namespace WindowsFormApp
{
    partial class AssignEmp
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
            BtnRemoveEmployee = new Button();
            BtnAddEmployee = new Button();
            CmbxEmployee = new ComboBox();
            AddLabel = new Label();
            lbxassignedEmployees = new ListBox();
            Savebtn = new Button();
            Shiftcmbx = new ComboBox();
            Shift = new Label();
            RoleCmbox = new ComboBox();
            label1 = new Label();
            EmployeeBtn = new Button();
            SpeciesBtn = new Button();
            AnimalBtn = new Button();
            reloadBtn = new Button();
            SuspendLayout();
            // 
            // BtnRemoveEmployee
            // 
            BtnRemoveEmployee.BackColor = Color.FromArgb(24, 30, 54);
            BtnRemoveEmployee.FlatAppearance.BorderSize = 0;
            BtnRemoveEmployee.FlatStyle = FlatStyle.Flat;
            BtnRemoveEmployee.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnRemoveEmployee.Location = new Point(30, 295);
            BtnRemoveEmployee.Margin = new Padding(4, 3, 4, 3);
            BtnRemoveEmployee.Name = "BtnRemoveEmployee";
            BtnRemoveEmployee.Size = new Size(138, 35);
            BtnRemoveEmployee.TabIndex = 13;
            BtnRemoveEmployee.Text = "Remove";
            BtnRemoveEmployee.UseVisualStyleBackColor = false;
            BtnRemoveEmployee.Visible = false;
            BtnRemoveEmployee.Click += BtnRemoveEmployee_Click_1;
            // 
            // BtnAddEmployee
            // 
            BtnAddEmployee.BackColor = Color.FromArgb(24, 30, 54);
            BtnAddEmployee.FlatAppearance.BorderSize = 0;
            BtnAddEmployee.FlatStyle = FlatStyle.Flat;
            BtnAddEmployee.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddEmployee.Location = new Point(219, 159);
            BtnAddEmployee.Margin = new Padding(4, 3, 4, 3);
            BtnAddEmployee.Name = "BtnAddEmployee";
            BtnAddEmployee.Size = new Size(138, 33);
            BtnAddEmployee.TabIndex = 12;
            BtnAddEmployee.Text = "Add";
            BtnAddEmployee.UseVisualStyleBackColor = false;
            BtnAddEmployee.Click += BtnAddEmployee_Click_2;
            // 
            // CmbxEmployee
            // 
            CmbxEmployee.FormattingEnabled = true;
            CmbxEmployee.Location = new Point(219, 123);
            CmbxEmployee.Margin = new Padding(4, 3, 4, 3);
            CmbxEmployee.Name = "CmbxEmployee";
            CmbxEmployee.Size = new Size(138, 23);
            CmbxEmployee.TabIndex = 11;
            CmbxEmployee.SelectedIndexChanged += CmbxEmployee_SelectedIndexChanged_1;
            // 
            // AddLabel
            // 
            AddLabel.AutoSize = true;
            AddLabel.Location = new Point(219, 103);
            AddLabel.Margin = new Padding(4, 0, 4, 0);
            AddLabel.Name = "AddLabel";
            AddLabel.Size = new Size(37, 15);
            AddLabel.TabIndex = 10;
            AddLabel.Text = "Entity";
            // 
            // lbxassignedEmployees
            // 
            lbxassignedEmployees.FormattingEnabled = true;
            lbxassignedEmployees.ItemHeight = 15;
            lbxassignedEmployees.Location = new Point(30, 120);
            lbxassignedEmployees.Margin = new Padding(4, 3, 4, 3);
            lbxassignedEmployees.Name = "lbxassignedEmployees";
            lbxassignedEmployees.Size = new Size(138, 169);
            lbxassignedEmployees.TabIndex = 9;
            // 
            // Savebtn
            // 
            Savebtn.BackColor = Color.FromArgb(24, 30, 54);
            Savebtn.FlatAppearance.BorderSize = 0;
            Savebtn.FlatStyle = FlatStyle.Flat;
            Savebtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Savebtn.Location = new Point(219, 256);
            Savebtn.Margin = new Padding(3, 2, 3, 2);
            Savebtn.Name = "Savebtn";
            Savebtn.Size = new Size(138, 33);
            Savebtn.TabIndex = 14;
            Savebtn.Text = "Save";
            Savebtn.UseVisualStyleBackColor = false;
            Savebtn.Click += Savebtn_Click_1;
            // 
            // Shiftcmbx
            // 
            Shiftcmbx.FormattingEnabled = true;
            Shiftcmbx.Items.AddRange(new object[] { "9:00-10:00", "10:00-11:00", "11:00-12:00", "13:00-14:00", "14:00-15:00", "15:00-16:00" });
            Shiftcmbx.Location = new Point(219, 27);
            Shiftcmbx.Margin = new Padding(1);
            Shiftcmbx.Name = "Shiftcmbx";
            Shiftcmbx.Size = new Size(138, 23);
            Shiftcmbx.TabIndex = 16;
            Shiftcmbx.SelectedIndexChanged += Shiftcmbx_SelectedIndexChanged_1;
            // 
            // Shift
            // 
            Shift.AutoSize = true;
            Shift.Location = new Point(216, 11);
            Shift.Margin = new Padding(1, 0, 1, 0);
            Shift.Name = "Shift";
            Shift.Size = new Size(31, 15);
            Shift.TabIndex = 17;
            Shift.Text = "Shift";
            // 
            // RoleCmbox
            // 
            RoleCmbox.FormattingEnabled = true;
            RoleCmbox.Items.AddRange(new object[] { "Admin", "Planner", "Manager", "Caretaker       ", "Employee" });
            RoleCmbox.Location = new Point(219, 73);
            RoleCmbox.Margin = new Padding(1);
            RoleCmbox.Name = "RoleCmbox";
            RoleCmbox.Size = new Size(138, 23);
            RoleCmbox.TabIndex = 18;
            RoleCmbox.SelectedIndexChanged += RoleCmbox_SelectedIndexChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(219, 57);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 20;
            label1.Text = "Role";
            // 
            // EmployeeBtn
            // 
            EmployeeBtn.BackColor = Color.FromArgb(24, 30, 54);
            EmployeeBtn.FlatAppearance.BorderSize = 0;
            EmployeeBtn.FlatStyle = FlatStyle.Flat;
            EmployeeBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            EmployeeBtn.Location = new Point(30, 21);
            EmployeeBtn.Margin = new Padding(1);
            EmployeeBtn.Name = "EmployeeBtn";
            EmployeeBtn.Size = new Size(138, 29);
            EmployeeBtn.TabIndex = 21;
            EmployeeBtn.Text = "Employees";
            EmployeeBtn.UseVisualStyleBackColor = false;
            EmployeeBtn.Click += EmployeeBtn_Click_1;
            // 
            // SpeciesBtn
            // 
            SpeciesBtn.BackColor = Color.FromArgb(24, 30, 54);
            SpeciesBtn.FlatAppearance.BorderSize = 0;
            SpeciesBtn.FlatStyle = FlatStyle.Flat;
            SpeciesBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SpeciesBtn.Location = new Point(30, 52);
            SpeciesBtn.Margin = new Padding(1);
            SpeciesBtn.Name = "SpeciesBtn";
            SpeciesBtn.Size = new Size(138, 29);
            SpeciesBtn.TabIndex = 22;
            SpeciesBtn.Text = "Species";
            SpeciesBtn.UseVisualStyleBackColor = false;
            SpeciesBtn.Click += SpeciesBtn_Click_1;
            // 
            // AnimalBtn
            // 
            AnimalBtn.BackColor = Color.FromArgb(24, 30, 54);
            AnimalBtn.FlatAppearance.BorderSize = 0;
            AnimalBtn.FlatStyle = FlatStyle.Flat;
            AnimalBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            AnimalBtn.Location = new Point(30, 83);
            AnimalBtn.Margin = new Padding(1);
            AnimalBtn.Name = "AnimalBtn";
            AnimalBtn.Size = new Size(138, 26);
            AnimalBtn.TabIndex = 23;
            AnimalBtn.Text = "Animal";
            AnimalBtn.UseVisualStyleBackColor = false;
            AnimalBtn.Click += AnimalBtn_Click_1;
            // 
            // reloadBtn
            // 
            reloadBtn.BackColor = Color.FromArgb(24, 30, 54);
            reloadBtn.FlatAppearance.BorderSize = 0;
            reloadBtn.FlatStyle = FlatStyle.Flat;
            reloadBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            reloadBtn.Location = new Point(219, 295);
            reloadBtn.Margin = new Padding(1);
            reloadBtn.Name = "reloadBtn";
            reloadBtn.Size = new Size(138, 35);
            reloadBtn.TabIndex = 15;
            reloadBtn.Text = "Reload page";
            reloadBtn.UseVisualStyleBackColor = false;
            // 
            // AssignEmp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(384, 352);
            Controls.Add(AnimalBtn);
            Controls.Add(SpeciesBtn);
            Controls.Add(EmployeeBtn);
            Controls.Add(label1);
            Controls.Add(RoleCmbox);
            Controls.Add(Shift);
            Controls.Add(Shiftcmbx);
            Controls.Add(reloadBtn);
            Controls.Add(Savebtn);
            Controls.Add(BtnRemoveEmployee);
            Controls.Add(BtnAddEmployee);
            Controls.Add(CmbxEmployee);
            Controls.Add(AddLabel);
            Controls.Add(lbxassignedEmployees);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AssignEmp";
            Text = "SheduleForm";
            Load += AssignEmp_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnRemoveEmployee;
        private Button BtnAddEmployee;
        private ComboBox CmbxEmployee;
        private Label AddLabel;
        private ListBox lbxassignedEmployees;
        private Button Savebtn;
        private Button SpeciesBtn;
        private ComboBox Shiftcmbx;
        private Label Shift;
        private ComboBox RoleCmbox;
        private Label label1;
        private Button EmployeeBtn;
        private Button AnimalBtn;
        private Button reloadBtn;
    }
}