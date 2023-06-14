using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new_design
{
    public partial class MainPageForArtists : Form
    {
        
        public MainPageForArtists()
        {
            InitializeComponent();
        }
       
        private void MainPageForArtists_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        public void loadform(object Form)
        {
            if (this.mainPanel.Controls.Count > 0)
            {
                this.mainPanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
        }
        private void btn_user_Click(object sender, EventArgs e)
        {
            artistTransition.Start();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }
        bool menuExpand = true;
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                menuPanel.Width -= 10;
                if (menuPanel.Width <= 70)
                {
                    menuExpand = false;
                    menuTransition.Stop();
                }
            }
            else
            {
                menuPanel.Width += 10;
                if (menuPanel.Width >= 200)
                {
                    menuExpand = true;
                    menuTransition.Stop();
                }
            }
        }
        bool artistExpand = true; 
        private void artistTransition_Tick(object sender, EventArgs e)
        {
            if (artistExpand == false)
            {
                userContainer.Height += 10;
                if (userContainer.Height >= 270)
                {
                    artistTransition.Stop();
                    artistExpand = true;
                }
            }
            else
            {
                userContainer.Height -= 10;
                if (userContainer.Height <= 45)
                {
                    artistTransition.Stop();
                    artistExpand = false;
                }
            }
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_profile_Click_1(object sender, EventArgs e)
        {
            loadform(new ProfileNew());
        }

        private void btn_upload_Click_1(object sender, EventArgs e)
        {
            loadform(new UploadNew());
        }

        private void btn_myAlbums_Click(object sender, EventArgs e)
        {
            loadform(new MyAlbumNew());
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            loadform(new SettingsNew());
        }

        private void btn_album_Click(object sender, EventArgs e)
        {
            loadform(new AlbumNew());
        }

        private void btn_artist_Click(object sender, EventArgs e)
        {
            loadform(new ArtistNew());
        }

        private void btn_playlist_Click(object sender, EventArgs e)
        {
            loadform(new PlaylistNew());
        }

        private void btn_home_Click_1(object sender, EventArgs e)
        {
            loadform(new HomeForArtistsNew());
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
