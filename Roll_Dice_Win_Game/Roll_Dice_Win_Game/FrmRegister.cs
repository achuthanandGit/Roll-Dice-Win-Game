using System;
using System.Windows.Forms;

namespace Roll_Dice_Win_Game
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
            SetButtonToolTips();
        }
        private void SetButtonToolTips()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.buttonRegister, "Register");
            ToolTip1.SetToolTip(this.buttonCancel, "Cancel");
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            textBoxEmail.Clear();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            ClosDialogBox();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            CheckAndRegister();
        }

        private void ClosDialogBox()
        {
            if (IsDataExists() && DialogResult.Yes == MessageBox.Show(ClsConstants.CANCEL_ERROR_MESSAGE,
                ClsConstants.DIALOG_ERROR, MessageBoxButtons.YesNo, MessageBoxIcon.Error))
                Close();
            else
                Close();
        }

        private void CheckAndRegister()
        {
            if (!IsDataExists())
                MessageBox.Show(ClsConstants.FILL_DATA_MESSAGE, ClsConstants.DIALOG_ERROR, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                GetAndRegisterUser();
        }

        private void GetAndRegisterUser()
        {
            String dbMessage = ClsExtractData.RegisterNewUser(textBoxUsername.Text, 
                textBoxPassword.Text, textBoxEmail.Text);
            switch(dbMessage)
            {
                case "username already taken":
                    MessageBox.Show(ClsConstants.USERNAME_EXISTS_ERROR, ClsConstants.DIALOG_ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "email should be unique":
                    MessageBox.Show(ClsConstants.EMAIL_EXISTS_ERROR, ClsConstants.DIALOG_ERROR, 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "invalid email":
                    MessageBox.Show(ClsConstants.INVALID_EMAIL_ERROR, ClsConstants.DIALOG_ERROR, 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "user added succefully":
                    if(DialogResult.OK == MessageBox.Show(ClsConstants.RESGISTRATION_SUCCESSFULL, ClsConstants.DIALOG_INFORMATION,
                        MessageBoxButtons.OK, MessageBoxIcon.Information))
                        Close();
                    break;
                default:
                    MessageBox.Show(ClsConstants.DIALOG_ERROR, dbMessage, MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    break;
            }
        }

     

        private bool IsDataExists()
        {
            return !(string.IsNullOrEmpty(textBoxUsername.Text) ||
                string.IsNullOrEmpty(textBoxPassword.Text) ||
                string.IsNullOrEmpty(textBoxEmail.Text));
        }

        
    }
}
