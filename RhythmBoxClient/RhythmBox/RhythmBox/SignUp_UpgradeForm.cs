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
    public partial class SignUp_UpgradeForm : Form
    {
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
            if (txtPassword.Text.Length != 0)
            {
                txtPassword.PasswordChar = '●';
                txtConfirmPassword.PasswordChar = '●';
            }
        }
    }
}
