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
    public partial class SignUp_UpgradeForm : Form
    {
        ApiService apiService = new ApiService();
        private string hashPassword(string password)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        public bool isValidPass(string password1, string password2)
        {
            if (password1.Length < 3)
                return false;
            else if (password1 != password2)
                return false;
            return true;
        }

        public int IntMonth(string sMonth)
        {
            switch (sMonth)
            {
                case "January":
                    return 1;
                case "February":
                    return 2;
                case "March":
                    return 3;
                case "April":
                    return 4;
                case "May":
                    return 5;
                case "June":
                    return 6;
                case "July":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "October":
                    return 10;
                case "November":
                    return 11;
                case "December":
                    return 12;
                default:
                    return 0;
            }
        }

        public string checkboxtostringGender()
        {
            if (rbtnMale.Checked)
                return "Male";
            else if (rbtnFemale.Checked)
                return "Female";
            else if (rbtnOther.Checked)
                return "Other";
            return "Error Gender!!";
        }

        public SignUp_UpgradeForm()
        {
            InitializeComponent();
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void btnShowHidePass_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text.Length != 0)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
        }

        private void btnShowHidePass_MouseUp(object sender, MouseEventArgs e)
        {
            if (txtConfirmPassword.Text.Length != 0)
            {
                txtPassword.PasswordChar = '●';
                txtConfirmPassword.PasswordChar = '●';
            }
        }

        private void txtDay_Click(object sender, EventArgs e)
        {
            txtDay.ForeColor = Color.Black;
            txtDay.Clear();
        }

        private void txtYear_Click(object sender, EventArgs e)
        {
            txtYear.ForeColor = Color.Black;
            txtYear.Clear();
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            DateTime dBirthday;
            int iYear = int.Parse(txtYear.Text);
            int iMonth = IntMonth(cbMonth.Text);
            int iDay = int.Parse(txtDay.Text);

            if (iMonth != 0)
            {
                dBirthday = new DateTime(iYear, iMonth, iDay);

                bool signupRes = await apiService.Account_SignUp(txtUsername.Text, txtEmail.Text, hashPassword(txtPassword.Text), dBirthday, checkboxtostringGender());

                if (txtUsername.Text == "" && txtPassword.Text == "" && txtConfirmPassword.Text == "" && txtEmail.Text == "")
                {
                    MessageBox.Show("Please fill in gaps", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtPassword.Text == txtConfirmPassword.Text && signupRes)
                {
                    MessageBox.Show("Your account has been created", "Please sign in", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SignIn_UpgradeForm signIn = new SignIn_UpgradeForm();
                    signIn.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password does not match", "Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();
                    return;
                }
            }

            else
            {
                MessageBox.Show("Invalid month", "Birthday error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void linkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn_UpgradeForm signIn = new SignIn_UpgradeForm();
            signIn.Show();
            this.Hide();
        }

        private void linkForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPassword_UpgradeForm().ShowDialog();
        }
    }
}
