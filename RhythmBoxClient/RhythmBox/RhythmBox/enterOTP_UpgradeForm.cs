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
    public partial class enterOTP_UpgradeForm : Form
    {
        ApiService apiService = new ApiService();
        string email = ForgotPassword_UpgradeForm.enteredEmail
            ;
        public enterOTP_UpgradeForm()
        {
            InitializeComponent();
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnVerfify_Click(object sender, EventArgs e)
        {
            int otp = Int32.Parse(txtOTP.Text);
            bool authRes = await apiService.AuthOTP(email, otp);

            if (authRes)
            {
                new ResetPassword_UpgradeForm().Show();
                this.Hide();
            }
            else
                MessageBox.Show("Error");
        }
    }
}
