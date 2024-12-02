namespace WindowsFormApp
{
    partial class FormManager
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
            BtnAddEmployeeShown = new Button();
            buttonNotes = new Button();
            SuspendLayout();
            // 
            // BtnProfileShow
            // 
            BtnProfileShow.BackColor = Color.FromArgb(46, 51, 73);
            BtnProfileShow.FlatAppearance.BorderSize = 0;
            BtnProfileShow.FlatStyle = FlatStyle.Flat;
            BtnProfileShow.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnProfileShow.ForeColor = SystemColors.Control;
            BtnProfileShow.Location = new Point(14, 14);
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
            PnlView.Location = new Point(110, 0);
            PnlView.Margin = new Padding(4, 3, 4, 3);
            PnlView.Name = "PnlView";
            PnlView.Size = new Size(812, 448);
            PnlView.TabIndex = 2;
            // 
            // BtnAddEmployeeShown
            // 
            BtnAddEmployeeShown.BackColor = Color.FromArgb(46, 51, 73);
            BtnAddEmployeeShown.FlatAppearance.BorderSize = 0;
            BtnAddEmployeeShown.FlatStyle = FlatStyle.Flat;
            BtnAddEmployeeShown.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddEmployeeShown.ForeColor = SystemColors.Control;
            BtnAddEmployeeShown.Location = new Point(14, 62);
            BtnAddEmployeeShown.Margin = new Padding(4, 3, 4, 3);
            BtnAddEmployeeShown.Name = "BtnAddEmployeeShown";
            BtnAddEmployeeShown.Size = new Size(88, 42);
            BtnAddEmployeeShown.TabIndex = 4;
            BtnAddEmployeeShown.Text = "Manage Employees";
            BtnAddEmployeeShown.UseVisualStyleBackColor = false;
            BtnAddEmployeeShown.Click += BtnAddEmployeeShown_Click;
            // 
            // buttonNotes
            // 
            buttonNotes.BackColor = Color.FromArgb(46, 51, 73);
            buttonNotes.FlatAppearance.BorderSize = 0;
            buttonNotes.FlatStyle = FlatStyle.Flat;
            buttonNotes.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNotes.ForeColor = SystemColors.Control;
            buttonNotes.Location = new Point(14, 110);
            buttonNotes.Margin = new Padding(4, 3, 4, 3);
            buttonNotes.Name = "buttonNotes";
            buttonNotes.Size = new Size(88, 42);
            buttonNotes.TabIndex = 5;
            buttonNotes.Text = "Notes";
            buttonNotes.UseVisualStyleBackColor = false;
            buttonNotes.Click += buttonNotes_Click;
            // 
            // FormManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 30, 54);
            ClientSize = new Size(922, 447);
            Controls.Add(buttonNotes);
            Controls.Add(BtnAddEmployeeShown);
            Controls.Add(BtnProfileShow);
            Controls.Add(PnlView);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormManager";
            Text = "FormManager";
            ResumeLayout(false);
        }

        #endregion

        private Button BtnProfileShow;
        private Panel PnlView;
        private Button BtnAddEmployeeShown;
        private Button buttonNotes;
    }
}