namespace WindowsFormApp
{
    partial class SheduleAndTask
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
            LsbxTasks = new ListBox();
            AssignBtn = new Button();
            EmployeeListbox = new ListBox();
            EmployeeTaskLsbx = new ListBox();
            label1 = new Label();
            SearchByNamebtn = new Button();
            SearchByEmployeeBtn = new Button();
            Employees = new Label();
            label3 = new Label();
            label2 = new Label();
            SeeInfoBtn = new Button();
            dateTimePicker1 = new DateTimePicker();
            SelectDate = new Button();
            DateAllBtn = new Button();
            RemoveBtn = new Button();
            titlecmbx = new ComboBox();
            SuspendLayout();
            // 
            // LsbxTasks
            // 
            LsbxTasks.FormattingEnabled = true;
            LsbxTasks.ItemHeight = 15;
            LsbxTasks.Location = new Point(29, 24);
            LsbxTasks.Margin = new Padding(4, 3, 4, 3);
            LsbxTasks.Name = "LsbxTasks";
            LsbxTasks.Size = new Size(230, 409);
            LsbxTasks.TabIndex = 0;
            LsbxTasks.SelectedIndexChanged += LsbxTasks_SelectedIndexChanged_1;
            // 
            // AssignBtn
            // 
            AssignBtn.BackColor = Color.FromArgb(24, 30, 54);
            AssignBtn.FlatAppearance.BorderSize = 0;
            AssignBtn.FlatStyle = FlatStyle.Flat;
            AssignBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            AssignBtn.Location = new Point(280, 296);
            AssignBtn.Margin = new Padding(3, 2, 3, 2);
            AssignBtn.Name = "AssignBtn";
            AssignBtn.Size = new Size(193, 36);
            AssignBtn.TabIndex = 3;
            AssignBtn.Text = "Assign Employee";
            AssignBtn.UseVisualStyleBackColor = false;
            AssignBtn.Click += AssignBtn_Click;
            // 
            // EmployeeListbox
            // 
            EmployeeListbox.FormattingEnabled = true;
            EmployeeListbox.ItemHeight = 15;
            EmployeeListbox.Location = new Point(501, 249);
            EmployeeListbox.Margin = new Padding(2);
            EmployeeListbox.Name = "EmployeeListbox";
            EmployeeListbox.Size = new Size(221, 184);
            EmployeeListbox.TabIndex = 5;
            EmployeeListbox.SelectedIndexChanged += EmployeeListbox_SelectedIndexChanged;
            // 
            // EmployeeTaskLsbx
            // 
            EmployeeTaskLsbx.FormattingEnabled = true;
            EmployeeTaskLsbx.ItemHeight = 15;
            EmployeeTaskLsbx.Location = new Point(501, 24);
            EmployeeTaskLsbx.Margin = new Padding(2);
            EmployeeTaskLsbx.Name = "EmployeeTaskLsbx";
            EmployeeTaskLsbx.Size = new Size(221, 184);
            EmployeeTaskLsbx.TabIndex = 0;
            EmployeeTaskLsbx.SelectedIndexChanged += EmployeeTaskLsbx_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(280, 7);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 7;
            label1.Text = "Task Name";
            label1.Click += label1_Click;
            // 
            // SearchByNamebtn
            // 
            SearchByNamebtn.BackColor = Color.FromArgb(24, 30, 54);
            SearchByNamebtn.FlatAppearance.BorderSize = 0;
            SearchByNamebtn.FlatStyle = FlatStyle.Flat;
            SearchByNamebtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SearchByNamebtn.Location = new Point(399, 24);
            SearchByNamebtn.Margin = new Padding(2);
            SearchByNamebtn.Name = "SearchByNamebtn";
            SearchByNamebtn.Size = new Size(74, 23);
            SearchByNamebtn.TabIndex = 8;
            SearchByNamebtn.Text = "Search";
            SearchByNamebtn.UseVisualStyleBackColor = false;
            SearchByNamebtn.Click += button1_Click;
            // 
            // SearchByEmployeeBtn
            // 
            SearchByEmployeeBtn.BackColor = Color.FromArgb(24, 30, 54);
            SearchByEmployeeBtn.FlatAppearance.BorderSize = 0;
            SearchByEmployeeBtn.FlatStyle = FlatStyle.Flat;
            SearchByEmployeeBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SearchByEmployeeBtn.Location = new Point(280, 121);
            SearchByEmployeeBtn.Margin = new Padding(2);
            SearchByEmployeeBtn.Name = "SearchByEmployeeBtn";
            SearchByEmployeeBtn.Size = new Size(193, 37);
            SearchByEmployeeBtn.TabIndex = 9;
            SearchByEmployeeBtn.Text = "Search without employees";
            SearchByEmployeeBtn.UseVisualStyleBackColor = false;
            SearchByEmployeeBtn.Click += SearchByEmployeeBtn_Click;
            // 
            // Employees
            // 
            Employees.AutoSize = true;
            Employees.Location = new Point(501, 232);
            Employees.Margin = new Padding(2, 0, 2, 0);
            Employees.Name = "Employees";
            Employees.Size = new Size(64, 15);
            Employees.TabIndex = 10;
            Employees.Text = "Employees";
            Employees.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(501, 7);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 11;
            label3.Text = "Tasks";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 6);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 12;
            label2.Text = "All Tasks";
            // 
            // SeeInfoBtn
            // 
            SeeInfoBtn.BackColor = Color.FromArgb(24, 30, 54);
            SeeInfoBtn.FlatAppearance.BorderSize = 0;
            SeeInfoBtn.FlatStyle = FlatStyle.Flat;
            SeeInfoBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SeeInfoBtn.Location = new Point(280, 178);
            SeeInfoBtn.Margin = new Padding(2);
            SeeInfoBtn.Name = "SeeInfoBtn";
            SeeInfoBtn.Size = new Size(193, 37);
            SeeInfoBtn.TabIndex = 15;
            SeeInfoBtn.Text = "Show task info";
            SeeInfoBtn.UseVisualStyleBackColor = false;
            SeeInfoBtn.Click += button1_Click_1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(280, 71);
            dateTimePicker1.Margin = new Padding(2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(115, 23);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // SelectDate
            // 
            SelectDate.BackColor = Color.FromArgb(24, 30, 54);
            SelectDate.FlatAppearance.BorderSize = 0;
            SelectDate.FlatStyle = FlatStyle.Flat;
            SelectDate.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SelectDate.Location = new Point(399, 71);
            SelectDate.Margin = new Padding(2);
            SelectDate.Name = "SelectDate";
            SelectDate.Size = new Size(74, 23);
            SelectDate.TabIndex = 16;
            SelectDate.Text = "Select";
            SelectDate.UseVisualStyleBackColor = false;
            SelectDate.Click += SelectDate_Click;
            // 
            // DateAllBtn
            // 
            DateAllBtn.BackColor = Color.FromArgb(24, 30, 54);
            DateAllBtn.FlatAppearance.BorderSize = 0;
            DateAllBtn.FlatStyle = FlatStyle.Flat;
            DateAllBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            DateAllBtn.Location = new Point(280, 232);
            DateAllBtn.Margin = new Padding(2);
            DateAllBtn.Name = "DateAllBtn";
            DateAllBtn.Size = new Size(193, 36);
            DateAllBtn.TabIndex = 0;
            DateAllBtn.Text = "Show all tasks";
            DateAllBtn.UseVisualStyleBackColor = false;
            DateAllBtn.Click += DateAllBtn_Click;
            // 
            // RemoveBtn
            // 
            RemoveBtn.BackColor = Color.FromArgb(24, 30, 54);
            RemoveBtn.FlatAppearance.BorderSize = 0;
            RemoveBtn.FlatStyle = FlatStyle.Flat;
            RemoveBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            RemoveBtn.Location = new Point(280, 354);
            RemoveBtn.Margin = new Padding(2);
            RemoveBtn.Name = "RemoveBtn";
            RemoveBtn.Size = new Size(193, 36);
            RemoveBtn.TabIndex = 17;
            RemoveBtn.Text = "Remove task";
            RemoveBtn.UseVisualStyleBackColor = false;
            RemoveBtn.Click += RemoveBtn_Click;
            // 
            // titlecmbx
            // 
            titlecmbx.FormattingEnabled = true;
            titlecmbx.Location = new Point(280, 24);
            titlecmbx.Margin = new Padding(2);
            titlecmbx.Name = "titlecmbx";
            titlecmbx.Size = new Size(115, 23);
            titlecmbx.TabIndex = 18;
            // 
            // SheduleAndTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(812, 449);
            Controls.Add(titlecmbx);
            Controls.Add(RemoveBtn);
            Controls.Add(DateAllBtn);
            Controls.Add(SelectDate);
            Controls.Add(dateTimePicker1);
            Controls.Add(SeeInfoBtn);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(Employees);
            Controls.Add(SearchByEmployeeBtn);
            Controls.Add(SearchByNamebtn);
            Controls.Add(label1);
            Controls.Add(EmployeeTaskLsbx);
            Controls.Add(EmployeeListbox);
            Controls.Add(AssignBtn);
            Controls.Add(LsbxTasks);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "SheduleAndTask";
            Text = "TaskForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox LsbxTasks;
        private Button AssignBtn;
        private ListBox EmployeeListbox;
        private ListBox EmployeeTaskLsbx;
        private Label label1;
        private Button SearchByNamebtn;
        private Button SearchByEmployeeBtn;
        private Label Employees;
        private Label label3;
        private Label label2;
        private Button SeeInfoBtn;
        private DateTimePicker dateTimePicker1;
        private Button SelectDate;
        private Button DateAllBtn;
        private Button RemoveBtn;
        private ComboBox titlecmbx;
    }
}