namespace Roll_Dice_Win_Game
{
    partial class FrmPlayerDashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlayerDashboard));
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.labelGameTitle = new System.Windows.Forms.Label();
            this.labelScoreTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewScoreList = new System.Windows.Forms.ListView();
            this.columnPlayer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewGameList = new System.Windows.Forms.ListView();
            this.columnHost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnGameId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripGame = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.joinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonManagePlayer = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelIsAdmin = new System.Windows.Forms.Label();
            this.timerRefreshScore = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.SystemColors.Window;
            this.buttonLogout.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonLogout.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogout.Image")));
            this.buttonLogout.Location = new System.Drawing.Point(29, 32);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(28, 28);
            this.buttonLogout.TabIndex = 79;
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogout_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.White;
            this.buttonSettings.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.ForeColor = System.Drawing.Color.Transparent;
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(662, 51);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(26, 28);
            this.buttonSettings.TabIndex = 77;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonStartGame.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.ForeColor = System.Drawing.Color.Transparent;
            this.buttonStartGame.Image = ((System.Drawing.Image)(resources.GetObject("buttonStartGame.Image")));
            this.buttonStartGame.Location = new System.Drawing.Point(647, 383);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(41, 32);
            this.buttonStartGame.TabIndex = 76;
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.ButtonStartGame_Click);
            // 
            // labelGameTitle
            // 
            this.labelGameTitle.AutoSize = true;
            this.labelGameTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelGameTitle.Font = new System.Drawing.Font("Ink Free", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameTitle.ForeColor = System.Drawing.Color.Transparent;
            this.labelGameTitle.Location = new System.Drawing.Point(316, 103);
            this.labelGameTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGameTitle.Name = "labelGameTitle";
            this.labelGameTitle.Size = new System.Drawing.Size(74, 20);
            this.labelGameTitle.TabIndex = 61;
            this.labelGameTitle.Text = "Game(s)";
            // 
            // labelScoreTitle
            // 
            this.labelScoreTitle.AutoSize = true;
            this.labelScoreTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelScoreTitle.Font = new System.Drawing.Font("Ink Free", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScoreTitle.ForeColor = System.Drawing.Color.Transparent;
            this.labelScoreTitle.Location = new System.Drawing.Point(38, 103);
            this.labelScoreTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScoreTitle.Name = "labelScoreTitle";
            this.labelScoreTitle.Size = new System.Drawing.Size(128, 20);
            this.labelScoreTitle.TabIndex = 60;
            this.labelScoreTitle.Text = "Online Player(s)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ink Free", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(263, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 34);
            this.label1.TabIndex = 44;
            this.label1.Text = "Game Dashboard";
            // 
            // listViewScoreList
            // 
            this.listViewScoreList.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.listViewScoreList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPlayer,
            this.columnScore});
            this.listViewScoreList.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewScoreList.FullRowSelect = true;
            this.listViewScoreList.GridLines = true;
            this.listViewScoreList.Location = new System.Drawing.Point(29, 139);
            this.listViewScoreList.Margin = new System.Windows.Forms.Padding(2);
            this.listViewScoreList.Name = "listViewScoreList";
            this.listViewScoreList.Size = new System.Drawing.Size(226, 227);
            this.listViewScoreList.TabIndex = 80;
            this.listViewScoreList.UseCompatibleStateImageBehavior = false;
            this.listViewScoreList.View = System.Windows.Forms.View.Details;
            // 
            // columnPlayer
            // 
            this.columnPlayer.Text = "Player";
            this.columnPlayer.Width = 160;
            // 
            // columnScore
            // 
            this.columnScore.Text = "Score";
            // 
            // listViewGameList
            // 
            this.listViewGameList.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.listViewGameList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHost,
            this.columnGameId,
            this.columnStatus});
            this.listViewGameList.ContextMenuStrip = this.contextMenuStripGame;
            this.listViewGameList.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewGameList.FullRowSelect = true;
            this.listViewGameList.GridLines = true;
            this.listViewGameList.Location = new System.Drawing.Point(306, 139);
            this.listViewGameList.Margin = new System.Windows.Forms.Padding(2);
            this.listViewGameList.Name = "listViewGameList";
            this.listViewGameList.Size = new System.Drawing.Size(384, 227);
            this.listViewGameList.TabIndex = 81;
            this.listViewGameList.UseCompatibleStateImageBehavior = false;
            this.listViewGameList.View = System.Windows.Forms.View.Details;
            // 
            // columnHost
            // 
            this.columnHost.Text = "Game Host";
            this.columnHost.Width = 160;
            // 
            // columnGameId
            // 
            this.columnGameId.Text = "Game ID";
            this.columnGameId.Width = 100;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 120;
            // 
            // contextMenuStripGame
            // 
            this.contextMenuStripGame.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joinToolStripMenuItem});
            this.contextMenuStripGame.Name = "contextMenuStripGame";
            this.contextMenuStripGame.Size = new System.Drawing.Size(96, 26);
            this.contextMenuStripGame.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripGame_Opening);
            // 
            // joinToolStripMenuItem
            // 
            this.joinToolStripMenuItem.Name = "joinToolStripMenuItem";
            this.joinToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.joinToolStripMenuItem.Text = "Join";
            // 
            // buttonManagePlayer
            // 
            this.buttonManagePlayer.BackColor = System.Drawing.SystemColors.HighlightText;
            this.buttonManagePlayer.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManagePlayer.ForeColor = System.Drawing.Color.Teal;
            this.buttonManagePlayer.Image = ((System.Drawing.Image)(resources.GetObject("buttonManagePlayer.Image")));
            this.buttonManagePlayer.Location = new System.Drawing.Point(227, 383);
            this.buttonManagePlayer.Margin = new System.Windows.Forms.Padding(2);
            this.buttonManagePlayer.Name = "buttonManagePlayer";
            this.buttonManagePlayer.Size = new System.Drawing.Size(27, 29);
            this.buttonManagePlayer.TabIndex = 85;
            this.buttonManagePlayer.UseVisualStyleBackColor = false;
            this.buttonManagePlayer.Click += new System.EventHandler(this.ButtonManagePlayer_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Ink Free", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.SystemColors.Window;
            this.labelUsername.Location = new System.Drawing.Point(626, 26);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(66, 23);
            this.labelUsername.TabIndex = 86;
            this.labelUsername.Text = "label2";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelIsAdmin
            // 
            this.labelIsAdmin.AutoSize = true;
            this.labelIsAdmin.Location = new System.Drawing.Point(650, 103);
            this.labelIsAdmin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIsAdmin.Name = "labelIsAdmin";
            this.labelIsAdmin.Size = new System.Drawing.Size(0, 13);
            this.labelIsAdmin.TabIndex = 87;
            this.labelIsAdmin.Visible = false;
            // 
            // timerRefreshScore
            // 
            this.timerRefreshScore.Enabled = true;
            this.timerRefreshScore.Interval = 5000;
            this.timerRefreshScore.Tick += new System.EventHandler(this.TimerRefreshScore_Tick);
            // 
            // FrmPlayerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(716, 435);
            this.Controls.Add(this.labelIsAdmin);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonManagePlayer);
            this.Controls.Add(this.listViewGameList);
            this.Controls.Add(this.listViewScoreList);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.labelGameTitle);
            this.Controls.Add(this.labelScoreTitle);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPlayerDashboard";
            this.Text = "Game Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlayerDashboard_FormClosing);
            this.contextMenuStripGame.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnPlayer;
        private System.Windows.Forms.ColumnHeader columnScore;
        private System.Windows.Forms.ListView listViewGameList;
        private System.Windows.Forms.ColumnHeader columnHost;
        private System.Windows.Forms.ColumnHeader columnGameId;
        private System.Windows.Forms.ColumnHeader columnStatus;
        protected System.Windows.Forms.Button buttonStartGame;
        protected System.Windows.Forms.Label labelGameTitle;
        protected System.Windows.Forms.Label labelScoreTitle;
        private System.Windows.Forms.Button buttonManagePlayer;
        protected System.Windows.Forms.ListView listViewScoreList;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelIsAdmin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGame;
        private System.Windows.Forms.ToolStripMenuItem joinToolStripMenuItem;
        private System.Windows.Forms.Timer timerRefreshScore;
    }
}