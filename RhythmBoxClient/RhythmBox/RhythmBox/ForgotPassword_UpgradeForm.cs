using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace RhythmBox
{
    public partial class ForgotPassword_UpgradeForm : Form
    {
        ApiService apiService = new ApiService();
        public static string enteredEmail { get; set; }
        public ForgotPassword_UpgradeForm()
        {
            InitializeComponent();
        }
        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnForgotPass_Click(object sender, EventArgs e)
        {
            bool resetRes = await apiService.ForgotPassword(txtEmail.Text);
            enteredEmail = txtEmail.Text;

            if (resetRes)
            {
                enterOTP_UpgradeForm authOTP = new enterOTP_UpgradeForm();
                authOTP.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

    }
}
