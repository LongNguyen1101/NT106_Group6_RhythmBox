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
    public partial class SignIn_UpgradeForm : Form
    {
        bool isMouseDown = true;

        ApiService apiService = new ApiService();

        private string hashPassword(string password)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
            //return password;
        }

        // Hàm này sẽ được dùng nếu cần thiết
        public bool isEmail(string text)
        {
            if (text.Contains("@"))
                return true;
            return false;
        }

        public SignIn_UpgradeForm()
        {
            InitializeComponent();
            lbMessageIncorrect.Hide();
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }


        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtEmail.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPassword.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SignIn_UpgradeForm_Load(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length == 0)
                txtEmail.Text = "Enter username";
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.Text = "Enter password";
                txtPassword.PasswordChar = '\0';
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtPassword.PasswordChar = '●';
        }

        private void btnShowHidePass_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text.Length != 0)
            txtPassword.PasswordChar = '\0';
        }

        private void btnShowHidePass_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text.Length != 0)
            txtPassword.PasswordChar = '●';
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp_UpgradeForm signup = new SignUp_UpgradeForm();
            this.Hide();
            signup.Show();
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            bool signinRes = await apiService.Account_SignIn(txtEmail.Text, hashPassword(txtPassword.Text));
            //bool signinRes = await apiService.SignIn(txt_userSI.Text, (txt_passwordSI.Text));

            if (signinRes)
            {
                new MainPage().Show();
                this.Hide();
            }
            else
            {
                lbMessageIncorrect.Show();
                txtPassword.Clear();
                return;
            }
        }

        private void linkForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPassword_UpgradeForm().ShowDialog();
        }
    }
}
