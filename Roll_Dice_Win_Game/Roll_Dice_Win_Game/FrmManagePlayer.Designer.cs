namespace Roll_Dice_Win_Game
{
    partial class FrmManagePlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManagePlayer));
            this.buttonAddPlayer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewPlayerList = new System.Windows.Forms.ListView();
            this.columnPlayer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnAccountStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripPlayer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddPlayer
            // 
            this.buttonAddPlayer.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddPlayer.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPlayer.ForeColor = System.Drawing.Color.Transparent;
            this.buttonAddPlayer.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddPlayer.Image")));
            this.buttonAddPlayer.Location = new System.Drawing.Point(298, 333);
            this.buttonAddPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddPlayer.Name = "buttonAddPlayer";
            this.buttonAddPlayer.Size = new System.Drawing.Size(61, 29);
            this.buttonAddPlayer.TabIndex = 91;
            this.buttonAddPlayer.Text = "Add";
            this.buttonAddPlayer.UseVisualStyleBackColor = false;
            this.buttonAddPlayer.Click += new System.EventHandler(this.ButtonAddPlayer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Ink Free", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(88, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 34);
            this.label4.TabIndex = 85;
            this.label4.Text = "Manage Player(s)";
            // 
            // listViewPlayerList
            // 
            this.listViewPlayerList.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.listViewPlayerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPlayer,
            this.columnScore,
            this.columnAccountStatus});
            this.listViewPlayerList.ContextMenuStrip = this.contextMenuStripPlayer;
            this.listViewPlayerList.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewPlayerList.FullRowSelect = true;
            this.listViewPlayerList.GridLines = true;
            this.listViewPlayerList.Location = new System.Drawing.Point(25, 106);
            this.listViewPlayerList.Margin = new System.Windows.Forms.Padding(2);
            this.listViewPlayerList.Name = "listViewPlayerList";
            this.listViewPlayerList.Size = new System.Drawing.Size(335, 210);
            this.listViewPlayerList.TabIndex = 92;
            this.listViewPlayerList.UseCompatibleStateImageBehavior = false;
            this.listViewPlayerList.View = System.Windows.Forms.View.Details;
            // 
            // columnPlayer
            // 
            this.columnPlayer.Text = "Player";
            this.columnPlayer.Width = 120;
            // 
            // columnScore
            // 
            this.columnScore.Text = "Score";
            this.columnScore.Width = 90;
            // 
            // columnAccountStatus
            // 
            this.columnAccountStatus.Text = "Account Status";
            this.columnAccountStatus.Width = 120;
            // 
            // contextMenuStripPlayer
            // 
            this.contextMenuStripPlayer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripPlayer.Name = "contextMenuStripPlayer";
            this.contextMenuStripPlayer.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStripPlayer.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripPlayer_Opening);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Transparent;
            this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
            this.buttonClose.Location = new System.Drawing.Point(199, 333);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(76, 29);
            this.buttonClose.TabIndex = 93;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // FrmManagePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(387, 381);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.listViewPlayerList);
            this.Controls.Add(this.buttonAddPlayer);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmManagePlayer";
            this.Text = "Manage Player(s)";
            this.Load += new System.EventHandler(this.FrmManagePalyer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddPlayer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listViewPlayerList;
        private System.Windows.Forms.ColumnHeader columnPlayer;
        private System.Windows.Forms.ColumnHeader columnScore;
        private System.Windows.Forms.ColumnHeader columnAccountStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPlayer;
        private System.Windows.Forms.Button buttonClose;
    }
}