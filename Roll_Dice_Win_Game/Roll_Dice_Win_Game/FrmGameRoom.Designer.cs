namespace Roll_Dice_Win_Game
{
    partial class FrmGameRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGameRoom));
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelUserTurn = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewScoreList = new System.Windows.Forms.ListView();
            this.columnHeaderPlayer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelUserTurnUpdate = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.labelGameId = new System.Windows.Forms.Label();
            this.labelSessionUser = new System.Windows.Forms.Label();
            this.buttonRollDice = new System.Windows.Forms.Button();
            this.pictureBoxRollResult = new System.Windows.Forms.PictureBox();
            this.pictureBoxGameBoard = new System.Windows.Forms.PictureBox();
            this.pictureBoxRed = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlue = new System.Windows.Forms.PictureBox();
            this.pictureBoxGreen = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlack = new System.Windows.Forms.PictureBox();
            this.labelTokenColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRollResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlack)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Ink Free", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Red;
            this.labelTitle.Location = new System.Drawing.Point(211, 37);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(247, 34);
            this.labelTitle.TabIndex = 45;
            this.labelTitle.Text = "Roll Dice Win Game";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.SystemColors.Window;
            this.buttonExit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(22, 42);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(28, 28);
            this.buttonExit.TabIndex = 80;
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // labelUserTurn
            // 
            this.labelUserTurn.AutoSize = true;
            this.labelUserTurn.BackColor = System.Drawing.Color.Transparent;
            this.labelUserTurn.Font = new System.Drawing.Font("Ink Free", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserTurn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelUserTurn.Location = new System.Drawing.Point(436, 466);
            this.labelUserTurn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserTurn.Name = "labelUserTurn";
            this.labelUserTurn.Size = new System.Drawing.Size(91, 20);
            this.labelUserTurn.TabIndex = 83;
            this.labelUserTurn.Text = "User Turn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Ink Free", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(460, 318);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "Player score list";
            // 
            // listViewScoreList
            // 
            this.listViewScoreList.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.listViewScoreList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPlayer,
            this.columnHeaderScore});
            this.listViewScoreList.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewScoreList.FullRowSelect = true;
            this.listViewScoreList.GridLines = true;
            this.listViewScoreList.Location = new System.Drawing.Point(440, 341);
            this.listViewScoreList.Margin = new System.Windows.Forms.Padding(2);
            this.listViewScoreList.Name = "listViewScoreList";
            this.listViewScoreList.Size = new System.Drawing.Size(185, 107);
            this.listViewScoreList.TabIndex = 86;
            this.listViewScoreList.UseCompatibleStateImageBehavior = false;
            this.listViewScoreList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPlayer
            // 
            this.columnHeaderPlayer.Text = "Player";
            this.columnHeaderPlayer.Width = 120;
            // 
            // columnHeaderScore
            // 
            this.columnHeaderScore.Text = "Score";
            // 
            // labelUserTurnUpdate
            // 
            this.labelUserTurnUpdate.AutoSize = true;
            this.labelUserTurnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.labelUserTurnUpdate.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserTurnUpdate.ForeColor = System.Drawing.Color.Khaki;
            this.labelUserTurnUpdate.Location = new System.Drawing.Point(435, 486);
            this.labelUserTurnUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserTurnUpdate.Name = "labelUserTurnUpdate";
            this.labelUserTurnUpdate.Size = new System.Drawing.Size(107, 26);
            this.labelUserTurnUpdate.TabIndex = 87;
            this.labelUserTurnUpdate.Text = "user turn";
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHelp.BackgroundImage")));
            this.buttonHelp.Location = new System.Drawing.Point(584, 511);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(38, 41);
            this.buttonHelp.TabIndex = 88;
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // labelGameId
            // 
            this.labelGameId.AutoSize = true;
            this.labelGameId.BackColor = System.Drawing.Color.Transparent;
            this.labelGameId.Font = new System.Drawing.Font("Ink Free", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameId.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelGameId.Location = new System.Drawing.Point(488, 154);
            this.labelGameId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGameId.Name = "labelGameId";
            this.labelGameId.Size = new System.Drawing.Size(97, 27);
            this.labelGameId.TabIndex = 89;
            this.labelGameId.Text = "GameId";
            // 
            // labelSessionUser
            // 
            this.labelSessionUser.AutoSize = true;
            this.labelSessionUser.BackColor = System.Drawing.Color.Transparent;
            this.labelSessionUser.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSessionUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSessionUser.Location = new System.Drawing.Point(448, 118);
            this.labelSessionUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSessionUser.Name = "labelSessionUser";
            this.labelSessionUser.Size = new System.Drawing.Size(144, 20);
            this.labelSessionUser.TabIndex = 90;
            this.labelSessionUser.Text = "session user name";
            // 
            // buttonRollDice
            // 
            this.buttonRollDice.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRollDice.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonRollDice.Image = ((System.Drawing.Image)(resources.GetObject("buttonRollDice.Image")));
            this.buttonRollDice.Location = new System.Drawing.Point(496, 266);
            this.buttonRollDice.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRollDice.Name = "buttonRollDice";
            this.buttonRollDice.Size = new System.Drawing.Size(68, 34);
            this.buttonRollDice.TabIndex = 92;
            this.buttonRollDice.Text = "Roll";
            this.buttonRollDice.UseVisualStyleBackColor = true;
            this.buttonRollDice.Click += new System.EventHandler(this.ButtonRollDice_Click);
            // 
            // pictureBoxRollResult
            // 
            this.pictureBoxRollResult.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxRollResult.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRollResult.Image")));
            this.pictureBoxRollResult.Location = new System.Drawing.Point(496, 194);
            this.pictureBoxRollResult.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxRollResult.Name = "pictureBoxRollResult";
            this.pictureBoxRollResult.Size = new System.Drawing.Size(68, 59);
            this.pictureBoxRollResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRollResult.TabIndex = 93;
            this.pictureBoxRollResult.TabStop = false;
            // 
            // pictureBoxGameBoard
            // 
            this.pictureBoxGameBoard.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGameBoard.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGameBoard.Image")));
            this.pictureBoxGameBoard.Location = new System.Drawing.Point(22, 118);
            this.pictureBoxGameBoard.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxGameBoard.Name = "pictureBoxGameBoard";
            this.pictureBoxGameBoard.Size = new System.Drawing.Size(400, 434);
            this.pictureBoxGameBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGameBoard.TabIndex = 94;
            this.pictureBoxGameBoard.TabStop = false;
            // 
            // pictureBoxRed
            // 
            this.pictureBoxRed.BackColor = System.Drawing.Color.White;
            this.pictureBoxRed.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRed.Image")));
            this.pictureBoxRed.Location = new System.Drawing.Point(27, 176);
            this.pictureBoxRed.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxRed.Name = "pictureBoxRed";
            this.pictureBoxRed.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRed.TabIndex = 95;
            this.pictureBoxRed.TabStop = false;
            // 
            // pictureBoxBlue
            // 
            this.pictureBoxBlue.BackColor = System.Drawing.Color.White;
            this.pictureBoxBlue.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBlue.Image")));
            this.pictureBoxBlue.Location = new System.Drawing.Point(27, 124);
            this.pictureBoxBlue.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxBlue.Name = "pictureBoxBlue";
            this.pictureBoxBlue.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBlue.TabIndex = 96;
            this.pictureBoxBlue.TabStop = false;
            // 
            // pictureBoxGreen
            // 
            this.pictureBoxGreen.BackColor = System.Drawing.Color.White;
            this.pictureBoxGreen.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGreen.Image")));
            this.pictureBoxGreen.Location = new System.Drawing.Point(73, 124);
            this.pictureBoxGreen.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxGreen.Name = "pictureBoxGreen";
            this.pictureBoxGreen.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxGreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGreen.TabIndex = 97;
            this.pictureBoxGreen.TabStop = false;
            // 
            // pictureBoxBlack
            // 
            this.pictureBoxBlack.BackColor = System.Drawing.Color.White;
            this.pictureBoxBlack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBlack.Image")));
            this.pictureBoxBlack.Location = new System.Drawing.Point(73, 176);
            this.pictureBoxBlack.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxBlack.Name = "pictureBoxBlack";
            this.pictureBoxBlack.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxBlack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBlack.TabIndex = 98;
            this.pictureBoxBlack.TabStop = false;
            // 
            // labelTokenColor
            // 
            this.labelTokenColor.AutoSize = true;
            this.labelTokenColor.Location = new System.Drawing.Point(550, 58);
            this.labelTokenColor.Name = "labelTokenColor";
            this.labelTokenColor.Size = new System.Drawing.Size(0, 13);
            this.labelTokenColor.TabIndex = 99;
            this.labelTokenColor.Visible = false;
            // 
            // FrmGameRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(645, 574);
            this.Controls.Add(this.labelTokenColor);
            this.Controls.Add(this.pictureBoxBlack);
            this.Controls.Add(this.pictureBoxGreen);
            this.Controls.Add(this.pictureBoxBlue);
            this.Controls.Add(this.pictureBoxRed);
            this.Controls.Add(this.pictureBoxGameBoard);
            this.Controls.Add(this.pictureBoxRollResult);
            this.Controls.Add(this.buttonRollDice);
            this.Controls.Add(this.labelSessionUser);
            this.Controls.Add(this.labelGameId);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.labelUserTurnUpdate);
            this.Controls.Add(this.listViewScoreList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelUserTurn);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelTitle);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmGameRoom";
            this.Text = "Game Room";
            
            this.Load += new System.EventHandler(this.FrmGameRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRollResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelUserTurn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewScoreList;
        private System.Windows.Forms.ColumnHeader columnHeaderPlayer;
        private System.Windows.Forms.ColumnHeader columnHeaderScore;
        private System.Windows.Forms.Label labelUserTurnUpdate;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Label labelGameId;
        private System.Windows.Forms.Label labelSessionUser;
        private System.Windows.Forms.Button buttonRollDice;
        private System.Windows.Forms.PictureBox pictureBoxRollResult;
        private System.Windows.Forms.PictureBox pictureBoxGameBoard;
        private System.Windows.Forms.PictureBox pictureBoxRed;
        private System.Windows.Forms.PictureBox pictureBoxBlue;
        private System.Windows.Forms.PictureBox pictureBoxGreen;
        private System.Windows.Forms.PictureBox pictureBoxBlack;
        private System.Windows.Forms.Label labelTokenColor;
    }
}