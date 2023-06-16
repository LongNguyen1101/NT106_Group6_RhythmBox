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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            new MainPage().Show();
            this.Hide();
        }

        private void link_signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignUp().Show();
            this.Hide();
        }

        private void checkbox_show_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_show.Checked)
            {
                txt_passwordSI.PasswordChar = '\0';
                
            }
            else
            {
                txt_passwordSI.PasswordChar = '*';
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new forgotPassword().Show();
            this.Hide();
        }
    }
}
