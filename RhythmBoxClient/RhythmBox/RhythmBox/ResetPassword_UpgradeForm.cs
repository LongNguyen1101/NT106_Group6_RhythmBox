using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmBox
{
    public partial class ResetPassword_UpgradeForm : Form
    {
        ApiService apiService = new ApiService();
        string email = ForgotPassword_UpgradeForm.enteredEmail;

        private string hashPassword(string password)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
        public ResetPassword_UpgradeForm()
        {
            InitializeComponent();
        }

        private void btnShowHidePass_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtNewPassword.Text.Length != 0)
            {
                txtNewPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
        }

        private void btnShowHidePass_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtConfirmPassword.Text.Length != 0)
            {
                txtConfirmPassword.PasswordChar = '●';
                txtConfirmPassword.PasswordChar = '●';
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
                MessageBox.Show("Re-enterd password is not same as first try", "Please try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool request = await apiService.RenewPassword(email, hashPassword(txtNewPassword.Text));
                if (request)
                {
                    MessageBox.Show("Reset password successfully");
                    this.Hide();
                }
            }
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
