namespace Roll_Dice_Win_Game
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.buttonResetPwd = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.BackColor = System.Drawing.Color.Transparent;
            this.buttonDashboard.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDashboard.ForeColor = System.Drawing.Color.Transparent;
            this.buttonDashboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonDashboard.Image")));
            this.buttonDashboard.Location = new System.Drawing.Point(61, 157);
            this.buttonDashboard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Size = new System.Drawing.Size(70, 29);
            this.buttonDashboard.TabIndex = 85;
            this.buttonDashboard.Text = "Cancel";
            this.buttonDashboard.UseVisualStyleBackColor = false;
            this.buttonDashboard.Click += new System.EventHandler(this.ButtonDashboard_Click);
            // 
            // buttonResetPwd
            // 
            this.buttonResetPwd.BackColor = System.Drawing.Color.Transparent;
            this.buttonResetPwd.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetPwd.ForeColor = System.Drawing.Color.Transparent;
            this.buttonResetPwd.Image = ((System.Drawing.Image)(resources.GetObject("buttonResetPwd.Image")));
            this.buttonResetPwd.Location = new System.Drawing.Point(147, 157);
            this.buttonResetPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonResetPwd.Name = "buttonResetPwd";
            this.buttonResetPwd.Size = new System.Drawing.Size(144, 29);
            this.buttonResetPwd.TabIndex = 84;
            this.buttonResetPwd.Text = "Reset Password";
            this.buttonResetPwd.UseVisualStyleBackColor = false;
            this.buttonResetPwd.Click += new System.EventHandler(this.ButtonResetPwd_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(74, 112);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPassword.Multiline = true;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(164, 25);
            this.textBoxPassword.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ink Free", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(56, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 34);
            this.label1.TabIndex = 82;
            this.label1.Text = "Reset Password";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(74, 93);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(0, 13);
            this.labelUsername.TabIndex = 86;
            this.labelUsername.Visible = false;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(321, 214);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonDashboard);
            this.Controls.Add(this.buttonResetPwd);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Button buttonResetPwd;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUsername;
    }
}