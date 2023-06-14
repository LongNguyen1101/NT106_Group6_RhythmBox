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
    public partial class resetPassword : Form
    {
        ApiService apiService = new ApiService();
        string email = forgotPassword.enteredEmail;

        private string hashPassword(string password)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public resetPassword()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_newpass.PasswordChar = '\0';
                txt_confirmnew.PasswordChar = '\0';
            }
            else
            {
                txt_newpass.PasswordChar = '*';
                txt_confirmnew .PasswordChar = '*'; 
            }
        }

        private async void btn_signIn_Click(object sender, EventArgs e)
        {
            if (txt_newpass.Text != txt_confirmnew.Text)
            {
                txt_newpass.Clear();
                txt_confirmnew.Clear();
                MessageBox.Show("Re-enterd password is not same as first try", "Please try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool request = await apiService.RenewPassword(email, hashPassword(txt_newpass.Text));
                if (request)
                {
                    MessageBox.Show("Reset password successfully");
                    Sign_In signIn = new Sign_In();
                    signIn.Show();
                    this.Hide();
                }
            }
        }
    }
}
