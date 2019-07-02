using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Roll_Dice_Win_Game
{
    public partial class FrmPlayerDashboard : Form
    {
        FrmSettings _Settings = new FrmSettings();
        FrmManagePlayer _ManagePlayer = new FrmManagePlayer();
        FrmGameRoom _GameRoom = new FrmGameRoom();
        public FrmPlayerDashboard()
        {
            InitializeComponent();
            SetButtonToolTips();
        }

        private void SetButtonToolTips()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.buttonLogout, "Logout");
            ToolTip1.SetToolTip(this.buttonSettings, "Reset Password");
            ToolTip1.SetToolTip(this.buttonStartGame, "Start Game");
            ToolTip1.SetToolTip(this.buttonManagePlayer, "Manage Player(s)");
        }

        internal void ShowDialog(string playerMode, string userName)
        {
            labelUsername.Text = userName;
            ShowHideAdminPrivileges(playerMode);
            UpdateScoreList();
            UpdateGameList();
            ShowDialog();
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            ClsExtractData.LogOutSession(labelUsername.Text);
            Close();
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            _Settings.ShowDialog(labelUsername.Text);
        }

        private void ButtonManagePlayer_Click(object sender, EventArgs e)
        {
            _ManagePlayer.ShowDialog();
        }

        private void ContextMenuStripGame_Opening(object sender, CancelEventArgs e)
        {
            ManageContextMenuItems(e);
        }

        private void TerminateGame_Click(object sender, EventArgs e)
        {
            TerminateGame();
        }

        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void JoinGame_Click(object sender, EventArgs e)
        {
            JoinGame();
        }

        private void TimerRefreshScore_Tick(object sender, EventArgs e)
        {
            UpdateScoreList();
            UpdateGameList();
        }

        private void FrmPlayerDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClsExtractData.LogOutSession(labelUsername.Text);
        }

        private void ShowHideAdminPrivileges(string playerMode)
        {
            if("admin" == playerMode)
            {
                buttonManagePlayer.Show();
                labelIsAdmin.Text = true.ToString();
            } else
            {
                buttonManagePlayer.Hide();
                labelIsAdmin.Text = false.ToString();
            }
        }

        private void UpdateScoreList()
        {
            listViewScoreList.Items.Clear();
            List<ClsScoreList> scoreList = ClsExtractData.GetOnlinePlayerList();
            if (scoreList != null && scoreList.Any())
            {
                foreach (ClsScoreList scoreEntry in scoreList)
                {
                    ListViewItem listViewItem = new ListViewItem(scoreEntry.Username);
                    listViewItem.SubItems.Add(scoreEntry.HighScore.ToString());
                    listViewScoreList.Items.Add(listViewItem);
                }
            }
        }

        private void UpdateGameList()
        {
            listViewGameList.Items.Clear();
            List<ClsGameList> gameList = ClsExtractData.GetGameList();
            if(gameList != null && gameList.Any())
            {
                foreach (ClsGameList gameEntry in gameList)
                {
                    ListViewItem listViewItem = new ListViewItem(gameEntry.GameHost);
                    listViewItem.SubItems.Add(gameEntry.GameId.ToString());
                    listViewItem.SubItems.Add(gameEntry.GameStatus.ToString());
                    listViewGameList.Items.Add(listViewItem);
                }
            }
        }

        private void ManageContextMenuItems(CancelEventArgs e)
        {
            contextMenuStripGame.Items.Clear();
            if (listViewGameList.SelectedItems.Count == 0 ||
                ("waitingToStart" != listViewGameList.SelectedItems[0].SubItems[2].Text &&
                "running" != listViewGameList.SelectedItems[0].SubItems[2].Text))
                e.Cancel = true;
            else
            {
                ToolStripMenuItem joinGame = new ToolStripMenuItem("Join");
                joinGame.Click += new EventHandler(JoinGame_Click);
                contextMenuStripGame.Items.Add(joinGame);
                bool isAdmin = Convert.ToBoolean(labelIsAdmin.Text);
                if(isAdmin && ("running" == listViewGameList.SelectedItems[0].SubItems[2].Text))
                {
                    ToolStripMenuItem terminateGame = new ToolStripMenuItem("Terminate");
                    terminateGame.Click += new EventHandler(TerminateGame_Click);
                    contextMenuStripGame.Items.Add(terminateGame);
                }   
            }
        }

        private void TerminateGame()
        {
            int gameId = Convert.ToInt32(listViewGameList.SelectedItems[0].SubItems[1].Text);
            string dbMessage = ClsExtractData.TerminateGame(gameId);
            MessageBox.Show(dbMessage, ClsConstants.DIALOG_INFORMATION, MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            UpdateGameList();
        }

        private void JoinGame()
        {
            int gameId = Convert.ToInt32(listViewGameList.SelectedItems[0].SubItems[1].Text);
            DataRowCollection dataRows = ClsExtractData.JoinGame(gameId, labelUsername.Text);
            if (dataRows == null || dataRows.Count == 0)
                MessageBox.Show(ClsConstants.SOMETHING_WRONG_MESSAGE, ClsConstants.DIALOG_INFORMATION,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (dataRows[0].Table.Columns.Contains("message"))
                    MessageBox.Show(dataRows[0]["message"].ToString(), ClsConstants.DIALOG_INFORMATION,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    this.Hide();
                    string tokenColor = dataRows[0][1].ToString();
                    string userTurn = dataRows[0][2].ToString();
                    _GameRoom.ShowDialog(gameId, tokenColor, userTurn, labelUsername.Text);
                    this.Show();
                }

            }
        }

        
        private void StartGame()
        {
            List<String> dbResult = ClsExtractData.StartGame(labelUsername.Text);
            if (dbResult.Count == 1)
                MessageBox.Show(dbResult[0], ClsConstants.DIALOG_INFORMATION, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                this.Hide();
                int gameId = Convert.ToInt32(dbResult[0]);
                string tokenColor = dbResult[1];
                string userTurn = dbResult[2];
                _GameRoom.ShowDialog(gameId, tokenColor, userTurn, labelUsername.Text);
                this.Show();
            }
        }

    }
}
