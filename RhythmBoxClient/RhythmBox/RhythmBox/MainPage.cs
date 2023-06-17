using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using NAudio.Wave;
using Newtonsoft.Json.Linq;

namespace RhythmBox
{

    public partial class MainPage : Form
    {
        FlowLayoutPanel panelRecentlyPlayed, panelTopTrack, panelTopAlbum, panelTopArtist;
        TableLayoutPanel tableRecentlyPlayed, tableTopTrack, tableTopAlbum, tableTopArtist;
        Label labelRecentlyPlayed, labelTopTrack, labelTopAlbum, labelTopArtist;
        string pageColor = "#a9dedc";
        string baseUrl = "https://rhythmboxserver.azurewebsites.net/api";
        HttpClient client = new HttpClient();
        string token = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJsb25nbmd1eWVuaG9hbmcxMTAxMUBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNjg2OTc0MTMyfQ.cEqxEJA7KmAADhJioCDSCAhwG9xbOs38Nxf81icSAXESTeBbVliLAlXj5PPoScfGWVxxbrfwv-DAp-ysHoXt9A";
        private bool isPlaying = false;
        private bool isLooping = false;
        private bool isRandom = false;
        private Thread playbackThread;
        private WaveOutEvent waveOut;
        private System.Windows.Forms.Timer trackBarTimer;
        private Mp3FileReader mp3Reader;

        public MainPage()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_home.ForeColor = Color.FromArgb(192, 255, 255);
            btn_home.IconColor = Color.FromArgb(192, 255, 255);

            this.SizeChanged += MainForm_SizeChanged;
            splitContainerPage.FixedPanel = FixedPanel.Panel2;
            panelController.Padding = new Padding(0);
            lbTrackTitle.TextAlign = ContentAlignment.MiddleCenter;

            trackBarTimer = new System.Windows.Forms.Timer();
            trackBarTimer.Interval = 100; 
            trackBarTimer.Tick += TrackBarTimer_Tick;
            trackBar.Scroll += new EventHandler(TrackBar_Scroll);
            trackBar.Minimum = 0;

            addTable();
            addPanel();
            addLabel();

            tableRecentlyPlayed.Controls.Add(labelRecentlyPlayed, 0, 0);
            tableRecentlyPlayed.Controls.Add(panelRecentlyPlayed, 0, 1);

            tableTopTrack.Controls.Add(labelTopTrack, 0, 0);
            tableTopTrack.Controls.Add(panelTopTrack, 0, 1);

            tableTopAlbum.Controls.Add(labelTopAlbum, 0, 0);
            tableTopAlbum.Controls.Add(panelTopAlbum, 0, 1);

            tableTopArtist.Controls.Add(labelTopArtist, 0, 0);
            tableTopArtist.Controls.Add(panelTopArtist, 0, 1);

            //Add Table to FlowLayoutPanel
            flowLayoutPanelShow.Controls.Add(tableRecentlyPlayed);
            flowLayoutPanelShow.Controls.Add(tableTopTrack);
            flowLayoutPanelShow.Controls.Add(tableTopAlbum);
            flowLayoutPanelShow.Controls.Add(tableTopArtist);

            flowLayoutPanelShow.BackColor = ColorTranslator.FromHtml(pageColor);

            getRecentlyPlayed();
            getTopTrack();
            getTopArtist();
            getTopAlbum();
        }

        private void addTable()
        {
            tableRecentlyPlayed = new TableLayoutPanel();
            tableRecentlyPlayed.BackColor = System.Drawing.ColorTranslator.FromHtml(pageColor);
            tableRecentlyPlayed.Width = flowLayoutPanelShow.Width;
            tableRecentlyPlayed.AutoSize = true;
            tableRecentlyPlayed.RowCount = 2;
            tableRecentlyPlayed.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            tableRecentlyPlayed.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            tableTopTrack = new TableLayoutPanel();
            tableTopTrack.BackColor = ColorTranslator.FromHtml(pageColor);
            tableTopTrack.Width = flowLayoutPanelShow.Width;
            tableTopTrack.AutoSize = true;
            tableTopTrack.RowCount = 2;
            tableTopTrack.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            tableTopTrack.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            tableTopAlbum = new TableLayoutPanel();
            tableTopAlbum.BackColor = System.Drawing.ColorTranslator.FromHtml(pageColor);
            tableTopAlbum.Width = flowLayoutPanelShow.Width;
            tableTopAlbum.AutoSize = true;
            tableTopAlbum.RowCount = 2;
            tableTopAlbum.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            tableTopAlbum.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            tableTopArtist = new TableLayoutPanel();
            tableTopArtist.BackColor = System.Drawing.ColorTranslator.FromHtml(pageColor);
            tableTopArtist.Width = flowLayoutPanelShow.Width;
            tableTopArtist.AutoSize = true;
            tableTopArtist.RowCount = 2;
            tableTopArtist.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            tableTopArtist.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        }

