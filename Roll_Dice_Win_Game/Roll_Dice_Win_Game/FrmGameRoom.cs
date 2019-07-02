using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Roll_Dice_Win_Game
{
    public partial class FrmGameRoom : Form
    {
        Timer t = new Timer();
        FrmHelp _Help = new FrmHelp();
        bool isTimerStopped = false;
        public FrmGameRoom()
        {
            InitializeComponent();
            SetButtonToolTips();
        }

        private void SetButtonToolTips()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.buttonExit, "Exit Game");
            ToolTip1.SetToolTip(this.buttonHelp, "Help");
            ToolTip1.SetToolTip(this.buttonRollDice, "Roll the Dice");
        }

        internal void ShowDialog(int gameId, string tokenColor, string userTurn, string username)
        {
            labelGameId.Text = gameId.ToString();
            labelTokenColor.Text = tokenColor;
            labelSessionUser.Text = username;
            buttonRollDice.Enabled = false;
            UpdateGameRoom(gameId);
            UpdateGameBoard(gameId);
            ShowDialog();
        }

        private void FrmGameRoom_Load(object sender, EventArgs e)
        {
            t.Interval = 5000;
            t.Tick += new EventHandler(TimerGameRoom_Tick);
            t.Start();
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            _Help.ShowDialog();
        }

        private void TimerGameRoom_Tick(object sender, EventArgs e)
        {
            if(!isTimerStopped)
                CheckAndUpdateGameRoom();
        }


        private void ButtonRollDice_Click(object sender, EventArgs e)
        {
            RollDiceAndShowResult();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            ExitGame();
        }
        
        private void RollDiceAndShowResult()
        {
            int gameId = Convert.ToInt32(labelGameId.Text);
            int diceSide = 0;
            string rollResult = ClsExtractData.GenerateDiceRollOutput(gameId, labelSessionUser.Text);
            if (rollResult.All(char.IsDigit))
            {
                diceSide = Convert.ToInt32(rollResult);
                UpdateDiceView(diceSide);
                GetAndIntiateMovement(gameId, diceSide, labelSessionUser.Text);
            }
            else
                MessageBox.Show(rollResult, ClsConstants.DIALOG_INFORMATION, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void GetAndIntiateMovement(int gameId, int diceSide, string username)
        {
            DataRowCollection dataRows = ClsExtractData.UpdateUserPosition(gameId, diceSide, username);
            if (dataRows == null || (dataRows.Count == 0))
                MessageBox.Show(ClsConstants.SOMETHING_WRONG_MESSAGE, ClsConstants.DIALOG_INFORMATION,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if(dataRows[0].Table.Columns.Contains("message"))
                {
                    string message = dataRows[0]["message"].ToString();
                    switch (message)
                    {
                        case "WINNER":
                            AnnounceWinnerAndEnd();
                            break;
                        default:
                            MessageBox.Show(message, ClsConstants.DIALOG_INFORMATION, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                    }
                } else
                {
                    int position = Convert.ToInt32(dataRows[0][1].ToString());
                    string nextUserTurn = dataRows[0][3].ToString();
                    MakeMovement(position);
                    labelUserTurnUpdate.Text = nextUserTurn;
                    buttonRollDice.Enabled = false;
                    UpdateGameRoom(gameId);
                }
            }
        }

        private void AnnounceWinnerAndEnd()
        {
            MakeMovement(24);
            t.Stop();
            if (DialogResult.OK == MessageBox.Show(ClsConstants.WINNER_MESSAGE, ClsConstants.WINNER_MESSAGE_TITLE,
                MessageBoxButtons.OK, MessageBoxIcon.Information))
            Close();
        }

        private void MakeMovement(int position)
        {
            switch (labelTokenColor.Text)
            {
                case "red":
                    pictureBoxRed.Location = new Point(ClsPlayerRedPosition.redPosList[position][0],
                        ClsPlayerRedPosition.redPosList[position][1]);
                    break;
                case "green":
                    pictureBoxGreen.Location = new Point(ClsPlayerGreenPosition.greenPosList[position][0],
                        ClsPlayerGreenPosition.greenPosList[position][1]);
                    break;
                case "blue":
                    pictureBoxBlue.Location = new Point(ClsPlayerBluePosition.bluePosList[position][0],
                        ClsPlayerBluePosition.bluePosList[position][1]);
                    break;
                case "black":
                    pictureBoxBlack.Location = new Point(ClsPlayerBlackPosition.blackPosList[position][0],
                        ClsPlayerBlackPosition.blackPosList[position][1]);
                    break;
            }
        }

        private void UpdateDiceView(int rollResult)
        {
            switch (rollResult)
            {
                case 1:
                    pictureBoxRollResult.Image = Properties.Resources.dice1;
                    break;
                case 2:
                    pictureBoxRollResult.Image = Properties.Resources.dice2;
                    break;
                case 3:
                    pictureBoxRollResult.Image = Properties.Resources.dice3;
                    break;
                case 4:
                    pictureBoxRollResult.Image = Properties.Resources.dice4;
                    break;
                case 5:
                    pictureBoxRollResult.Image = Properties.Resources.dice5;
                    break;
                case 6:
                    pictureBoxRollResult.Image = Properties.Resources.dice6;
                    break;
            }
        }

       
        private void CheckAndUpdateGameRoom()
        {
            int gameId = Convert.ToInt32(labelGameId.Text);
            string dbMessage = ClsExtractData.GetGameStatus(gameId);
            switch (dbMessage)
            {
                case "continue":
                    UpdateGameRoom(gameId);
                    UpdateGameBoard(gameId);
                    break;
                default:
                    t.Stop();
                    isTimerStopped = true;
                    MessageBox.Show(dbMessage, ClsConstants.DIALOG_INFORMATION,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    break;
            }
        }

        

        private void UpdateGameRoom(int gameId)
        {
            string username = labelSessionUser.Text;
            List<ClsScoreList> scoreList = ClsExtractData.GetGameRoomScoreList(gameId);
            if (scoreList.Any())
            {
                listViewScoreList.Items.Clear();
                foreach (ClsScoreList scoreEntry in scoreList)
                {
                    ListViewItem listViewItem = new ListViewItem(scoreEntry.Username);
                    listViewItem.SubItems.Add(scoreEntry.HighScore.ToString());
                    listViewScoreList.Items.Add(listViewItem);
                    if ("enable" == scoreEntry.UserTurn && username == scoreEntry.Username)
                        buttonRollDice.Enabled = true;
                   
                    if ("enable" == scoreEntry.UserTurn)
                        labelUserTurnUpdate.Text = scoreEntry.Username;
                }
            }
        }

        private void UpdateGameBoard(int gameId)
        {
            List<ClsGameBoard> boardList = ClsExtractData.GetGameBoardData(gameId);
            int playerRedPosition = 0;
            int playerGreenPosition = 0;
            int playerBluePosition = 0;
            int playerBlackPosition = 0;
            bool redPlayer = false;
            bool greenPlayer = false;
            bool bluePlayer = false;
            bool blackPlayer = false;
            if (boardList.Any())
            {
                foreach (ClsGameBoard boardEntry in boardList)
                {
                    switch (boardEntry.PlayerColor)
                    {
                        case "red":
                            playerRedPosition = boardEntry.PlayerPosition;
                            redPlayer = true;
                            break;
                        case "green":
                            playerGreenPosition = boardEntry.PlayerPosition;
                            greenPlayer = true;
                            break;
                        case "blue":
                            playerBluePosition = boardEntry.PlayerPosition;
                            bluePlayer = true;
                            break;
                        case "black":
                            playerBlackPosition = boardEntry.PlayerPosition;
                            blackPlayer = false;
                            break;
                    }
                        
                }
                if (redPlayer)
                {
                    pictureBoxRed.Visible = true;
                    pictureBoxRed.Location = new Point(ClsPlayerRedPosition.redPosList[playerRedPosition][0],
                                            ClsPlayerRedPosition.redPosList[playerRedPosition][1]);
                }
                else
                    pictureBoxRed.Visible = false;

                if (greenPlayer)
                {
                    pictureBoxGreen.Visible = true;
                    pictureBoxGreen.Location = new Point(ClsPlayerGreenPosition.greenPosList[playerGreenPosition][0],
                        ClsPlayerGreenPosition.greenPosList[playerGreenPosition][1]);
                }
                else
                    pictureBoxGreen.Visible = false;

                if (bluePlayer)
                {
                    pictureBoxBlue.Visible = true;
                    pictureBoxBlue.Location = new Point(ClsPlayerBluePosition.bluePosList[playerBluePosition][0],
                        ClsPlayerBluePosition.bluePosList[playerBluePosition][1]);
                }
                else
                    pictureBoxBlue.Visible = false;

                if (blackPlayer)
                {
                    pictureBoxBlack.Visible = true;
                    pictureBoxBlack.Location = new Point(ClsPlayerBlackPosition.blackPosList[playerBlackPosition][0],
                       ClsPlayerBlackPosition.blackPosList[playerBlackPosition][1]);
                }
                else
                    pictureBoxBlack.Visible = false;
            }

        }

        private void ExitGame()
        {
            int gameId = Convert.ToInt32(labelGameId.Text);
            string dbMessage = ClsExtractData.ExitGame(gameId, labelSessionUser.Text);
            switch(dbMessage)
            {
                case "Successfully quit":
                    t.Stop();
                    Close();
                    break;
                default:
                    MessageBox.Show(dbMessage, ClsConstants.DIALOG_INFORMATION,
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}
