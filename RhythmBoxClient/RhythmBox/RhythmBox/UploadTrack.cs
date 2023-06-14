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
    public partial class UploadTrack : Form
    {
        public UploadTrack()
        {
            InitializeComponent();
        }

        private void UploadTrack_Load(object sender, EventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Form MainPage = Application.OpenForms["MainPage"];
            MainPage.Show();
            this.Hide();
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            new Profile().Show();
            this.Hide();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            new settings().Show();
            this.Hide();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            new SignIn().Show();
            this.Hide();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            new searchPage().Show();
            this.Hide();
        }

        private void btn_playlist_Click(object sender, EventArgs e)
        {
            new playlistPage().Show();
            this.Hide();
        }

        private void btn_artist_Click(object sender, EventArgs e)
        {
            new Artist().Show();
            this.Hide();
        }

        private void btn_album_Click(object sender, EventArgs e)
        {
            new Album().Show();
            this.Hide();
        }
    }
}