        private void addPanel()
        {
            panelRecentlyPlayed = new FlowLayoutPanel();
            panelRecentlyPlayed.FlowDirection = FlowDirection.LeftToRight;
            panelRecentlyPlayed.BackColor = ColorTranslator.FromHtml(pageColor);
            panelRecentlyPlayed.Width = flowLayoutPanelShow.Width;
            panelRecentlyPlayed.Dock = DockStyle.Top;
            panelRecentlyPlayed.AutoSize = true;

            panelTopTrack = new FlowLayoutPanel();
            panelTopTrack.FlowDirection = FlowDirection.LeftToRight;
            panelTopTrack.BackColor = ColorTranslator.FromHtml(pageColor);
            panelTopTrack.Width = flowLayoutPanelShow.Width;
            panelTopTrack.AutoSize = true;

            panelTopAlbum = new FlowLayoutPanel();
            panelTopAlbum.FlowDirection = FlowDirection.LeftToRight;
            panelTopAlbum.BackColor = System.Drawing.ColorTranslator.FromHtml(pageColor);
            panelTopAlbum.Width = flowLayoutPanelShow.Width;
            panelTopAlbum.AutoSize = true;

            panelTopArtist = new FlowLayoutPanel();
            panelTopArtist.FlowDirection = FlowDirection.LeftToRight;
            panelTopArtist.BackColor = System.Drawing.ColorTranslator.FromHtml(pageColor);
            panelTopArtist.Width = flowLayoutPanelShow.Width;
            panelTopArtist.AutoSize = true;
        }

        private void addLabel()
        {
            labelRecentlyPlayed = new Label();
            labelRecentlyPlayed.Text = "Rencently Played";
            labelRecentlyPlayed.Dock = DockStyle.Fill;
            labelRecentlyPlayed.Font = new Font("Arial", 20, FontStyle.Bold);
            labelRecentlyPlayed.ForeColor = Color.Black; 
            labelRecentlyPlayed.Location = new Point(5, 5);

            labelTopTrack = new Label();
            labelTopTrack.Text = "Top Track";
            labelTopTrack.AutoSize = true;
            labelTopTrack.Font = new Font("Arial", 20, FontStyle.Bold);
            labelTopTrack.ForeColor = Color.Black; 
            labelTopTrack.Location = new Point(5, 5);

            labelTopAlbum = new Label();
            labelTopAlbum.Text = "Top Album";
            labelTopAlbum.AutoSize = true;
            labelTopAlbum.Font = new Font("Arial", 20, FontStyle.Bold);
            labelTopAlbum.ForeColor = Color.Black;
            labelTopAlbum.Location = new Point(5, 5);

            labelTopArtist = new Label();
            labelTopArtist.Text = "Top Artist";
            labelTopArtist.AutoSize = true;
            labelTopArtist.Font = new Font("Arial", 20, FontStyle.Bold);
            labelTopArtist.ForeColor = Color.Black;
            labelTopArtist.Location = new Point(5, 5);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            int panelWidth = flowLayoutPanelShow.ClientSize.Width - flowLayoutPanelShow.Padding.Horizontal;

            foreach (Control panel in flowLayoutPanelShow.Controls)
            {
                panel.Width = panelWidth;
            }

            tableRecentlyPlayed.Width = flowLayoutPanelShow.Width;

            panelController.Location = CalculateGroupBoxPosition();
        }

