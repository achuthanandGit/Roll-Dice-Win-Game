using System;
using System.Windows.Forms;

namespace Roll_Dice_Win_Game
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
            SetButtonToolTips();
        }
        private void SetButtonToolTips()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.buttonDashboard, "Cancel");
            ToolTip1.SetToolTip(this.buttonResetPwd, "Reset Password");
        }

        internal void ShowDialog(string username)
        {
            labelUsername.Text = username;
            ShowDialog();
        }

        private void ButtonDashboard_Click(object sender, EventArgs e)
        {
            textBoxPassword.Clear();
            Close();
        }

        private void ButtonResetPwd_Click(object sender, EventArgs e)
        {
            ResetPassword();
        }

        private void ResetPassword()
        {
            if (string.IsNullOrEmpty(textBoxPassword.Text))
                MessageBox.Show(ClsConstants.FILL_DATA_MESSAGE, ClsConstants.DIALOG_ERROR, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                string dbMessage = ClsExtractData.ResetPassword(labelUsername.Text, textBoxPassword.Text);
                switch(dbMessage)
                {
                    case "Password reset successfully.":
                        if (DialogResult.OK == MessageBox.Show(dbMessage, ClsConstants.DIALOG_INFORMATION,
                            MessageBoxButtons.OK, MessageBoxIcon.Information))
                            textBoxPassword.Clear();
                            Close();
                        break;
                    default:
                        MessageBox.Show(dbMessage, ClsConstants.DIALOG_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                }
            }
                
        }

    }
}
