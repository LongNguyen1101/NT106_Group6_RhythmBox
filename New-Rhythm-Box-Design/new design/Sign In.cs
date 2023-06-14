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

namespace new_design
{
    public partial class Sign_In : Form
    {
        ApiService apiService = new ApiService();

        private string hashPassword(string password)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
            return password;
        }

        // Hàm này sẽ được dùng nếu cần thiết
        public bool isEmail(string text)
        {
            if (text.Contains("@"))
                return true;
            return false;
        }

        public Sign_In()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_password.PasswordChar = '\0';

            }
            else
            {
                txt_password.PasswordChar = '*';

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sign_Up sign_Up = new Sign_Up();
            sign_Up.Show();
            this.Hide();
        }

        private async void btn_signIn_Click(object sender, EventArgs e)
        {
            bool signinRes = await apiService.Account_SignIn(txt_username.Text, hashPassword(txt_password.Text));
            //bool signinRes = await apiService.SignIn(txt_userSI.Text, (txt_passwordSI.Text));

            if (signinRes)
            {
                new MainPage().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password incorrect!!", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Clear();
                txt_password.Clear();
                txt_username.Focus();
                return;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotPassword forgotPass = new forgotPassword();
            forgotPass.Show();
            this.Hide();
        }
    }
}
