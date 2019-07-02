using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Roll_Dice_Win_Game
{
    public partial class FrmManagePlayer : Form
    {
        FrmSettings _Settings = new FrmSettings();
        FrmRegister _Register = new FrmRegister();
        public FrmManagePlayer()
        {
            InitializeComponent();
            SetButtonToolTips();
        }

        private void SetButtonToolTips()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.buttonAddPlayer, "Add");
            ToolTip1.SetToolTip(this.buttonClose, "Cancel");
        }
        private void FrmManagePalyer_Load(object sender, EventArgs e)
        {
            LoadPlayerList();
        }

        private void ContextMenuStripPlayer_Opening(object sender, CancelEventArgs e)
        {
            ManageContextMenuItems(e);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonAddPlayer_Click(object sender, EventArgs e)
        {
            _Register.ShowDialog();
            LoadPlayerList();
        }

        private void UnlockItem_Click(object sender, EventArgs e)
        {
            UnlockUser();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void ResetPassword_Click(object sender, EventArgs e)
        {
            _Settings.ShowDialog(listViewPlayerList.SelectedItems[0].Text);
        }

        private void LoadPlayerList()
        {
            listViewPlayerList.Items.Clear();
            List<ClsScoreList> scoreList = ClsExtractData.GetPalyerListForAdmin();
            if (scoreList != null && scoreList.Any())
            {
                foreach (ClsScoreList scoreEntry in scoreList)
                {
                    ListViewItem listViewItem = new ListViewItem(scoreEntry.Username);
                    listViewItem.SubItems.Add(scoreEntry.HighScore.ToString());
                    listViewItem.SubItems.Add(scoreEntry.AccountStatus.ToString());
                    listViewPlayerList.Items.Add(listViewItem);
                }
            }
        }


        private void ManageContextMenuItems(CancelEventArgs e)
        {
            contextMenuStripPlayer.Items.Clear();
            if (listViewPlayerList.SelectedItems.Count == 0)
                e.Cancel = true;
            else
            {
                string username = listViewPlayerList.SelectedItems[0].Text;
                string status = listViewPlayerList.SelectedItems[0].SubItems[2].Text;
                if ("online" == status || "playing" == status)
                    e.Cancel = true;
                else if ("offline" == status)
                    AddContextMenuItems("offline");
                else if ("locked" == status)
                    AddContextMenuItems("locked");
            }
        }

        private void AddContextMenuItems(string status)
        {
            contextMenuStripPlayer.Items.Clear();
            if ("locked" == status)
            {
                ToolStripMenuItem unlockItem = new ToolStripMenuItem("Unlock");
                unlockItem.Click += new EventHandler(UnlockItem_Click);
                contextMenuStripPlayer.Items.Add(unlockItem);
            }
            ToolStripMenuItem resetPasswordItem = new ToolStripMenuItem("Reset Password");
            resetPasswordItem.Click += new EventHandler(ResetPassword_Click);
            contextMenuStripPlayer.Items.Add(resetPasswordItem);
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete");
            deleteItem.Click += new EventHandler(Delete_Click);
            contextMenuStripPlayer.Items.Add(deleteItem);
        }

        private void DeleteUser()
        {
            if (DialogResult.Yes == MessageBox.Show(ClsConstants.DELETE_USER_CONFIRM_MESSAGE, ClsConstants.DIALOG_WARNING,
                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                string dbMessage = ClsExtractData.DeleteUser(listViewPlayerList.SelectedItems[0].Text);
                MessageBox.Show(dbMessage, ClsConstants.DIALOG_INFORMATION, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            LoadPlayerList();
        }

        private void UnlockUser()
        {
            string dbMessage = ClsExtractData.UnlockUser(listViewPlayerList.SelectedItems[0].Text);
            MessageBox.Show(dbMessage, ClsConstants.DIALOG_INFORMATION, MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            LoadPlayerList();
        }

        
    }
}
