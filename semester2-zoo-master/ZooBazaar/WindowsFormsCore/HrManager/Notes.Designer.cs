namespace WindowsFormsCore.HrManager
{
    partial class Notes
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
            listBoxNotes = new ListBox();
            comboBoxSpeciesOrNotFilter = new ComboBox();
            comboBoxEmployeeFilter = new ComboBox();
            buttonSwitchArchiveActive = new Button();
            panelNoteInfo = new Panel();
            panelNoteSpecies = new Panel();
            textBoxSpeciesName = new TextBox();
            labelSpeciesName = new Label();
            buttonArchive = new Button();
            label4 = new Label();
            textBoxNoteText = new TextBox();
            label3 = new Label();
            textBoxSubmitterName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            panelNoteInfo.SuspendLayout();
            panelNoteSpecies.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxNotes
            // 
            listBoxNotes.FormattingEnabled = true;
            listBoxNotes.ItemHeight = 15;
            listBoxNotes.Location = new Point(22, 60);
            listBoxNotes.Name = "listBoxNotes";
            listBoxNotes.Size = new Size(365, 349);
            listBoxNotes.TabIndex = 0;
            listBoxNotes.SelectedIndexChanged += listBoxNotes_SelectedIndexChanged;
            // 
            // comboBoxSpeciesOrNotFilter
            // 
            comboBoxSpeciesOrNotFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSpeciesOrNotFilter.FormattingEnabled = true;
            comboBoxSpeciesOrNotFilter.Location = new Point(22, 25);
            comboBoxSpeciesOrNotFilter.Name = "comboBoxSpeciesOrNotFilter";
            comboBoxSpeciesOrNotFilter.Size = new Size(120, 23);
            comboBoxSpeciesOrNotFilter.TabIndex = 1;
            comboBoxSpeciesOrNotFilter.SelectedIndexChanged += comboBoxSpeciesOrNotFilter_SelectedIndexChanged;
            // 
            // comboBoxEmployeeFilter
            // 
            comboBoxEmployeeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEmployeeFilter.FormattingEnabled = true;
            comboBoxEmployeeFilter.Location = new Point(148, 25);
            comboBoxEmployeeFilter.Name = "comboBoxEmployeeFilter";
            comboBoxEmployeeFilter.Size = new Size(120, 23);
            comboBoxEmployeeFilter.TabIndex = 2;
            comboBoxEmployeeFilter.SelectedIndexChanged += comboBoxEmployeeFilter_SelectedIndexChanged;
            // 
            // buttonSwitchArchiveActive
            // 
            buttonSwitchArchiveActive.BackColor = Color.FromArgb(24, 30, 54);
            buttonSwitchArchiveActive.FlatAppearance.BorderSize = 0;
            buttonSwitchArchiveActive.FlatStyle = FlatStyle.Flat;
            buttonSwitchArchiveActive.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSwitchArchiveActive.Location = new Point(274, 16);
            buttonSwitchArchiveActive.Name = "buttonSwitchArchiveActive";
            buttonSwitchArchiveActive.Size = new Size(113, 36);
            buttonSwitchArchiveActive.TabIndex = 3;
            buttonSwitchArchiveActive.Text = "Show archived";
            buttonSwitchArchiveActive.UseVisualStyleBackColor = false;
            buttonSwitchArchiveActive.Click += buttonSwitchArchiveActive_Click;
            // 
            // panelNoteInfo
            // 
            panelNoteInfo.Controls.Add(panelNoteSpecies);
            panelNoteInfo.Controls.Add(buttonArchive);
            panelNoteInfo.Controls.Add(label4);
            panelNoteInfo.Controls.Add(textBoxNoteText);
            panelNoteInfo.Controls.Add(label3);
            panelNoteInfo.Controls.Add(textBoxSubmitterName);
            panelNoteInfo.Location = new Point(405, 25);
            panelNoteInfo.Name = "panelNoteInfo";
            panelNoteInfo.Size = new Size(357, 384);
            panelNoteInfo.TabIndex = 4;
            // 
            // panelNoteSpecies
            // 
            panelNoteSpecies.Controls.Add(textBoxSpeciesName);
            panelNoteSpecies.Controls.Add(labelSpeciesName);
            panelNoteSpecies.Location = new Point(35, 3);
            panelNoteSpecies.Name = "panelNoteSpecies";
            panelNoteSpecies.Size = new Size(310, 66);
            panelNoteSpecies.TabIndex = 10;
            // 
            // textBoxSpeciesName
            // 
            textBoxSpeciesName.Enabled = false;
            textBoxSpeciesName.Location = new Point(22, 32);
            textBoxSpeciesName.Name = "textBoxSpeciesName";
            textBoxSpeciesName.Size = new Size(277, 23);
            textBoxSpeciesName.TabIndex = 8;
            // 
            // labelSpeciesName
            // 
            labelSpeciesName.AutoSize = true;
            labelSpeciesName.Location = new Point(22, 14);
            labelSpeciesName.Name = "labelSpeciesName";
            labelSpeciesName.Size = new Size(46, 15);
            labelSpeciesName.TabIndex = 9;
            labelSpeciesName.Text = "Species";
            // 
            // buttonArchive
            // 
            buttonArchive.BackColor = Color.FromArgb(24, 30, 54);
            buttonArchive.FlatAppearance.BorderSize = 0;
            buttonArchive.FlatStyle = FlatStyle.Flat;
            buttonArchive.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonArchive.Location = new Point(57, 332);
            buttonArchive.Name = "buttonArchive";
            buttonArchive.Size = new Size(277, 32);
            buttonArchive.TabIndex = 7;
            buttonArchive.Text = "Archive";
            buttonArchive.UseVisualStyleBackColor = false;
            buttonArchive.Click += buttonArchive_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 127);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 3;
            label4.Text = "Note";
            // 
            // textBoxNoteText
            // 
            textBoxNoteText.Enabled = false;
            textBoxNoteText.Location = new Point(57, 145);
            textBoxNoteText.Multiline = true;
            textBoxNoteText.Name = "textBoxNoteText";
            textBoxNoteText.Size = new Size(277, 172);
            textBoxNoteText.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 72);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 1;
            label3.Text = "Submitter";
            // 
            // textBoxSubmitterName
            // 
            textBoxSubmitterName.Enabled = false;
            textBoxSubmitterName.Location = new Point(57, 90);
            textBoxSubmitterName.Name = "textBoxSubmitterName";
            textBoxSubmitterName.Size = new Size(277, 23);
            textBoxSubmitterName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 7);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 5;
            label1.Text = "Type Filter";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 7);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 6;
            label2.Text = "Employee Filter";
            // 
            // Notes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(812, 448);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelNoteInfo);
            Controls.Add(buttonSwitchArchiveActive);
            Controls.Add(comboBoxEmployeeFilter);
            Controls.Add(comboBoxSpeciesOrNotFilter);
            Controls.Add(listBoxNotes);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Notes";
            Text = "Notes";
            Load += Notes_Load;
            panelNoteInfo.ResumeLayout(false);
            panelNoteInfo.PerformLayout();
            panelNoteSpecies.ResumeLayout(false);
            panelNoteSpecies.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxNotes;
        private ComboBox comboBoxSpeciesOrNotFilter;
        private ComboBox comboBoxEmployeeFilter;
        private Button buttonSwitchArchiveActive;
        private Panel panelNoteInfo;
        private Label label1;
        private Label label2;
        private TextBox textBoxNoteText;
        private Label label3;
        private TextBox textBoxSubmitterName;
        private Label label4;
        private Label labelSpeciesName;
        private TextBox textBoxSpeciesName;
        private Button buttonArchive;
        private Panel panelNoteSpecies;
    }
}