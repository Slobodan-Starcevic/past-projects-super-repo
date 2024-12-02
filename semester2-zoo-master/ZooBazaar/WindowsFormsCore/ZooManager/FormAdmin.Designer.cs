namespace WindowsFormApp
{
    partial class FormAdmin
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
            PnlView = new Panel();
            BtnProfileShow = new Button();
            BtnAddEmployee = new Button();
            BtnAddAnimal = new Button();
            BtnContentViewable = new Button();
            AddTaskOptionBtn = new Button();
            SuspendLayout();
            // 
            // PnlView
            // 
            PnlView.Location = new Point(110, 0);
            PnlView.Margin = new Padding(4, 3, 4, 3);
            PnlView.Name = "PnlView";
            PnlView.Size = new Size(812, 448);
            PnlView.TabIndex = 0;
            // 
            // BtnProfileShow
            // 
            BtnProfileShow.BackColor = Color.FromArgb(46, 51, 73);
            BtnProfileShow.FlatAppearance.BorderSize = 0;
            BtnProfileShow.FlatStyle = FlatStyle.Flat;
            BtnProfileShow.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnProfileShow.ForeColor = SystemColors.Control;
            BtnProfileShow.Location = new Point(11, 12);
            BtnProfileShow.Margin = new Padding(4, 3, 4, 3);
            BtnProfileShow.Name = "BtnProfileShow";
            BtnProfileShow.Size = new Size(88, 42);
            BtnProfileShow.TabIndex = 1;
            BtnProfileShow.Text = "Profile";
            BtnProfileShow.UseVisualStyleBackColor = false;
            BtnProfileShow.Click += BtnProfileShow_Click;
            // 
            // BtnAddEmployee
            // 
            BtnAddEmployee.BackColor = Color.FromArgb(46, 51, 73);
            BtnAddEmployee.FlatAppearance.BorderSize = 0;
            BtnAddEmployee.FlatStyle = FlatStyle.Flat;
            BtnAddEmployee.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddEmployee.ForeColor = SystemColors.Control;
            BtnAddEmployee.Location = new Point(10, 60);
            BtnAddEmployee.Margin = new Padding(4, 3, 4, 3);
            BtnAddEmployee.Name = "BtnAddEmployee";
            BtnAddEmployee.Size = new Size(90, 42);
            BtnAddEmployee.TabIndex = 2;
            BtnAddEmployee.Text = "Employees";
            BtnAddEmployee.UseVisualStyleBackColor = false;
            BtnAddEmployee.Click += BtnAddEmployee_Click;
            // 
            // BtnAddAnimal
            // 
            BtnAddAnimal.BackColor = Color.FromArgb(46, 51, 73);
            BtnAddAnimal.FlatAppearance.BorderSize = 0;
            BtnAddAnimal.FlatStyle = FlatStyle.Flat;
            BtnAddAnimal.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddAnimal.ForeColor = SystemColors.Control;
            BtnAddAnimal.Location = new Point(10, 108);
            BtnAddAnimal.Margin = new Padding(4, 3, 4, 3);
            BtnAddAnimal.Name = "BtnAddAnimal";
            BtnAddAnimal.RightToLeft = RightToLeft.Yes;
            BtnAddAnimal.Size = new Size(90, 42);
            BtnAddAnimal.TabIndex = 4;
            BtnAddAnimal.Text = "Animals";
            BtnAddAnimal.UseVisualStyleBackColor = false;
            BtnAddAnimal.Click += BtnAddAnimal_Click_1;
            // 
            // BtnContentViewable
            // 
            BtnContentViewable.BackColor = Color.FromArgb(46, 51, 73);
            BtnContentViewable.FlatAppearance.BorderSize = 0;
            BtnContentViewable.FlatStyle = FlatStyle.Flat;
            BtnContentViewable.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnContentViewable.ForeColor = SystemColors.Control;
            BtnContentViewable.Location = new Point(11, 156);
            BtnContentViewable.Margin = new Padding(4, 3, 4, 3);
            BtnContentViewable.Name = "BtnContentViewable";
            BtnContentViewable.RightToLeft = RightToLeft.No;
            BtnContentViewable.Size = new Size(89, 52);
            BtnContentViewable.TabIndex = 5;
            BtnContentViewable.Text = "Web Content";
            BtnContentViewable.UseVisualStyleBackColor = false;
            BtnContentViewable.Click += BtnContentViewable_Click;
            // 
            // AddTaskOptionBtn
            // 
            AddTaskOptionBtn.BackColor = Color.FromArgb(46, 51, 73);
            AddTaskOptionBtn.FlatAppearance.BorderSize = 0;
            AddTaskOptionBtn.FlatStyle = FlatStyle.Flat;
            AddTaskOptionBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            AddTaskOptionBtn.ForeColor = SystemColors.Control;
            AddTaskOptionBtn.Location = new Point(11, 214);
            AddTaskOptionBtn.Margin = new Padding(4, 3, 4, 3);
            AddTaskOptionBtn.Name = "AddTaskOptionBtn";
            AddTaskOptionBtn.Size = new Size(88, 45);
            AddTaskOptionBtn.TabIndex = 6;
            AddTaskOptionBtn.Text = "Task Types";
            AddTaskOptionBtn.UseVisualStyleBackColor = false;
            AddTaskOptionBtn.Click += AddTaskOptionBtn_Click;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(24, 30, 54);
            ClientSize = new Size(922, 447);
            Controls.Add(AddTaskOptionBtn);
            Controls.Add(PnlView);
            Controls.Add(BtnProfileShow);
            Controls.Add(BtnAddAnimal);
            Controls.Add(BtnContentViewable);
            Controls.Add(BtnAddEmployee);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormAdmin";
            Text = "FormAdmin";
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlView;
        private Button BtnProfileShow;
        private Button BtnAddEmployee;
        private Button BtnAddAnimal;
        private Button BtnContentViewable;
        private Button AddTaskOptionBtn;
    }
}