        private Point CalculateGroupBoxPosition()
        {
            int x = (splitContainerPage.Panel2.ClientSize.Width - panelController.Width) / 2;
            int y = (splitContainerPage.Panel2.ClientSize.Height - panelController.Height) / 2;
            return new Point(x, y);
        }

        private async void getRecentlyPlayed()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/Home/recentlyPlayed");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    JArray content = JArray.Parse(jsonResponse);

                    displayRecentlyPlayed(content);
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error from getting tracks {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void getTopTrack()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/Home/track");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    JArray content = JArray.Parse(jsonResponse);

                    displayTrack(content);
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error from getting tracks {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void getTopAlbum()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/Home/album");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    JArray content = JArray.Parse(jsonResponse);

                    displayTopAlbum(content);
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error from getting tracks {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void getTopArtist()
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/Home/artist");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    JArray content = JArray.Parse(jsonResponse);

                    displayTopArtist(content);
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error from getting tracks {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void displayTrack(JArray tracks)
        {
            foreach (JObject track in tracks)
            {
                Panel childPanel = new Panel();
                childPanel.BackColor = ColorTranslator.FromHtml(pageColor);
                childPanel.Width = 300;
                childPanel.Height = 400;

                Image image;
                byte[] imageData = track["TrackImage"].ToObject<byte[]>();
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = Image.FromStream(ms);
                }

                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = image;

                Label label = new Label();
                label.Text = track["Title"].ToString();
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Dock = DockStyle.Bottom;

                childPanel.Click += (sender, e) =>
                {
                    setUpWhilePlaying(track["TrackID"].ToObject<int>(), track["Title"].ToString(), image);
                };

                pictureBox.Click += (sender, e) =>
                {
                    setUpWhilePlaying(track["TrackID"].ToObject<int>(), track["Title"].ToString(), image);
                };

                label.Click += (sender, e) =>
                {
                    setUpWhilePlaying(track["TrackID"].ToObject<int>(), track["Title"].ToString(), image);
                };

                childPanel.Controls.Add(label);
                childPanel.Controls.Add(pictureBox);

                panelTopTrack.Controls.Add(childPanel);
            }
        }

        private void displayRecentlyPlayed(JArray tracks)
        {
            foreach (JObject track in tracks)
            {
                Panel childPanel = new Panel();
                childPanel.BackColor = ColorTranslator.FromHtml(pageColor);
                childPanel.Width = 300;
                childPanel.Height = 400;

                Image image;
                byte[] imageData = track["TrackImage"].ToObject<byte[]>();
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = Image.FromStream(ms);
                }

                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = image;

                Label label = new Label();
                label.Text = track["Title"].ToString();
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Dock = DockStyle.Bottom;

                childPanel.Click += (sender, e) =>
                {
                    setUpWhilePlaying(track["TrackID"].ToObject<int>(), track["Title"].ToString(), image);
                };

                pictureBox.Click += (sender, e) =>
                {
                    setUpWhilePlaying(track["TrackID"].ToObject<int>(), track["Title"].ToString(), image);
                };

                label.Click += (sender, e) =>
                {
                    setUpWhilePlaying(track["TrackID"].ToObject<int>(), track["Title"].ToString(), image);
                };

                childPanel.Controls.Add(label);
                childPanel.Controls.Add(pictureBox);

                panelRecentlyPlayed.Controls.Add(childPanel);
            }
        }

        private void displayTopAlbum(JArray albums)
        {
            foreach (JObject album in albums)
            {
                Panel childPanel = new Panel();
                childPanel.BackColor = ColorTranslator.FromHtml(pageColor);
                childPanel.Width = 300;
                childPanel.Height = 400;

                Image image;
                byte[] imageData = album["Item3"].ToObject<byte[]>();
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = Image.FromStream(ms);
                }

                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = image;

                Label label = new Label();
                label.Text = album["Item2"].ToString();
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Dock = DockStyle.Bottom;

                childPanel.Controls.Add(label);
                childPanel.Controls.Add(pictureBox);

                panelTopAlbum.Controls.Add(childPanel);
            }
        }

        private void displayTopArtist(JArray artists)
        {
            foreach (JObject artist in artists)
            {
                Panel childPanel = new Panel();
                childPanel.BackColor = ColorTranslator.FromHtml(pageColor);
                childPanel.Width = 300;
                childPanel.Height = 400;

                Image image;
                byte[] imageData = artist["ArtistImage"].ToObject<byte[]>();
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = Image.FromStream(ms);
                }

                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = image;

                Label label = new Label();
                label.Text = artist["FullName"].ToString();
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Dock = DockStyle.Bottom;

                childPanel.Controls.Add(label);
                childPanel.Controls.Add(pictureBox);

                panelTopArtist.Controls.Add(childPanel);
            }
        }

