namespace WindowsFormsCore.ZooManager
{
    partial class TaskOption
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
            TbxTaskDescription = new TextBox();
            TitleTxtbx = new TextBox();
            OptionListbx = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            CreateBtn = new Button();
            SelectBtn = new Button();
            UpdateBtn = new Button();
            RemoveBtn = new Button();
            SuspendLayout();
            // 
            // TbxTaskDescription
            // 
            TbxTaskDescription.Location = new Point(314, 85);
            TbxTaskDescription.Margin = new Padding(4, 3, 4, 3);
            TbxTaskDescription.Multiline = true;
            TbxTaskDescription.Name = "TbxTaskDescription";
            TbxTaskDescription.Size = new Size(191, 208);
            TbxTaskDescription.TabIndex = 10;
            // 
            // TitleTxtbx
            // 
            TitleTxtbx.Location = new Point(314, 38);
            TitleTxtbx.Margin = new Padding(2);
            TitleTxtbx.Name = "TitleTxtbx";
            TitleTxtbx.Size = new Size(191, 23);
            TitleTxtbx.TabIndex = 11;
            TitleTxtbx.TextChanged += TitleTxtbx_TextChanged;
            // 
            // OptionListbx
            // 
            OptionListbx.FormattingEnabled = true;
            OptionListbx.ItemHeight = 15;
            OptionListbx.Location = new Point(22, 35);
            OptionListbx.Margin = new Padding(2);
            OptionListbx.Name = "OptionListbx";
            OptionListbx.Size = new Size(184, 304);
            OptionListbx.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 13;
            label1.Text = "Options";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(314, 21);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 14;
            label2.Text = "Title";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(314, 67);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 15;
            label3.Text = "Description";
            // 
            // CreateBtn
            // 
            CreateBtn.BackColor = Color.FromArgb(24, 30, 54);
            CreateBtn.FlatAppearance.BorderSize = 0;
            CreateBtn.FlatStyle = FlatStyle.Flat;
            CreateBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            CreateBtn.Location = new Point(422, 308);
            CreateBtn.Margin = new Padding(2);
            CreateBtn.Name = "CreateBtn";
            CreateBtn.Size = new Size(83, 31);
            CreateBtn.TabIndex = 16;
            CreateBtn.Text = "Create";
            CreateBtn.UseVisualStyleBackColor = false;
            CreateBtn.Click += CreateBtn_Click;
            // 
            // SelectBtn
            // 
            SelectBtn.BackColor = Color.FromArgb(24, 30, 54);
            SelectBtn.FlatAppearance.BorderSize = 0;
            SelectBtn.FlatStyle = FlatStyle.Flat;
            SelectBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SelectBtn.Location = new Point(210, 35);
            SelectBtn.Margin = new Padding(2);
            SelectBtn.Name = "SelectBtn";
            SelectBtn.Size = new Size(91, 26);
            SelectBtn.TabIndex = 17;
            SelectBtn.Text = "Select";
            SelectBtn.UseVisualStyleBackColor = false;
            SelectBtn.Click += SelectBtn_Click;
            // 
            // UpdateBtn
            // 
            UpdateBtn.BackColor = Color.FromArgb(24, 30, 54);
            UpdateBtn.FlatAppearance.BorderSize = 0;
            UpdateBtn.FlatStyle = FlatStyle.Flat;
            UpdateBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            UpdateBtn.Location = new Point(314, 308);
            UpdateBtn.Margin = new Padding(2);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.Size = new Size(83, 31);
            UpdateBtn.TabIndex = 18;
            UpdateBtn.Text = "Update";
            UpdateBtn.UseVisualStyleBackColor = false;
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // RemoveBtn
            // 
            RemoveBtn.BackColor = Color.FromArgb(24, 30, 54);
            RemoveBtn.FlatAppearance.BorderSize = 0;
            RemoveBtn.FlatStyle = FlatStyle.Flat;
            RemoveBtn.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            RemoveBtn.Location = new Point(210, 65);
            RemoveBtn.Margin = new Padding(2);
            RemoveBtn.Name = "RemoveBtn";
            RemoveBtn.Size = new Size(91, 26);
            RemoveBtn.TabIndex = 19;
            RemoveBtn.Text = "Remove";
            RemoveBtn.UseVisualStyleBackColor = false;
            RemoveBtn.Click += RemoveBtn_Click;
            // 
            // TaskOption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(538, 359);
            Controls.Add(RemoveBtn);
            Controls.Add(UpdateBtn);
            Controls.Add(SelectBtn);
            Controls.Add(CreateBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(OptionListbx);
            Controls.Add(TitleTxtbx);
            Controls.Add(TbxTaskDescription);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "TaskOption";
            Text = "TaskOption";
            Load += TaskOption_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TbxTaskDescription;
        private TextBox TitleTxtbx;
        private ListBox OptionListbx;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button CreateBtn;
        private Button SelectBtn;
        private Button UpdateBtn;
        private Button RemoveBtn;
    }
}