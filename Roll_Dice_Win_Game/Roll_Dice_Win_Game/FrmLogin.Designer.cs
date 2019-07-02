namespace Roll_Dice_Win_Game
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelGameTitle = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelUsernameError = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelLoginError = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(262, 260);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(56, 34);
            this.buttonExit.TabIndex = 16;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Enabled = false;
            this.buttonLogIn.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogIn.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonLogIn.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogIn.Image")));
            this.buttonLogIn.Location = new System.Drawing.Point(440, 260);
            this.buttonLogIn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(68, 34);
            this.buttonLogIn.TabIndex = 15;
            this.buttonLogIn.Text = "LogIn";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBoxUserName.Location = new System.Drawing.Point(350, 145);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUserName.Multiline = true;
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(160, 29);
            this.textBoxUserName.TabIndex = 14;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // labelGameTitle
            // 
            this.labelGameTitle.AutoSize = true;
            this.labelGameTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelGameTitle.Font = new System.Drawing.Font("Ink Free", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameTitle.ForeColor = System.Drawing.Color.Red;
            this.labelGameTitle.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelGameTitle.Location = new System.Drawing.Point(202, 56);
            this.labelGameTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGameTitle.Name = "labelGameTitle";
            this.labelGameTitle.Size = new System.Drawing.Size(247, 34);
            this.labelGameTitle.TabIndex = 13;
            this.labelGameTitle.Text = "Roll Dice Win Game";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBoxPassword.Location = new System.Drawing.Point(350, 188);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPassword.Multiline = true;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(160, 29);
            this.textBoxPassword.TabIndex = 17;
            this.textBoxPassword.Visible = false;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // labelUsernameError
            // 
            this.labelUsernameError.AutoSize = true;
            this.labelUsernameError.BackColor = System.Drawing.Color.LightGray;
            this.labelUsernameError.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsernameError.ForeColor = System.Drawing.Color.Red;
            this.labelUsernameError.Location = new System.Drawing.Point(356, 123);
            this.labelUsernameError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsernameError.Name = "labelUsernameError";
            this.labelUsernameError.Size = new System.Drawing.Size(0, 14);
            this.labelUsernameError.TabIndex = 18;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonRegister.Image = ((System.Drawing.Image)(resources.GetObject("buttonRegister.Image")));
            this.buttonRegister.Location = new System.Drawing.Point(360, 260);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(76, 34);
            this.buttonRegister.TabIndex = 19;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // labelLoginError
            // 
            this.labelLoginError.AutoSize = true;
            this.labelLoginError.BackColor = System.Drawing.Color.LightGray;
            this.labelLoginError.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginError.ForeColor = System.Drawing.Color.Red;
            this.labelLoginError.Location = new System.Drawing.Point(360, 231);
            this.labelLoginError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLoginError.Name = "labelLoginError";
            this.labelLoginError.Size = new System.Drawing.Size(0, 14);
            this.labelLoginError.TabIndex = 20;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCheck.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonCheck.Image = ((System.Drawing.Image)(resources.GetObject("buttonCheck.Image")));
            this.buttonCheck.Location = new System.Drawing.Point(545, 145);
            this.buttonCheck.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(56, 34);
            this.buttonCheck.TabIndex = 21;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.Transparent;
            this.labelUsername.Location = new System.Drawing.Point(266, 150);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(72, 18);
            this.labelUsername.TabIndex = 87;
            this.labelUsername.Text = "Username";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.Transparent;
            this.labelPassword.Location = new System.Drawing.Point(266, 193);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(72, 18);
            this.labelPassword.TabIndex = 88;
            this.labelPassword.Text = "Password";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelPassword.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 128);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 189);
            this.pictureBox1.TabIndex = 89;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(647, 347);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.labelLoginError);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.labelUsernameError);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelGameTitle);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roll Dice Win Game";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelGameTitle;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelUsernameError;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label labelLoginError;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

