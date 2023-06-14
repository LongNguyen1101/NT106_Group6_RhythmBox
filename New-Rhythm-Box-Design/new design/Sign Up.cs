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
using System.Windows.Forms.Design;

namespace new_design
{
    public partial class Sign_Up : Form
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
                case "JANUARY":
                    return 1;
                case "FEBRUARY":
                    return 2;
                case "MARCH":
                    return 3;
                case "APRIL":
                    return 4;
                case "MAY":
                    return 5;
                case "JUNE":
                    return 6;
                case "JULY":
                    return 7;
                case "AUGUST":
                    return 8;
                case "SEPTEMBER":
                    return 9;
                case "OCTOBER":
                    return 10;
                case "NOVEMBER":
                    return 11;
                case "DECEMBER":
                    return 12;
                default:
                    return 0;
            }
        }

        public string checkboxtostringGender()
        {
            if (checkBox_male.Checked)
                return "Male";
            else if (checkBox_female.Checked)
                return "Female";
            else if (checkBox_other.Checked)
                return "Other";
            return "Error Gender!!";
        }

        public Sign_Up()
        {
            InitializeComponent();
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_password.PasswordChar = '\0';
                txt_confirm.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';
                txt_confirm .PasswordChar = '*';
            }
        }

        private void checkBox_male_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_male.Checked)
            {
                checkBox_female.Enabled = false;
                checkBox_other.Enabled = false;
            }
            else
            {
                checkBox_female.Enabled = true;
                checkBox_other.Enabled = true;
            }
        }

        private void checkBox_female_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_female.Checked)
            {
                checkBox_male.Enabled = false;
                checkBox_other.Enabled = false;
            }
            else
            {
                checkBox_male.Enabled = true;
                checkBox_other.Enabled = true;
            }
        }

        private void checkBox_other_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_other.Checked)
            {
                checkBox_male.Enabled = false;
                checkBox_female.Enabled = false;
            }
            else
            {
                checkBox_male.Enabled = true;
                checkBox_female.Enabled = true;
            }
        }

        private async void btn_signIn_Click(object sender, EventArgs e)
        {
            int iYear = int.Parse(txt_year.Text);
            int iMonth = IntMonth(cb_month.Text);
            int iDate = int.Parse(txt_day.Text);
            DateTime dBirthday = new DateTime(iYear, iMonth, iDate);

            bool signupRes = await apiService.Account_SignUp(txt_username.Text, txt_email.Text, hashPassword(txt_password.Text), dBirthday, checkboxtostringGender());

            if (txt_username.Text == "" && txt_password.Text == "" && txt_confirm.Text == "")
            {
                MessageBox.Show("Username and Password box are empty", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Focus();

            }
            else if (txt_password.Text == txt_confirm.Text && signupRes)
            {
                MessageBox.Show("Your account has been created", "Please sign in", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Sign_In signIn = new Sign_In();
                signIn.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password does not match", "Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_password.Clear();
                txt_confirm.Clear();
                txt_username.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sign_In signIn = new Sign_In();
            signIn.Show();
            this.Hide();
        }
    }
}
