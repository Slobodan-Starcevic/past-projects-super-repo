namespace WindowsFormsCore.ZooManager
{
    partial class ContentAndViewableForm
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
            GbxContent = new GroupBox();
            label8 = new Label();
            TbxImageLink = new TextBox();
            label6 = new Label();
            CmbxOrder = new ComboBox();
            BtnNewContent = new Button();
            BtnDeleteNote = new Button();
            BtnSaveNote = new Button();
            TbxContentText = new TextBox();
            label3 = new Label();
            TbxTitleContent = new TextBox();
            label2 = new Label();
            label1 = new Label();
            CmbxListContents = new ComboBox();
            label4 = new Label();
            BtnAddToWebsite = new Button();
            BtnRemoveFormWebSite = new Button();
            label5 = new Label();
            LsBxNotOnline = new ListBox();
            LsBxOnline = new ListBox();
            RBtnEnclosures = new RadioButton();
            RBtnAnimals = new RadioButton();
            RBtnSpecies = new RadioButton();
            TbxSearch = new TextBox();
            label7 = new Label();
            GbxContent.SuspendLayout();
            SuspendLayout();
            // 
            // GbxContent
            // 
            GbxContent.Controls.Add(label8);
            GbxContent.Controls.Add(TbxImageLink);
            GbxContent.Controls.Add(label6);
            GbxContent.Controls.Add(CmbxOrder);
            GbxContent.Controls.Add(BtnNewContent);
            GbxContent.Controls.Add(BtnDeleteNote);
            GbxContent.Controls.Add(BtnSaveNote);
            GbxContent.Controls.Add(TbxContentText);
            GbxContent.Controls.Add(label3);
            GbxContent.Controls.Add(TbxTitleContent);
            GbxContent.Controls.Add(label2);
            GbxContent.Controls.Add(label1);
            GbxContent.Controls.Add(CmbxListContents);
            GbxContent.Enabled = false;
            GbxContent.Location = new Point(341, 12);
            GbxContent.Name = "GbxContent";
            GbxContent.Size = new Size(443, 377);
            GbxContent.TabIndex = 4;
            GbxContent.TabStop = false;
            GbxContent.Text = "content";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(52, 46);
            label8.Name = "label8";
            label8.Size = new Size(98, 15);
            label8.TabIndex = 53;
            label8.Text = "Profile photo link";
            // 
            // TbxImageLink
            // 
            TbxImageLink.Location = new Point(52, 64);
            TbxImageLink.Name = "TbxImageLink";
            TbxImageLink.PlaceholderText = "Please paste image link here";
            TbxImageLink.Size = new Size(202, 23);
            TbxImageLink.TabIndex = 51;
            TbxImageLink.TextChanged += TbxImageLink_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 147);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 28;
            label6.Text = "Order :";
            label6.Click += label6_Click;
            // 
            // CmbxOrder
            // 
            CmbxOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbxOrder.FormattingEnabled = true;
            CmbxOrder.Location = new Point(52, 165);
            CmbxOrder.Name = "CmbxOrder";
            CmbxOrder.Size = new Size(202, 23);
            CmbxOrder.TabIndex = 27;
            CmbxOrder.SelectionChangeCommitted += CmbxOrder_SelectionChangeCommitted;
            // 
            // BtnNewContent
            // 
            BtnNewContent.BackColor = Color.FromArgb(24, 30, 54);
            BtnNewContent.FlatAppearance.BorderSize = 0;
            BtnNewContent.FlatStyle = FlatStyle.Flat;
            BtnNewContent.ForeColor = Color.White;
            BtnNewContent.Location = new Point(295, 216);
            BtnNewContent.Name = "BtnNewContent";
            BtnNewContent.Size = new Size(106, 34);
            BtnNewContent.TabIndex = 26;
            BtnNewContent.Text = "New";
            BtnNewContent.UseVisualStyleBackColor = false;
            BtnNewContent.Click += BtnNewContent_Click;
            // 
            // BtnDeleteNote
            // 
            BtnDeleteNote.BackColor = Color.FromArgb(24, 30, 54);
            BtnDeleteNote.Enabled = false;
            BtnDeleteNote.FlatAppearance.BorderSize = 0;
            BtnDeleteNote.FlatStyle = FlatStyle.Flat;
            BtnDeleteNote.ForeColor = Color.White;
            BtnDeleteNote.Location = new Point(295, 296);
            BtnDeleteNote.Name = "BtnDeleteNote";
            BtnDeleteNote.Size = new Size(106, 34);
            BtnDeleteNote.TabIndex = 7;
            BtnDeleteNote.Text = "Delete";
            BtnDeleteNote.UseVisualStyleBackColor = false;
            BtnDeleteNote.Click += BtnDeleteNote_Click;
            // 
            // BtnSaveNote
            // 
            BtnSaveNote.BackColor = Color.FromArgb(24, 30, 54);
            BtnSaveNote.Enabled = false;
            BtnSaveNote.FlatAppearance.BorderSize = 0;
            BtnSaveNote.FlatStyle = FlatStyle.Flat;
            BtnSaveNote.ForeColor = Color.White;
            BtnSaveNote.Location = new Point(295, 256);
            BtnSaveNote.Name = "BtnSaveNote";
            BtnSaveNote.Size = new Size(106, 34);
            BtnSaveNote.TabIndex = 6;
            BtnSaveNote.Text = "Save";
            BtnSaveNote.UseVisualStyleBackColor = false;
            BtnSaveNote.Click += BtnSaveNote_Click;
            // 
            // TbxContentText
            // 
            TbxContentText.Location = new Point(52, 217);
            TbxContentText.Multiline = true;
            TbxContentText.Name = "TbxContentText";
            TbxContentText.Size = new Size(202, 113);
            TbxContentText.TabIndex = 5;
            TbxContentText.TextChanged += TbxContentText_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 199);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 4;
            label3.Text = "Main tekst:";
            // 
            // TbxTitleContent
            // 
            TbxTitleContent.Location = new Point(52, 116);
            TbxTitleContent.Name = "TbxTitleContent";
            TbxTitleContent.Size = new Size(202, 23);
            TbxTitleContent.TabIndex = 3;
            TbxTitleContent.TextChanged += TbxTitleContent_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 95);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 2;
            label2.Text = "Title:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 169);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 1;
            label1.Text = "List  of Contents";
            // 
            // CmbxListContents
            // 
            CmbxListContents.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbxListContents.FormattingEnabled = true;
            CmbxListContents.Location = new Point(295, 187);
            CmbxListContents.Name = "CmbxListContents";
            CmbxListContents.Size = new Size(106, 23);
            CmbxListContents.TabIndex = 0;
            CmbxListContents.SelectionChangeCommitted += CmbxListContents_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 232);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 6;
            label4.Text = "Not online";
            // 
            // BtnAddToWebsite
            // 
            BtnAddToWebsite.BackColor = Color.FromArgb(24, 30, 54);
            BtnAddToWebsite.Enabled = false;
            BtnAddToWebsite.FlatAppearance.BorderSize = 0;
            BtnAddToWebsite.FlatStyle = FlatStyle.Flat;
            BtnAddToWebsite.ForeColor = Color.White;
            BtnAddToWebsite.Location = new Point(12, 206);
            BtnAddToWebsite.Name = "BtnAddToWebsite";
            BtnAddToWebsite.Size = new Size(126, 23);
            BtnAddToWebsite.TabIndex = 7;
            BtnAddToWebsite.Text = "^ Add to website ^";
            BtnAddToWebsite.UseVisualStyleBackColor = false;
            BtnAddToWebsite.Click += BtnAddToWebsite_Click;
            // 
            // BtnRemoveFormWebSite
            // 
            BtnRemoveFormWebSite.BackColor = Color.FromArgb(24, 30, 54);
            BtnRemoveFormWebSite.Enabled = false;
            BtnRemoveFormWebSite.FlatAppearance.BorderSize = 0;
            BtnRemoveFormWebSite.FlatStyle = FlatStyle.Flat;
            BtnRemoveFormWebSite.ForeColor = Color.White;
            BtnRemoveFormWebSite.Location = new Point(144, 206);
            BtnRemoveFormWebSite.Name = "BtnRemoveFormWebSite";
            BtnRemoveFormWebSite.Size = new Size(164, 23);
            BtnRemoveFormWebSite.TabIndex = 8;
            BtnRemoveFormWebSite.Text = "V Remove from website V";
            BtnRemoveFormWebSite.UseVisualStyleBackColor = false;
            BtnRemoveFormWebSite.Click += BtnRemoveFormWebSite_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 43);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 10;
            label5.Text = "Online";
            // 
            // LsBxNotOnline
            // 
            LsBxNotOnline.FormattingEnabled = true;
            LsBxNotOnline.ItemHeight = 15;
            LsBxNotOnline.Location = new Point(12, 250);
            LsBxNotOnline.Name = "LsBxNotOnline";
            LsBxNotOnline.Size = new Size(296, 139);
            LsBxNotOnline.TabIndex = 11;
            LsBxNotOnline.SelectedValueChanged += LsBxNotOnline_SelectedValueChanged;
            LsBxNotOnline.MouseDown += LsBxNotOnline_MouseDown;
            // 
            // LsBxOnline
            // 
            LsBxOnline.FormattingEnabled = true;
            LsBxOnline.ItemHeight = 15;
            LsBxOnline.Location = new Point(12, 61);
            LsBxOnline.Name = "LsBxOnline";
            LsBxOnline.Size = new Size(296, 139);
            LsBxOnline.TabIndex = 12;
            LsBxOnline.SelectedValueChanged += LsBxOnline_SelectedValueChanged;
            LsBxOnline.MouseDown += LsBxOnline_MouseDown;
            // 
            // RBtnEnclosures
            // 
            RBtnEnclosures.AutoSize = true;
            RBtnEnclosures.Checked = true;
            RBtnEnclosures.Location = new Point(14, 19);
            RBtnEnclosures.Name = "RBtnEnclosures";
            RBtnEnclosures.Size = new Size(50, 19);
            RBtnEnclosures.TabIndex = 14;
            RBtnEnclosures.TabStop = true;
            RBtnEnclosures.Text = "Encl.";
            RBtnEnclosures.UseVisualStyleBackColor = true;
            RBtnEnclosures.CheckedChanged += RBtnEnclosures_CheckedChanged;
            // 
            // RBtnAnimals
            // 
            RBtnAnimals.AutoSize = true;
            RBtnAnimals.Location = new Point(70, 19);
            RBtnAnimals.Name = "RBtnAnimals";
            RBtnAnimals.Size = new Size(68, 19);
            RBtnAnimals.TabIndex = 15;
            RBtnAnimals.Text = "Animals";
            RBtnAnimals.UseVisualStyleBackColor = true;
            RBtnAnimals.CheckedChanged += RBtnAnimals_CheckedChanged;
            // 
            // RBtnSpecies
            // 
            RBtnSpecies.AutoSize = true;
            RBtnSpecies.Location = new Point(144, 19);
            RBtnSpecies.Name = "RBtnSpecies";
            RBtnSpecies.Size = new Size(64, 19);
            RBtnSpecies.TabIndex = 16;
            RBtnSpecies.Text = "Species";
            RBtnSpecies.UseVisualStyleBackColor = true;
            RBtnSpecies.CheckedChanged += RBtnSpecies_CheckedChanged;
            // 
            // TbxSearch
            // 
            TbxSearch.Location = new Point(208, 31);
            TbxSearch.Name = "TbxSearch";
            TbxSearch.Size = new Size(100, 23);
            TbxSearch.TabIndex = 17;
            TbxSearch.TextChanged += TbxSearch_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(208, 13);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 18;
            label7.Text = "Search :";
            // 
            // ContentAndViewableForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(796, 409);
            Controls.Add(label7);
            Controls.Add(TbxSearch);
            Controls.Add(RBtnSpecies);
            Controls.Add(RBtnAnimals);
            Controls.Add(RBtnEnclosures);
            Controls.Add(LsBxOnline);
            Controls.Add(LsBxNotOnline);
            Controls.Add(label5);
            Controls.Add(BtnRemoveFormWebSite);
            Controls.Add(BtnAddToWebsite);
            Controls.Add(label4);
            Controls.Add(GbxContent);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "ContentAndViewableForm";
            Text = "ContentAndViewableForm";
            GbxContent.ResumeLayout(false);
            GbxContent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GbxContent;
        private Button BtnNewContent;
        private Button BtnDeleteNote;
        private Button BtnSaveNote;
        private TextBox TbxContentText;
        private Label label3;
        private TextBox TbxTitleContent;
        private Label label2;
        private Label label1;
        private ComboBox CmbxListContents;
        private Label label4;
        private Button BtnAddToWebsite;
        private Button BtnRemoveFormWebSite;
        private Label label5;
        private ListBox LsBxNotOnline;
        private ListBox LsBxOnline;
        private Label label6;
        private ComboBox CmbxOrder;
        private RadioButton RBtnEnclosures;
        private RadioButton RBtnAnimals;
        private RadioButton RBtnSpecies;
        private TextBox TbxSearch;
        private Label label7;
        private TextBox TbxImageLink;
        private Label label8;
    }
}