namespace WindowsFormApp
{
    partial class LogInForm
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
            label1 = new Label();
            label2 = new Label();
            TxBxLogInPassWord = new TextBox();
            TxBxLogInEmail = new TextBox();
            BtnConfirm = new Button();
            BtnReset = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(348, 95);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(348, 150);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // TxBxLogInPassWord
            // 
            TxBxLogInPassWord.Location = new Point(348, 168);
            TxBxLogInPassWord.Margin = new Padding(4, 3, 4, 3);
            TxBxLogInPassWord.Name = "TxBxLogInPassWord";
            TxBxLogInPassWord.Size = new Size(236, 23);
            TxBxLogInPassWord.TabIndex = 2;
            // 
            // TxBxLogInEmail
            // 
            TxBxLogInEmail.Location = new Point(348, 113);
            TxBxLogInEmail.Margin = new Padding(4, 3, 4, 3);
            TxBxLogInEmail.Name = "TxBxLogInEmail";
            TxBxLogInEmail.Size = new Size(236, 23);
            TxBxLogInEmail.TabIndex = 1;
            // 
            // BtnConfirm
            // 
            BtnConfirm.BackColor = Color.FromArgb(24, 30, 54);
            BtnConfirm.FlatAppearance.BorderSize = 0;
            BtnConfirm.FlatStyle = FlatStyle.Flat;
            BtnConfirm.ForeColor = SystemColors.Control;
            BtnConfirm.Location = new Point(348, 208);
            BtnConfirm.Margin = new Padding(4, 3, 4, 3);
            BtnConfirm.Name = "BtnConfirm";
            BtnConfirm.Size = new Size(114, 39);
            BtnConfirm.TabIndex = 3;
            BtnConfirm.Text = "Confirm";
            BtnConfirm.UseVisualStyleBackColor = false;
            BtnConfirm.Click += BtnConfirm_Click;
            // 
            // BtnReset
            // 
            BtnReset.BackColor = Color.FromArgb(24, 30, 54);
            BtnReset.FlatAppearance.BorderSize = 0;
            BtnReset.FlatStyle = FlatStyle.Flat;
            BtnReset.ForeColor = SystemColors.Control;
            BtnReset.Location = new Point(470, 208);
            BtnReset.Margin = new Padding(4, 3, 4, 3);
            BtnReset.Name = "BtnReset";
            BtnReset.Size = new Size(114, 39);
            BtnReset.TabIndex = 4;
            BtnReset.Text = "Reset";
            BtnReset.UseVisualStyleBackColor = false;
            BtnReset.Click += BtnReset_Click;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(922, 447);
            Controls.Add(BtnReset);
            Controls.Add(BtnConfirm);
            Controls.Add(TxBxLogInEmail);
            Controls.Add(TxBxLogInPassWord);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "LogInForm";
            Text = "LogInForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox TxBxLogInPassWord;
        private TextBox TxBxLogInEmail;
        private Button BtnConfirm;
        private Button BtnReset;
    }
}