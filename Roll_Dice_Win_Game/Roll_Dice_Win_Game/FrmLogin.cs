using System;
using System.Windows.Forms;

namespace Roll_Dice_Win_Game
{
    public partial class FormLogin : Form
    {
        FrmPlayerDashboard _PlayerDashBoard = new FrmPlayerDashboard();
        FrmRegister _Register = new FrmRegister();

        public FormLogin()
        {
            InitializeComponent();
            SetButtonToolTips();
        }

        private void SetButtonToolTips()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.buttonCheck, "Check");
            ToolTip1.SetToolTip(this.buttonLogIn, "Login");
            ToolTip1.SetToolTip(this.buttonRegister, "Register");
            ToolTip1.SetToolTip(this.buttonExit, "Exit");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            CheckUserNameExists(textBoxUserName.Text);
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            SetAndOpenRegistration();
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            labelUsernameError.Text = string.Empty;
            if (string.IsNullOrEmpty(textBoxUserName.Text) ||
                string.IsNullOrEmpty(textBoxPassword.Text))
                buttonLogIn.Enabled = false;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            labelUsernameError.Text = string.Empty;
            if (string.IsNullOrEmpty(textBoxPassword.Text) ||
                string.IsNullOrEmpty(textBoxUserName.Text))
                buttonLogIn.Enabled = false;
            else
                buttonLogIn.Enabled = true;
        }

        private void SetAndOpenRegistration()
        {
            textBoxUserName.Clear();
            textBoxPassword.Clear();
            this.Hide();
            _Register.ShowDialog();
            this.Show();
        }

        private void CheckLogin()
        {
            labelLoginError.Text = string.Empty;
            String dbMessage = ClsExtractData.CheckUserAuthentication(textBoxUserName.Text, textBoxPassword.Text);
            switch(dbMessage)
            {
                case "admin login success":
                    LoadGameDashboard("admin");
                    break;
                case "user login success":
                    LoadGameDashboard(string.Empty);
                    break;
                case "contact admin to unlock":
                    MessageBox.Show(ClsConstants.CONTACT_ADMIN, ClsConstants.DIALOG_ERROR,
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "locked":
                    MessageBox.Show(ClsConstants.CONTACT_ADMIN, ClsConstants.DIALOG_ERROR,
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "login again":
                    labelLoginError.Text = ClsConstants.AUTHENTICATION_FAILS_ERROR;
                    break;
                default:
                    labelLoginError.Text = dbMessage;
                    break;
            }
        }

        

        private void CheckUserNameExists(string inputUsername)
        {
            if(string.IsNullOrWhiteSpace(inputUsername))
            {
                labelUsernameError.Text = ClsConstants.INPUT_VALID_USERNAME_MESSAGE;
            } else
            {
                labelUsernameError.Text = string.Empty;
                String dbMesssage = ClsExtractData.CheckUserNameExistance(inputUsername);
                switch (dbMesssage)
                {
                    case "user exists":
                        LoadPasswordInput();
                        break;
                    case "register":
                        LoadRegistrationPage();
                        break;
                    case "contact admin to unlock":
                        MessageBox.Show(ClsConstants.CONTACT_ADMIN, ClsConstants.DIALOG_ERROR,
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        labelUsernameError.Text = dbMesssage;
                        break;
                }
            }
        }

        private void LoadRegistrationPage()
        {
            if(DialogResult.OK == MessageBox.Show(ClsConstants.REGISTER_INFORMATION,
                ClsConstants.DIALOG_INFORMATION, MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                textBoxUserName.Clear();
                this.Hide();
                _Register.ShowDialog();
                this.Show();
            }
        }

        private void LoadPasswordInput()
        {
            buttonCheck.Hide();
            textBoxPassword.Show();
            labelPassword.Show();
        }

        private void LoadGameDashboard(String playerMode)
        {
            this.Hide();
            _PlayerDashBoard.ShowDialog(playerMode, textBoxUserName.Text);
            labelLoginError.Text = string.Empty;
            textBoxUserName.Clear();
            textBoxPassword.Clear();
            textBoxPassword.Hide();
            labelPassword.Hide();
            buttonLogIn.Enabled = false;
            buttonCheck.Show();
            this.Show();
        }

    }
}
