namespace WindowsFormApp
{
    partial class AddAnimalSpeciesForm
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
            LsbxSpecies = new ListBox();
            BtnAddSpecies = new Button();
            PnlForms = new Panel();
            BtnAddAnimal = new Button();
            SuspendLayout();
            // 
            // LsbxSpecies
            // 
            LsbxSpecies.BackColor = Color.White;
            LsbxSpecies.FormattingEnabled = true;
            LsbxSpecies.ItemHeight = 15;
            LsbxSpecies.Location = new Point(14, 14);
            LsbxSpecies.Margin = new Padding(4, 3, 4, 3);
            LsbxSpecies.Name = "LsbxSpecies";
            LsbxSpecies.Size = new Size(242, 379);
            LsbxSpecies.TabIndex = 0;
            LsbxSpecies.MouseDoubleClick += LsbxSpecies_MouseDoubleClick;
            LsbxSpecies.MouseDown += LsbxSpecies_MouseDown;
            // 
            // BtnAddSpecies
            // 
            BtnAddSpecies.BackColor = Color.FromArgb(24, 30, 54);
            BtnAddSpecies.FlatStyle = FlatStyle.Popup;
            BtnAddSpecies.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddSpecies.ForeColor = Color.White;
            BtnAddSpecies.Location = new Point(14, 399);
            BtnAddSpecies.Margin = new Padding(4, 3, 4, 3);
            BtnAddSpecies.Name = "BtnAddSpecies";
            BtnAddSpecies.Size = new Size(113, 37);
            BtnAddSpecies.TabIndex = 1;
            BtnAddSpecies.Text = "Add species";
            BtnAddSpecies.UseVisualStyleBackColor = false;
            BtnAddSpecies.Click += BtnAddSpecies_Click;
            // 
            // PnlForms
            // 
            PnlForms.Location = new Point(264, -1);
            PnlForms.Margin = new Padding(4, 3, 4, 3);
            PnlForms.Name = "PnlForms";
            PnlForms.Size = new Size(551, 450);
            PnlForms.TabIndex = 3;
            // 
            // BtnAddAnimal
            // 
            BtnAddAnimal.BackColor = Color.FromArgb(24, 30, 54);
            BtnAddAnimal.Enabled = false;
            BtnAddAnimal.FlatStyle = FlatStyle.Popup;
            BtnAddAnimal.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddAnimal.ForeColor = Color.White;
            BtnAddAnimal.Location = new Point(143, 399);
            BtnAddAnimal.Name = "BtnAddAnimal";
            BtnAddAnimal.Size = new Size(113, 37);
            BtnAddAnimal.TabIndex = 4;
            BtnAddAnimal.Text = "Add Animal";
            BtnAddAnimal.UseVisualStyleBackColor = false;
            BtnAddAnimal.Visible = false;
            BtnAddAnimal.Click += BtnAddAnimal_Click;
            // 
            // AddAnimalSpeciesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(812, 448);
            Controls.Add(BtnAddAnimal);
            Controls.Add(PnlForms);
            Controls.Add(BtnAddSpecies);
            Controls.Add(LsbxSpecies);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddAnimalSpeciesForm";
            Text = "AddAnimal";
            ResumeLayout(false);
        }

        #endregion

        private ListBox LsbxSpecies;
        private Button BtnAddSpecies;
        private Panel PnlForms;
        private Button BtnAddAnimal;
    }
}