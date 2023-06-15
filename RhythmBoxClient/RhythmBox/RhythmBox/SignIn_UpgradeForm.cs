using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmBox
{
    public partial class SignIn_UpgradeForm : Form
    {
        bool isMouseDown = true;
        public SignIn_UpgradeForm()
        {
            InitializeComponent();
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
    }
}
