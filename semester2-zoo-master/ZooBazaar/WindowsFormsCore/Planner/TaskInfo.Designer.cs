namespace WindowsFormsCore.Planner
{
    partial class TaskInfo
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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            AddCmbx = new ComboBox();
            SpeciesBTN = new Button();
            AnimalBTN = new Button();
            EmployeeBtn = new Button();
            Addspecies = new Button();
            TitleCmbx = new ComboBox();
            label3 = new Label();
            DateTaskPicker = new DateTimePicker();
            RemoveBtn = new Button();
            BtnSaveTask = new Button();
            TbxTaskDescription = new TextBox();
            CmbShifts = new ComboBox();
            label4 = new Label();
            lbxSpecies = new ListBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(TitleCmbx);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(DateTaskPicker);
            groupBox1.Controls.Add(RemoveBtn);
            groupBox1.Controls.Add(BtnSaveTask);
            groupBox1.Controls.Add(TbxTaskDescription);
            groupBox1.Controls.Add(CmbShifts);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lbxSpecies);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(13, 10);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(538, 448);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Task info";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(AddCmbx);
            groupBox2.Controls.Add(SpeciesBTN);
            groupBox2.Controls.Add(AnimalBTN);
            groupBox2.Controls.Add(EmployeeBtn);
            groupBox2.Controls.Add(Addspecies);
            groupBox2.Location = new Point(216, 13);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(309, 123);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add ";
            // 
            // AddCmbx
            // 
            AddCmbx.FormattingEnabled = true;
            AddCmbx.Location = new Point(46, 69);
            AddCmbx.Margin = new Padding(2);
            AddCmbx.Name = "AddCmbx";
            AddCmbx.Size = new Size(129, 23);
            AddCmbx.TabIndex = 17;
            AddCmbx.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // SpeciesBTN
            // 
            SpeciesBTN.BackColor = Color.FromArgb(24, 30, 54);
            SpeciesBTN.FlatAppearance.BorderSize = 0;
            SpeciesBTN.FlatStyle = FlatStyle.Flat;
            SpeciesBTN.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SpeciesBTN.Location = new Point(112, 20);
            SpeciesBTN.Margin = new Padding(1, 2, 1, 2);
            SpeciesBTN.Name = "SpeciesBTN";
            SpeciesBTN.Size = new Size(78, 29);
            SpeciesBTN.TabIndex = 11;
            SpeciesBTN.Text = "Species";
            SpeciesBTN.UseVisualStyleBackColor = false;
            SpeciesBTN.Click += SpeciesBTN_Click_1;
            // 
            // AnimalBTN
            // 
            AnimalBTN.BackColor = Color.FromArgb(24, 30, 54);
            AnimalBTN.FlatAppearance.BorderSize = 0;
            AnimalBTN.FlatStyle = FlatStyle.Flat;
            AnimalBTN.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            AnimalBTN.Location = new Point(201, 20);
            AnimalBTN.Margin = new Padding(1, 2, 1, 2);
            AnimalBTN.Name = "AnimalBTN";
            AnimalBTN.Size = new Size(78, 29);
            AnimalBTN.TabIndex = 12;
            AnimalBTN.Text = "Animal";
            AnimalBTN.UseVisualStyleBackColor = false;
            AnimalBTN.Click += AnimalBTN_Click_1;
            // 
            // EmployeeBtn
            // 
            EmployeeBtn.BackColor = Color.FromArgb(24, 30, 54);
            EmployeeBtn.FlatAppearance.BorderSize = 0;
            EmployeeBtn.FlatStyle = FlatStyle.Flat;
            EmployeeBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            EmployeeBtn.Location = new Point(21, 20);
            EmployeeBtn.Margin = new Padding(2);
            EmployeeBtn.Name = "EmployeeBtn";
            EmployeeBtn.Size = new Size(78, 29);
            EmployeeBtn.TabIndex = 16;
            EmployeeBtn.Text = "Employee";
            EmployeeBtn.UseVisualStyleBackColor = false;
            EmployeeBtn.Click += EmployeeBtn_Click;
            // 
            // Addspecies
            // 
            Addspecies.BackColor = Color.FromArgb(24, 30, 54);
            Addspecies.FlatAppearance.BorderSize = 0;
            Addspecies.FlatStyle = FlatStyle.Flat;
            Addspecies.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Addspecies.Location = new Point(178, 69);
            Addspecies.Margin = new Padding(1, 2, 1, 2);
            Addspecies.Name = "Addspecies";
            Addspecies.Size = new Size(75, 23);
            Addspecies.TabIndex = 15;
            Addspecies.Text = "Add";
            Addspecies.UseVisualStyleBackColor = false;
            Addspecies.Click += Addspecies_Click_1;
            // 
            // TitleCmbx
            // 
            TitleCmbx.FormattingEnabled = true;
            TitleCmbx.Location = new Point(10, 41);
            TitleCmbx.Margin = new Padding(2);
            TitleCmbx.Name = "TitleCmbx";
            TitleCmbx.Size = new Size(193, 23);
            TitleCmbx.TabIndex = 20;
            TitleCmbx.SelectedIndexChanged += TitleCmbx_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(237, 383);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 19;
            label3.Text = "Date";
            // 
            // DateTaskPicker
            // 
            DateTaskPicker.Location = new Point(237, 400);
            DateTaskPicker.Margin = new Padding(2);
            DateTaskPicker.Name = "DateTaskPicker";
            DateTaskPicker.Size = new Size(181, 23);
            DateTaskPicker.TabIndex = 18;
            // 
            // RemoveBtn
            // 
            RemoveBtn.BackColor = Color.FromArgb(24, 30, 54);
            RemoveBtn.FlatAppearance.BorderSize = 0;
            RemoveBtn.FlatStyle = FlatStyle.Flat;
            RemoveBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            RemoveBtn.Location = new Point(437, 152);
            RemoveBtn.Margin = new Padding(2);
            RemoveBtn.Name = "RemoveBtn";
            RemoveBtn.Size = new Size(88, 24);
            RemoveBtn.TabIndex = 17;
            RemoveBtn.Text = "Remove";
            RemoveBtn.UseVisualStyleBackColor = false;
            RemoveBtn.Click += RemoveBtn_Click;
            // 
            // BtnSaveTask
            // 
            BtnSaveTask.BackColor = Color.FromArgb(24, 30, 54);
            BtnSaveTask.FlatAppearance.BorderSize = 0;
            BtnSaveTask.FlatStyle = FlatStyle.Flat;
            BtnSaveTask.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnSaveTask.Location = new Point(437, 396);
            BtnSaveTask.Margin = new Padding(4, 3, 4, 3);
            BtnSaveTask.Name = "BtnSaveTask";
            BtnSaveTask.Size = new Size(88, 27);
            BtnSaveTask.TabIndex = 10;
            BtnSaveTask.Text = "Save";
            BtnSaveTask.UseVisualStyleBackColor = false;
            BtnSaveTask.Click += BtnSaveTask_Click;
            // 
            // TbxTaskDescription
            // 
            TbxTaskDescription.Location = new Point(7, 96);
            TbxTaskDescription.Margin = new Padding(4, 3, 4, 3);
            TbxTaskDescription.Multiline = true;
            TbxTaskDescription.Name = "TbxTaskDescription";
            TbxTaskDescription.ReadOnly = true;
            TbxTaskDescription.Size = new Size(196, 341);
            TbxTaskDescription.TabIndex = 9;
            TbxTaskDescription.TextChanged += TbxTaskDescription_TextChanged;
            // 
            // CmbShifts
            // 
            CmbShifts.FormattingEnabled = true;
            CmbShifts.Items.AddRange(new object[] { "9:00-10:00", "10:00-11:00", "11:00-12:00", "13:00-14:00", "14:00-15:00", "15:00-16:00" });
            CmbShifts.Location = new Point(237, 357);
            CmbShifts.Margin = new Padding(4, 3, 4, 3);
            CmbShifts.Name = "CmbShifts";
            CmbShifts.Size = new Size(181, 23);
            CmbShifts.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(237, 339);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 4;
            label4.Text = "Shift";
            // 
            // lbxSpecies
            // 
            lbxSpecies.FormattingEnabled = true;
            lbxSpecies.ItemHeight = 15;
            lbxSpecies.Location = new Point(237, 152);
            lbxSpecies.Margin = new Padding(4, 3, 4, 3);
            lbxSpecies.Name = "lbxSpecies";
            lbxSpecies.Size = new Size(181, 184);
            lbxSpecies.TabIndex = 3;
            lbxSpecies.SelectedIndexChanged += lbxSpecies_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 77);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Description:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 0;
            label1.Text = "Title:";
            // 
            // TaskInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(560, 488);
            Controls.Add(groupBox1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "TaskInfo";
            Text = "TaskInfo";
            Load += TaskInfo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button Addspecies;
        private Button AnimalBTN;
        private Button SpeciesBTN;
        private Button BtnSaveTask;
        private TextBox TbxTaskDescription;
        private ComboBox CmbShifts;
        private Label label4;
        private ListBox lbxSpecies;
        private Label label2;
        private Label label1;
        private Button EmployeeBtn;
        private Button RemoveBtn;
        private Label label3;
        private DateTimePicker DateTaskPicker;
        private ComboBox TitleCmbx;
        private GroupBox groupBox2;
        private ComboBox AddCmbx;
    }
}