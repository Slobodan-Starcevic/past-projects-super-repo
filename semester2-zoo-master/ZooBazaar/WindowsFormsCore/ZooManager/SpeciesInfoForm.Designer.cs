namespace WindowsFormApp
{
    partial class SpeciesInfoForm
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
            BtnEditEnclosure = new Button();
            GrbxEnclosure = new GroupBox();
            BtnCancel = new Button();
            BtnDeleteEnclosure = new Button();
            BtnSaveEnclosure = new Button();
            TbxEName = new TextBox();
            label5 = new Label();
            BtnNewEnclosure = new Button();
            NudSpeciesSpeed = new NumericUpDown();
            label4 = new Label();
            NudSpeciesIncubation = new NumericUpDown();
            label3 = new Label();
            NudSpeciesLifeSpan = new NumericUpDown();
            NudSpeciesSize = new NumericUpDown();
            label2 = new Label();
            NudSpeciesWeight = new NumericUpDown();
            label1 = new Label();
            BtnDeleteSpecies = new Button();
            BtnSaveSpecies = new Button();
            CmbxEnclosure = new ComboBox();
            CmbxEndagered = new ComboBox();
            LblEnclosure = new Label();
            TbxName = new TextBox();
            LblDanger = new Label();
            LblIncubationT = new Label();
            LblName = new Label();
            groupBox1.SuspendLayout();
            GrbxEnclosure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesIncubation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesLifeSpan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesWeight).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(46, 51, 73);
            groupBox1.Controls.Add(BtnEditEnclosure);
            groupBox1.Controls.Add(GrbxEnclosure);
            groupBox1.Controls.Add(BtnNewEnclosure);
            groupBox1.Controls.Add(NudSpeciesSpeed);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(NudSpeciesIncubation);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(NudSpeciesLifeSpan);
            groupBox1.Controls.Add(NudSpeciesSize);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(NudSpeciesWeight);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(BtnDeleteSpecies);
            groupBox1.Controls.Add(BtnSaveSpecies);
            groupBox1.Controls.Add(CmbxEnclosure);
            groupBox1.Controls.Add(CmbxEndagered);
            groupBox1.Controls.Add(LblEnclosure);
            groupBox1.Controls.Add(TbxName);
            groupBox1.Controls.Add(LblDanger);
            groupBox1.Controls.Add(LblIncubationT);
            groupBox1.Controls.Add(LblName);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(14, 14);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(523, 422);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Spiecies info";
            // 
            // BtnEditEnclosure
            // 
            BtnEditEnclosure.BackColor = Color.FromArgb(24, 30, 54);
            BtnEditEnclosure.Enabled = false;
            BtnEditEnclosure.FlatAppearance.BorderSize = 0;
            BtnEditEnclosure.FlatStyle = FlatStyle.Flat;
            BtnEditEnclosure.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnEditEnclosure.ForeColor = SystemColors.Control;
            BtnEditEnclosure.Location = new Point(388, 199);
            BtnEditEnclosure.Name = "BtnEditEnclosure";
            BtnEditEnclosure.Size = new Size(88, 23);
            BtnEditEnclosure.TabIndex = 10;
            BtnEditEnclosure.Text = "Edit";
            BtnEditEnclosure.UseVisualStyleBackColor = false;
            BtnEditEnclosure.Visible = false;
            BtnEditEnclosure.Click += BtnEditEnclosure_Click;
            // 
            // GrbxEnclosure
            // 
            GrbxEnclosure.Controls.Add(BtnCancel);
            GrbxEnclosure.Controls.Add(BtnDeleteEnclosure);
            GrbxEnclosure.Controls.Add(BtnSaveEnclosure);
            GrbxEnclosure.Controls.Add(TbxEName);
            GrbxEnclosure.Controls.Add(label5);
            GrbxEnclosure.Enabled = false;
            GrbxEnclosure.Location = new Point(283, 230);
            GrbxEnclosure.Margin = new Padding(4, 3, 4, 3);
            GrbxEnclosure.Name = "GrbxEnclosure";
            GrbxEnclosure.Padding = new Padding(4, 3, 4, 3);
            GrbxEnclosure.Size = new Size(209, 141);
            GrbxEnclosure.TabIndex = 37;
            GrbxEnclosure.TabStop = false;
            GrbxEnclosure.Text = "Enclosure info";
            GrbxEnclosure.Visible = false;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.FromArgb(24, 30, 54);
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatStyle = FlatStyle.Flat;
            BtnCancel.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnCancel.ForeColor = SystemColors.Control;
            BtnCancel.Location = new Point(9, 108);
            BtnCancel.Margin = new Padding(4, 3, 4, 3);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(88, 27);
            BtnCancel.TabIndex = 14;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnDeleteEnclosure
            // 
            BtnDeleteEnclosure.BackColor = Color.FromArgb(24, 30, 54);
            BtnDeleteEnclosure.Enabled = false;
            BtnDeleteEnclosure.FlatAppearance.BorderSize = 0;
            BtnDeleteEnclosure.FlatStyle = FlatStyle.Flat;
            BtnDeleteEnclosure.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDeleteEnclosure.ForeColor = SystemColors.Control;
            BtnDeleteEnclosure.Location = new Point(105, 76);
            BtnDeleteEnclosure.Margin = new Padding(4, 3, 4, 3);
            BtnDeleteEnclosure.Name = "BtnDeleteEnclosure";
            BtnDeleteEnclosure.Size = new Size(88, 27);
            BtnDeleteEnclosure.TabIndex = 13;
            BtnDeleteEnclosure.Text = "Delete";
            BtnDeleteEnclosure.UseVisualStyleBackColor = false;
            BtnDeleteEnclosure.Visible = false;
            BtnDeleteEnclosure.Click += BtnDeleteEnclosure_Click;
            // 
            // BtnSaveEnclosure
            // 
            BtnSaveEnclosure.BackColor = Color.FromArgb(24, 30, 54);
            BtnSaveEnclosure.FlatAppearance.BorderSize = 0;
            BtnSaveEnclosure.FlatStyle = FlatStyle.Flat;
            BtnSaveEnclosure.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnSaveEnclosure.ForeColor = SystemColors.Control;
            BtnSaveEnclosure.Location = new Point(8, 76);
            BtnSaveEnclosure.Margin = new Padding(4, 3, 4, 3);
            BtnSaveEnclosure.Name = "BtnSaveEnclosure";
            BtnSaveEnclosure.Size = new Size(88, 27);
            BtnSaveEnclosure.TabIndex = 12;
            BtnSaveEnclosure.Text = "Save";
            BtnSaveEnclosure.UseVisualStyleBackColor = false;
            BtnSaveEnclosure.Click += BtnSaveEnclosure_Click;
            // 
            // TbxEName
            // 
            TbxEName.Location = new Point(72, 31);
            TbxEName.Margin = new Padding(4, 3, 4, 3);
            TbxEName.Name = "TbxEName";
            TbxEName.Size = new Size(121, 23);
            TbxEName.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 34);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 0;
            label5.Text = "Name:";
            // 
            // BtnNewEnclosure
            // 
            BtnNewEnclosure.BackColor = Color.FromArgb(24, 30, 54);
            BtnNewEnclosure.FlatAppearance.BorderSize = 0;
            BtnNewEnclosure.FlatStyle = FlatStyle.Flat;
            BtnNewEnclosure.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnNewEnclosure.ForeColor = SystemColors.Control;
            BtnNewEnclosure.Location = new Point(290, 199);
            BtnNewEnclosure.Name = "BtnNewEnclosure";
            BtnNewEnclosure.Size = new Size(89, 23);
            BtnNewEnclosure.TabIndex = 9;
            BtnNewEnclosure.Text = "New enclosure";
            BtnNewEnclosure.UseVisualStyleBackColor = false;
            BtnNewEnclosure.Click += BtnNewEnclosure_Click;
            // 
            // NudSpeciesSpeed
            // 
            NudSpeciesSpeed.Location = new Point(46, 277);
            NudSpeciesSpeed.Maximum = new decimal(new int[] { 2147483640, 0, 0, 0 });
            NudSpeciesSpeed.Name = "NudSpeciesSpeed";
            NudSpeciesSpeed.Size = new Size(181, 23);
            NudSpeciesSpeed.TabIndex = 5;
            NudSpeciesSpeed.ValueChanged += NudSpeciesSpeed_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 259);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 34;
            label4.Text = "Speed in km/h:";
            // 
            // NudSpeciesIncubation
            // 
            NudSpeciesIncubation.Location = new Point(292, 67);
            NudSpeciesIncubation.Maximum = new decimal(new int[] { 2147483640, 0, 0, 0 });
            NudSpeciesIncubation.Name = "NudSpeciesIncubation";
            NudSpeciesIncubation.Size = new Size(184, 23);
            NudSpeciesIncubation.TabIndex = 6;
            NudSpeciesIncubation.ValueChanged += NudSpeciesIncubation_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(292, 49);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 32;
            label3.Text = "Incubation time in days:";
            // 
            // NudSpeciesLifeSpan
            // 
            NudSpeciesLifeSpan.Location = new Point(46, 220);
            NudSpeciesLifeSpan.Maximum = new decimal(new int[] { 2147483640, 0, 0, 0 });
            NudSpeciesLifeSpan.Name = "NudSpeciesLifeSpan";
            NudSpeciesLifeSpan.Size = new Size(181, 23);
            NudSpeciesLifeSpan.TabIndex = 4;
            NudSpeciesLifeSpan.ValueChanged += NudSpeciesLifeSpan_ValueChanged;
            // 
            // NudSpeciesSize
            // 
            NudSpeciesSize.Location = new Point(46, 167);
            NudSpeciesSize.Maximum = new decimal(new int[] { 2147483640, 0, 0, 0 });
            NudSpeciesSize.Name = "NudSpeciesSize";
            NudSpeciesSize.Size = new Size(181, 23);
            NudSpeciesSize.TabIndex = 3;
            NudSpeciesSize.ValueChanged += NudSpeciesSize_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 149);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 29;
            label2.Text = "Size in cm:";
            // 
            // NudSpeciesWeight
            // 
            NudSpeciesWeight.Location = new Point(47, 115);
            NudSpeciesWeight.Maximum = new decimal(new int[] { 2147483640, 0, 0, 0 });
            NudSpeciesWeight.Name = "NudSpeciesWeight";
            NudSpeciesWeight.Size = new Size(180, 23);
            NudSpeciesWeight.TabIndex = 2;
            NudSpeciesWeight.ValueChanged += NudSpeciesWeight_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 96);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 27;
            label1.Text = "Weight in kg:";
            // 
            // BtnDeleteSpecies
            // 
            BtnDeleteSpecies.BackColor = Color.FromArgb(24, 30, 54);
            BtnDeleteSpecies.FlatAppearance.BorderSize = 0;
            BtnDeleteSpecies.FlatStyle = FlatStyle.Flat;
            BtnDeleteSpecies.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDeleteSpecies.ForeColor = SystemColors.Control;
            BtnDeleteSpecies.Location = new Point(143, 315);
            BtnDeleteSpecies.Margin = new Padding(4, 3, 4, 3);
            BtnDeleteSpecies.Name = "BtnDeleteSpecies";
            BtnDeleteSpecies.Size = new Size(84, 50);
            BtnDeleteSpecies.TabIndex = 15;
            BtnDeleteSpecies.Text = "Delete";
            BtnDeleteSpecies.UseVisualStyleBackColor = false;
            BtnDeleteSpecies.Click += BtnDeleteSpecies_Click;
            // 
            // BtnSaveSpecies
            // 
            BtnSaveSpecies.BackColor = Color.FromArgb(24, 30, 54);
            BtnSaveSpecies.Enabled = false;
            BtnSaveSpecies.FlatAppearance.BorderSize = 0;
            BtnSaveSpecies.FlatStyle = FlatStyle.Flat;
            BtnSaveSpecies.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnSaveSpecies.ForeColor = SystemColors.Control;
            BtnSaveSpecies.Location = new Point(46, 315);
            BtnSaveSpecies.Margin = new Padding(4, 3, 4, 3);
            BtnSaveSpecies.Name = "BtnSaveSpecies";
            BtnSaveSpecies.Size = new Size(85, 50);
            BtnSaveSpecies.TabIndex = 14;
            BtnSaveSpecies.Text = "Save";
            BtnSaveSpecies.UseVisualStyleBackColor = false;
            BtnSaveSpecies.Click += BtnSave_Click;
            // 
            // CmbxEnclosure
            // 
            CmbxEnclosure.FormattingEnabled = true;
            CmbxEnclosure.Location = new Point(291, 166);
            CmbxEnclosure.Margin = new Padding(4, 3, 4, 3);
            CmbxEnclosure.Name = "CmbxEnclosure";
            CmbxEnclosure.Size = new Size(185, 23);
            CmbxEnclosure.TabIndex = 8;
            CmbxEnclosure.SelectedIndexChanged += CmbxEnclosure_SelectedIndexChanged;
            // 
            // CmbxEndagered
            // 
            CmbxEndagered.FormattingEnabled = true;
            CmbxEndagered.Location = new Point(290, 114);
            CmbxEndagered.Margin = new Padding(4, 3, 4, 3);
            CmbxEndagered.Name = "CmbxEndagered";
            CmbxEndagered.Size = new Size(186, 23);
            CmbxEndagered.TabIndex = 7;
            CmbxEndagered.SelectionChangeCommitted += CmbxEndagered_SelectionChangeCommitted;
            // 
            // LblEnclosure
            // 
            LblEnclosure.AutoSize = true;
            LblEnclosure.Location = new Point(290, 145);
            LblEnclosure.Margin = new Padding(4, 0, 4, 0);
            LblEnclosure.Name = "LblEnclosure";
            LblEnclosure.Size = new Size(61, 15);
            LblEnclosure.TabIndex = 9;
            LblEnclosure.Text = "Enclosure:";
            // 
            // TbxName
            // 
            TbxName.Location = new Point(47, 66);
            TbxName.Margin = new Padding(4, 3, 4, 3);
            TbxName.Name = "TbxName";
            TbxName.Size = new Size(180, 23);
            TbxName.TabIndex = 1;
            TbxName.TextChanged += TbxName_TextChanged;
            // 
            // LblDanger
            // 
            LblDanger.AutoSize = true;
            LblDanger.Location = new Point(290, 93);
            LblDanger.Margin = new Padding(4, 0, 4, 0);
            LblDanger.Name = "LblDanger";
            LblDanger.Size = new Size(73, 15);
            LblDanger.TabIndex = 6;
            LblDanger.Text = "Endangered:";
            // 
            // LblIncubationT
            // 
            LblIncubationT.AutoSize = true;
            LblIncubationT.Location = new Point(46, 202);
            LblIncubationT.Margin = new Padding(4, 0, 4, 0);
            LblIncubationT.Name = "LblIncubationT";
            LblIncubationT.Size = new Size(97, 15);
            LblIncubationT.TabIndex = 4;
            LblIncubationT.Text = "Life span in days:";
            // 
            // LblName
            // 
            LblName.AutoSize = true;
            LblName.Location = new Point(47, 48);
            LblName.Margin = new Padding(4, 0, 4, 0);
            LblName.Name = "LblName";
            LblName.Size = new Size(42, 15);
            LblName.TabIndex = 0;
            LblName.Text = "Name:";
            // 
            // SpeciesInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(551, 450);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "SpeciesInfoForm";
            Text = "SpeciesInfoForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            GrbxEnclosure.ResumeLayout(false);
            GrbxEnclosure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesIncubation).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesLifeSpan).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesWeight).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button BtnSaveSpecies;
        private ComboBox CmbxEnclosure;
        private ComboBox CmbxEndagered;
        private Label LblEnclosure;
        private TextBox TbxName;
        private Label LblDanger;
        private Label LblIncubationT;
        private Label LblName;
        private Button BtnDeleteSpecies;
        private NumericUpDown NudSpeciesWeight;
        private Label label1;
        private Label label2;
        private NumericUpDown NudSpeciesLifeSpan;
        private NumericUpDown NudSpeciesSize;
        private NumericUpDown NudSpeciesIncubation;
        private Label label3;
        private NumericUpDown NudSpeciesSpeed;
        private Label label4;
        private Button BtnNewEnclosure;
        private GroupBox GrbxEnclosure;
        private Button BtnDeleteEnclosure;
        private Button BtnSaveEnclosure;
        private TextBox TbxEName;
        private Label label5;
        private Button BtnEditEnclosure;
        private Button BtnCancel;
    }
}