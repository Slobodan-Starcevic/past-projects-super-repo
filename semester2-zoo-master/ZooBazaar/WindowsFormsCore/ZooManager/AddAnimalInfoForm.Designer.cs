namespace WindowsFormApp
{
    partial class AddAnimalInfoForm
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
            NudSpeciesSpeed = new NumericUpDown();
            label3 = new Label();
            NudSpeciesSize = new NumericUpDown();
            label5 = new Label();
            NudSpeciesWeight = new NumericUpDown();
            label6 = new Label();
            CbxLeaveDate = new CheckBox();
            BtnNewAnimal = new Button();
            DtpAnimalLeaveDate = new DateTimePicker();
            label2 = new Label();
            DtpAnimalAriveDate = new DateTimePicker();
            label1 = new Label();
            BtnDeleteAnimal = new Button();
            label4 = new Label();
            CmbxListAnimals = new ComboBox();
            BtnCancel = new Button();
            BtnSaveAnimal = new Button();
            CmbxSex = new ComboBox();
            DtpBirthdate = new DateTimePicker();
            TbxName = new TextBox();
            LblSex = new Label();
            LblBirhtdate = new Label();
            LblName = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesWeight).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(NudSpeciesSpeed);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(NudSpeciesSize);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(NudSpeciesWeight);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(CbxLeaveDate);
            groupBox1.Controls.Add(BtnNewAnimal);
            groupBox1.Controls.Add(DtpAnimalLeaveDate);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(DtpAnimalAriveDate);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(BtnDeleteAnimal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(CmbxListAnimals);
            groupBox1.Controls.Add(BtnCancel);
            groupBox1.Controls.Add(BtnSaveAnimal);
            groupBox1.Controls.Add(CmbxSex);
            groupBox1.Controls.Add(DtpBirthdate);
            groupBox1.Controls.Add(TbxName);
            groupBox1.Controls.Add(LblSex);
            groupBox1.Controls.Add(LblBirhtdate);
            groupBox1.Controls.Add(LblName);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Location = new Point(13, 12);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(525, 426);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Animal info";
            // 
            // NudSpeciesSpeed
            // 
            NudSpeciesSpeed.Location = new Point(44, 287);
            NudSpeciesSpeed.Maximum = new decimal(new int[] { 2147483640, 0, 0, 0 });
            NudSpeciesSpeed.Name = "NudSpeciesSpeed";
            NudSpeciesSpeed.Size = new Size(121, 23);
            NudSpeciesSpeed.TabIndex = 6;
            NudSpeciesSpeed.ValueChanged += NudSpeciesSpeed_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 269);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 40;
            label3.Text = "Speed in km/h:";
            // 
            // NudSpeciesSize
            // 
            NudSpeciesSize.Location = new Point(44, 227);
            NudSpeciesSize.Maximum = new decimal(new int[] { 2147483640, 0, 0, 0 });
            NudSpeciesSize.Name = "NudSpeciesSize";
            NudSpeciesSize.Size = new Size(121, 23);
            NudSpeciesSize.TabIndex = 5;
            NudSpeciesSize.ValueChanged += NudSpeciesSize_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 209);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 38;
            label5.Text = "Size in cm:";
            // 
            // NudSpeciesWeight
            // 
            NudSpeciesWeight.Location = new Point(44, 172);
            NudSpeciesWeight.Maximum = new decimal(new int[] { 2147483640, 0, 0, 0 });
            NudSpeciesWeight.Name = "NudSpeciesWeight";
            NudSpeciesWeight.Size = new Size(121, 23);
            NudSpeciesWeight.TabIndex = 4;
            NudSpeciesWeight.ValueChanged += NudSpeciesWeight_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(44, 154);
            label6.Name = "label6";
            label6.Size = new Size(77, 15);
            label6.TabIndex = 36;
            label6.Text = "Weight in kg:";
            label6.Click += label6_Click;
            // 
            // CbxLeaveDate
            // 
            CbxLeaveDate.AutoSize = true;
            CbxLeaveDate.Location = new Point(318, 201);
            CbxLeaveDate.Name = "CbxLeaveDate";
            CbxLeaveDate.Size = new Size(117, 19);
            CbxLeaveDate.TabIndex = 11;
            CbxLeaveDate.Text = "No leave date yet";
            CbxLeaveDate.UseVisualStyleBackColor = true;
            CbxLeaveDate.CheckedChanged += CbxLeaveDate_CheckedChanged;
            // 
            // BtnNewAnimal
            // 
            BtnNewAnimal.BackColor = Color.FromArgb(24, 30, 54);
            BtnNewAnimal.Enabled = false;
            BtnNewAnimal.FlatAppearance.BorderSize = 0;
            BtnNewAnimal.FlatStyle = FlatStyle.Flat;
            BtnNewAnimal.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnNewAnimal.ForeColor = SystemColors.Control;
            BtnNewAnimal.Location = new Point(172, 66);
            BtnNewAnimal.Margin = new Padding(4, 3, 4, 3);
            BtnNewAnimal.Name = "BtnNewAnimal";
            BtnNewAnimal.Size = new Size(87, 24);
            BtnNewAnimal.TabIndex = 2;
            BtnNewAnimal.Text = "New Animal";
            BtnNewAnimal.UseVisualStyleBackColor = false;
            BtnNewAnimal.Visible = false;
            BtnNewAnimal.Click += BtnNewAnimal_Click;
            // 
            // DtpAnimalLeaveDate
            // 
            DtpAnimalLeaveDate.Format = DateTimePickerFormat.Short;
            DtpAnimalLeaveDate.Location = new Point(318, 172);
            DtpAnimalLeaveDate.Margin = new Padding(4, 3, 4, 3);
            DtpAnimalLeaveDate.MaxDate = new DateTime(2023, 3, 15, 0, 0, 0, 0);
            DtpAnimalLeaveDate.Name = "DtpAnimalLeaveDate";
            DtpAnimalLeaveDate.Size = new Size(121, 23);
            DtpAnimalLeaveDate.TabIndex = 10;
            DtpAnimalLeaveDate.Value = new DateTime(2023, 3, 15, 0, 0, 0, 0);
            DtpAnimalLeaveDate.ValueChanged += DtpAnimalLeaveDate_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(318, 152);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 28;
            label2.Text = "Leave date:";
            // 
            // DtpAnimalAriveDate
            // 
            DtpAnimalAriveDate.Format = DateTimePickerFormat.Short;
            DtpAnimalAriveDate.Location = new Point(318, 118);
            DtpAnimalAriveDate.Margin = new Padding(4, 3, 4, 3);
            DtpAnimalAriveDate.MaxDate = new DateTime(2023, 3, 15, 0, 0, 0, 0);
            DtpAnimalAriveDate.Name = "DtpAnimalAriveDate";
            DtpAnimalAriveDate.Size = new Size(121, 23);
            DtpAnimalAriveDate.TabIndex = 9;
            DtpAnimalAriveDate.Value = new DateTime(2023, 3, 15, 0, 0, 0, 0);
            DtpAnimalAriveDate.ValueChanged += DtpAnimalAriveDate_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(318, 100);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 26;
            label1.Text = "Arrival date:";
            // 
            // BtnDeleteAnimal
            // 
            BtnDeleteAnimal.BackColor = Color.FromArgb(24, 30, 54);
            BtnDeleteAnimal.Enabled = false;
            BtnDeleteAnimal.FlatAppearance.BorderSize = 0;
            BtnDeleteAnimal.FlatStyle = FlatStyle.Flat;
            BtnDeleteAnimal.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDeleteAnimal.ForeColor = SystemColors.Control;
            BtnDeleteAnimal.Location = new Point(318, 253);
            BtnDeleteAnimal.Margin = new Padding(4, 3, 4, 3);
            BtnDeleteAnimal.Name = "BtnDeleteAnimal";
            BtnDeleteAnimal.Size = new Size(121, 37);
            BtnDeleteAnimal.TabIndex = 14;
            BtnDeleteAnimal.Text = "Delete";
            BtnDeleteAnimal.UseVisualStyleBackColor = false;
            BtnDeleteAnimal.Visible = false;
            BtnDeleteAnimal.Click += BtnDeleteAnimal_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 48);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 11;
            label4.Text = "List of animals:";
            // 
            // CmbxListAnimals
            // 
            CmbxListAnimals.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbxListAnimals.FormattingEnabled = true;
            CmbxListAnimals.Location = new Point(44, 66);
            CmbxListAnimals.Name = "CmbxListAnimals";
            CmbxListAnimals.Size = new Size(121, 23);
            CmbxListAnimals.TabIndex = 20;
            CmbxListAnimals.SelectedIndexChanged += CmbxListAnimals_SelectedIndexChanged;
            // 
            // BtnCancel
            // 
            BtnCancel.BackColor = Color.FromArgb(24, 30, 54);
            BtnCancel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatStyle = FlatStyle.Flat;
            BtnCancel.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnCancel.ForeColor = SystemColors.Control;
            BtnCancel.Location = new Point(318, 339);
            BtnCancel.Margin = new Padding(4, 3, 4, 3);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(121, 37);
            BtnCancel.TabIndex = 13;
            BtnCancel.Text = "Cancel";
            BtnCancel.UseVisualStyleBackColor = false;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnSaveAnimal
            // 
            BtnSaveAnimal.BackColor = Color.FromArgb(24, 30, 54);
            BtnSaveAnimal.Enabled = false;
            BtnSaveAnimal.FlatAppearance.BorderSize = 0;
            BtnSaveAnimal.FlatStyle = FlatStyle.Flat;
            BtnSaveAnimal.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnSaveAnimal.ForeColor = SystemColors.Control;
            BtnSaveAnimal.Location = new Point(318, 296);
            BtnSaveAnimal.Margin = new Padding(4, 3, 4, 3);
            BtnSaveAnimal.Name = "BtnSaveAnimal";
            BtnSaveAnimal.Size = new Size(121, 37);
            BtnSaveAnimal.TabIndex = 12;
            BtnSaveAnimal.Text = "Save";
            BtnSaveAnimal.UseVisualStyleBackColor = false;
            BtnSaveAnimal.Click += BtnSave_Click;
            // 
            // CmbxSex
            // 
            CmbxSex.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbxSex.FormattingEnabled = true;
            CmbxSex.Location = new Point(318, 67);
            CmbxSex.Margin = new Padding(4, 3, 4, 3);
            CmbxSex.Name = "CmbxSex";
            CmbxSex.Size = new Size(121, 23);
            CmbxSex.TabIndex = 8;
            CmbxSex.SelectionChangeCommitted += CmbxSex_SelectionChangeCommitted;
            CmbxSex.Leave += CmbxSex_Leave;
            // 
            // DtpBirthdate
            // 
            DtpBirthdate.Format = DateTimePickerFormat.Short;
            DtpBirthdate.Location = new Point(44, 345);
            DtpBirthdate.Margin = new Padding(4, 3, 4, 3);
            DtpBirthdate.MaxDate = new DateTime(2023, 3, 15, 0, 0, 0, 0);
            DtpBirthdate.Name = "DtpBirthdate";
            DtpBirthdate.Size = new Size(121, 23);
            DtpBirthdate.TabIndex = 7;
            DtpBirthdate.Value = new DateTime(2023, 3, 15, 0, 0, 0, 0);
            DtpBirthdate.ValueChanged += DtpBirthdate_ValueChanged;
            // 
            // TbxName
            // 
            TbxName.Location = new Point(44, 118);
            TbxName.Margin = new Padding(4, 3, 4, 3);
            TbxName.Name = "TbxName";
            TbxName.Size = new Size(121, 23);
            TbxName.TabIndex = 3;
            TbxName.TextChanged += TbxName_TextChanged;
            // 
            // LblSex
            // 
            LblSex.AutoSize = true;
            LblSex.Location = new Point(318, 49);
            LblSex.Margin = new Padding(4, 0, 4, 0);
            LblSex.Name = "LblSex";
            LblSex.Size = new Size(28, 15);
            LblSex.TabIndex = 2;
            LblSex.Text = "Sex:";
            // 
            // LblBirhtdate
            // 
            LblBirhtdate.AutoSize = true;
            LblBirhtdate.Location = new Point(44, 327);
            LblBirhtdate.Margin = new Padding(4, 0, 4, 0);
            LblBirhtdate.Name = "LblBirhtdate";
            LblBirhtdate.Size = new Size(58, 15);
            LblBirhtdate.TabIndex = 1;
            LblBirhtdate.Text = "Birthdate:";
            // 
            // LblName
            // 
            LblName.AutoSize = true;
            LblName.Location = new Point(44, 100);
            LblName.Margin = new Padding(4, 0, 4, 0);
            LblName.Name = "LblName";
            LblName.Size = new Size(42, 15);
            LblName.TabIndex = 0;
            LblName.Text = "Name:";
            // 
            // AddAnimalInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(551, 450);
            Controls.Add(groupBox1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddAnimalInfoForm";
            Text = "AddAnimalInfoForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)NudSpeciesWeight).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button BtnCancel;
        private Button BtnSaveAnimal;
        private ComboBox CmbxSex;
        private DateTimePicker DtpBirthdate;
        private TextBox TbxName;
        private Label LblSex;
        private Label LblBirhtdate;
        private Label LblName;
        private Label label4;
        private ComboBox CmbxListAnimals;
        private Button BtnDeleteAnimal;
        private DateTimePicker DtpAnimalLeaveDate;
        private Label label2;
        private DateTimePicker DtpAnimalAriveDate;
        private Label label1;
        private Button BtnNewAnimal;
        private CheckBox CbxLeaveDate;
        private NumericUpDown NudSpeciesSpeed;
        private Label label3;
        private NumericUpDown NudSpeciesSize;
        private Label label5;
        private NumericUpDown NudSpeciesWeight;
        private Label label6;
    }
}