        private async Task<(TimeSpan, byte[])?> getTrack(int trackId)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/Play/trackID?trackID={trackId}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject content = JObject.Parse(jsonResponse);

                    return (content["Item3"].ToObject<TimeSpan>(), content["Item4"].ToObject<byte[]>());
                }
                else
                {
                    MessageBox.Show(response.StatusCode.ToString());
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error from getting tracks {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

        private async void playTrack(int trackId)
        {
            isPlaying = true;

            var data = await Task.Run(() => getTrack(trackId).Result);

            trackBar.Maximum = (int)data.Value.Item1.TotalSeconds;
            labelDuration.Text = data.Value.Item1.ToString().Replace("00:", "");

            playbackThread = new Thread(() =>
            {
                byte[] audioData = data.Value.Item2;

                MemoryStream stream = new MemoryStream(audioData);
                mp3Reader = new Mp3FileReader(stream);
                waveOut = new WaveOutEvent();
                    
                waveOut.Init(mp3Reader);
                waveOut.Play();

                isPlaying = true;

                while (waveOut.PlaybackState == PlaybackState.Playing && isPlaying)
                {
                    Thread.Sleep(100);
                }

                waveOut.Stop();
            });

            playbackThread.Start();
        }

        private void stopPlayTrack()
        {
            
            if (isPlaying)
            {
                if (playbackThread !=  null) playbackThread.Abort();
                waveOut.Dispose();
                mp3Reader.Dispose();
                trackBarTimer.Stop();
            }
            isPlaying = false;
        }

        private void displayTitle(string title, Image image)
        {
            pictureBoxCover.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCover.Dock = DockStyle.Fill;
            pictureBoxCover.Image = image;

            lbTrackTitle.Text = title;
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopPlayTrack();
        }

        private void iconPlay_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                isPlaying = false;
                iconPlay.IconChar = IconChar.Play;
                if (waveOut != null) waveOut.Pause();
            }
            else
            {
                if (waveOut == null) return;
                isPlaying = true;
                iconPlay.IconChar = IconChar.Pause;
                if (waveOut != null) waveOut.Play();
            }
        }

        private void setUpWhilePlaying(int id, string title, Image image)
        {
            if (isPlaying) stopPlayTrack();
            playTrack(id);
            displayTitle(title, image);
            iconPlay.IconChar = IconChar.Pause;
            trackBarTimer.Start();
        }

        private void TrackBarTimer_Tick(object sender, EventArgs e)
        {
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                TimeSpan currentTime = mp3Reader.CurrentTime;

                labelTrackRunning.Text = currentTime.ToString(@"mm\:ss");
                trackBar.Value = (int)currentTime.TotalSeconds;

                if (mp3Reader.Position >= mp3Reader.Length)
                {
                    if (isLooping)
                    {
                        mp3Reader.Position = 0;
                        waveOut.Play();
                    }
                    else
                    {
                        iconPlay.IconChar = IconChar.Play;
                        stopPlayTrack();
                    }
                }
            }
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
            {
                int trackBarValue = trackBar.Value;

                TimeSpan newPosition = TimeSpan.FromSeconds(trackBarValue);

                mp3Reader.CurrentTime = newPosition;
            }
        }

        private void iconLooping_Click(object sender, EventArgs e)
        {
            if (isLooping)
            {
                isLooping = false;
                iconLooping.IconColor = Color.DimGray;
            }
            else
            {
                isLooping = true;
                iconLooping.IconColor = Color.Black;
            }
        }

        private void iconRandom_Click(object sender, EventArgs e)
        {
            isRandom = !isRandom;

            if (isLooping)
            {
                iconRandom.IconColor = Color.DimGray;
            }
            else
            {
                iconRandom.IconColor = Color.Black;
            }

        }


    }
}
