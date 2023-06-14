using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.OleDb;
namespace RhythmBox
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            
        }
        OleDbConnection conn = new OleDbConnection("Provider= Microsoft.Jet.OLEDB.4.0;Data Source = database_user.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void btn_signup_Click(object sender, System.EventArgs e)
        {
            if (txt_userSU.Text == "" && txt_passwordSU.Text == "" && txt_confirmSU.Text == "")
            {
                MessageBox.Show("Username and Password box are empty", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_userSU.Focus();

            }
            else if (txt_passwordSU.Text == txt_confirmSU.Text)
            {
                /* conn.Open();
                string register = "INSERT INTO user_password VALUES ('" + txt_userSU.Text + " " + txt_passwordSU.Text + "')"; // send new username and password to database
                cmd = new OleDbCommand(register,conn);
                cmd.ExecuteNonQuery();
                conn.Close(); */


                MessageBox.Show("Your account has been created","let's sign in",MessageBoxButtons.OK, MessageBoxIcon.Information); // create account successfully
            }
            else 
            {
                MessageBox.Show("Password does not match", "please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_passwordSU.Text = "";
                txt_confirmSU.Text = "";
                txt_userSU.Focus();
            }
        }

        private void checkbox_show_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkbox_show.Checked)
            {
                txt_passwordSU.PasswordChar = '\0';
                txt_confirmSU.PasswordChar= '\0';
            }
            else
            {
                txt_passwordSU.PasswordChar = '*';
                txt_confirmSU.PasswordChar = '*';
            }
        }

        private void link_signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignIn().Show();
            this.Hide();
        }

        private void SignUp_Load(object sender, System.EventArgs e)
        {

        }

        private void cbBox_month_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox_male.Checked)
            {
                checkBox_female.Enabled = false;
                checkBox_no.Enabled = false;
            }
            else
            {
                checkBox_female.Enabled = true;
                checkBox_no.Enabled = true;
            }
            
        }

        private void checkBox_female_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox_female.Checked)
            {
                checkBox_male.Enabled = false;
                checkBox_no.Enabled = false;
            }
            else
            {
                checkBox_male.Enabled = true;
                checkBox_no.Enabled = true;
            }
        }

        private void checkBox_no_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox_no.Checked)
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new signUpGoogle().Show();
            this.Hide();
        }
    }
}
