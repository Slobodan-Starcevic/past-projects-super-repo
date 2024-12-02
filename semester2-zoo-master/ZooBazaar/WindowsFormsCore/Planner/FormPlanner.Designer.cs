namespace WindowsFormApp
{
    partial class FormPlanner
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
            BtnProfileShow = new Button();
            PnlView = new Panel();
            BtnSheduleShow = new Button();
            AddTaskBtn = new Button();
            SuspendLayout();
            // 
            // BtnProfileShow
            // 
            BtnProfileShow.BackColor = Color.FromArgb(46, 51, 73);
            BtnProfileShow.FlatAppearance.BorderSize = 0;
            BtnProfileShow.FlatStyle = FlatStyle.Flat;
            BtnProfileShow.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnProfileShow.Location = new Point(13, 14);
            BtnProfileShow.Margin = new Padding(4, 3, 4, 3);
            BtnProfileShow.Name = "BtnProfileShow";
            BtnProfileShow.Size = new Size(88, 42);
            BtnProfileShow.TabIndex = 3;
            BtnProfileShow.Text = "Profile";
            BtnProfileShow.UseVisualStyleBackColor = false;
            BtnProfileShow.Click += BtnProfileShow_Click;
            // 
            // PnlView
            // 
            PnlView.Location = new Point(111, 0);
            PnlView.Margin = new Padding(4, 3, 4, 3);
            PnlView.Name = "PnlView";
            PnlView.Size = new Size(812, 448);
            PnlView.TabIndex = 2;
            PnlView.Paint += PnlView_Paint;
            // 
            // BtnSheduleShow
            // 
            BtnSheduleShow.BackColor = Color.FromArgb(46, 51, 73);
            BtnSheduleShow.FlatAppearance.BorderSize = 0;
            BtnSheduleShow.FlatStyle = FlatStyle.Flat;
            BtnSheduleShow.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnSheduleShow.Location = new Point(13, 62);
            BtnSheduleShow.Margin = new Padding(4, 3, 4, 3);
            BtnSheduleShow.Name = "BtnSheduleShow";
            BtnSheduleShow.Size = new Size(88, 42);
            BtnSheduleShow.TabIndex = 5;
            BtnSheduleShow.Text = "Shedule";
            BtnSheduleShow.UseVisualStyleBackColor = false;
            BtnSheduleShow.Click += button1_Click;
            // 
            // AddTaskBtn
            // 
            AddTaskBtn.BackColor = Color.FromArgb(46, 51, 73);
            AddTaskBtn.FlatAppearance.BorderSize = 0;
            AddTaskBtn.FlatStyle = FlatStyle.Flat;
            AddTaskBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            AddTaskBtn.Location = new Point(13, 109);
            AddTaskBtn.Margin = new Padding(2);
            AddTaskBtn.Name = "AddTaskBtn";
            AddTaskBtn.Size = new Size(88, 42);
            AddTaskBtn.TabIndex = 6;
            AddTaskBtn.Text = "Add Task";
            AddTaskBtn.UseVisualStyleBackColor = false;
            AddTaskBtn.Click += AddTaskBtn_Click;
            // 
            // FormPlanner
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 30, 54);
            ClientSize = new Size(923, 447);
            Controls.Add(AddTaskBtn);
            Controls.Add(BtnSheduleShow);
            Controls.Add(BtnProfileShow);
            Controls.Add(PnlView);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormPlanner";
            Text = "FormPlanner";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnProfileShow;
        private Panel PnlView;
        private Button BtnSheduleShow;
        private Button AddTaskBtn;
    }
}