namespace WindowsFormsCore.Planner
{
    partial class TaskShow
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
            Titletxtbx = new TextBox();
            TbxTaskDescription = new TextBox();
            EmployeesLsbx = new ListBox();
            AnimalsLsbx = new ListBox();
            SpeciesLsbx = new ListBox();
            ShiftTxtbx = new TextBox();
            DateTxtbx = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            CloseBtn = new Button();
            SuspendLayout();
            // 
            // Titletxtbx
            // 
            Titletxtbx.Location = new Point(44, 35);
            Titletxtbx.Margin = new Padding(2);
            Titletxtbx.Name = "Titletxtbx";
            Titletxtbx.ReadOnly = true;
            Titletxtbx.Size = new Size(173, 23);
            Titletxtbx.TabIndex = 0;
            // 
            // TbxTaskDescription
            // 
            TbxTaskDescription.Location = new Point(44, 122);
            TbxTaskDescription.Margin = new Padding(4, 3, 4, 3);
            TbxTaskDescription.Multiline = true;
            TbxTaskDescription.Name = "TbxTaskDescription";
            TbxTaskDescription.ReadOnly = true;
            TbxTaskDescription.Size = new Size(173, 260);
            TbxTaskDescription.TabIndex = 10;
            TbxTaskDescription.TextChanged += TbxTaskDescription_TextChanged;
            // 
            // EmployeesLsbx
            // 
            EmployeesLsbx.FormattingEnabled = true;
            EmployeesLsbx.ItemHeight = 15;
            EmployeesLsbx.Location = new Point(263, 122);
            EmployeesLsbx.Margin = new Padding(2);
            EmployeesLsbx.Name = "EmployeesLsbx";
            EmployeesLsbx.Size = new Size(103, 259);
            EmployeesLsbx.TabIndex = 11;
            EmployeesLsbx.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // AnimalsLsbx
            // 
            AnimalsLsbx.FormattingEnabled = true;
            AnimalsLsbx.ItemHeight = 15;
            AnimalsLsbx.Location = new Point(412, 122);
            AnimalsLsbx.Margin = new Padding(2);
            AnimalsLsbx.Name = "AnimalsLsbx";
            AnimalsLsbx.Size = new Size(103, 259);
            AnimalsLsbx.TabIndex = 12;
            AnimalsLsbx.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // SpeciesLsbx
            // 
            SpeciesLsbx.FormattingEnabled = true;
            SpeciesLsbx.ItemHeight = 15;
            SpeciesLsbx.Location = new Point(553, 122);
            SpeciesLsbx.Margin = new Padding(2);
            SpeciesLsbx.Name = "SpeciesLsbx";
            SpeciesLsbx.Size = new Size(103, 259);
            SpeciesLsbx.TabIndex = 13;
            SpeciesLsbx.SelectedIndexChanged += listBox3_SelectedIndexChanged;
            // 
            // ShiftTxtbx
            // 
            ShiftTxtbx.Location = new Point(263, 35);
            ShiftTxtbx.Margin = new Padding(2);
            ShiftTxtbx.Name = "ShiftTxtbx";
            ShiftTxtbx.ReadOnly = true;
            ShiftTxtbx.Size = new Size(103, 23);
            ShiftTxtbx.TabIndex = 14;
            // 
            // DateTxtbx
            // 
            DateTxtbx.Location = new Point(412, 35);
            DateTxtbx.Margin = new Padding(2);
            DateTxtbx.Name = "DateTxtbx";
            DateTxtbx.ReadOnly = true;
            DateTxtbx.Size = new Size(103, 23);
            DateTxtbx.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 16;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 98);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 17;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(261, 18);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 18;
            label3.Text = "Shift";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(412, 18);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 19;
            label4.Text = "Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(263, 98);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 20;
            label5.Text = "Employees";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(412, 98);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 21;
            label6.Text = "Animals";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(553, 98);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 22;
            label7.Text = "Species";
            // 
            // CloseBtn
            // 
            CloseBtn.BackColor = Color.FromArgb(24, 30, 54);
            CloseBtn.FlatAppearance.BorderSize = 0;
            CloseBtn.FlatStyle = FlatStyle.Flat;
            CloseBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            CloseBtn.Location = new Point(553, 25);
            CloseBtn.Margin = new Padding(2);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(103, 39);
            CloseBtn.TabIndex = 23;
            CloseBtn.Text = "Close";
            CloseBtn.UseVisualStyleBackColor = false;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // TaskShow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(675, 395);
            Controls.Add(CloseBtn);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DateTxtbx);
            Controls.Add(ShiftTxtbx);
            Controls.Add(SpeciesLsbx);
            Controls.Add(AnimalsLsbx);
            Controls.Add(EmployeesLsbx);
            Controls.Add(TbxTaskDescription);
            Controls.Add(Titletxtbx);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "TaskShow";
            Text = "TaskShow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Titletxtbx;
        private TextBox TbxTaskDescription;
        private ListBox EmployeesLsbx;
        private ListBox AnimalsLsbx;
        private ListBox SpeciesLsbx;
        private TextBox ShiftTxtbx;
        private TextBox DateTxtbx;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button CloseBtn;
    }
}