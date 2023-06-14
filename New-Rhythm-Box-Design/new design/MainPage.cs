using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using new_design.DTO;
using Newtonsoft.Json;
using NAudio.Wave;
using System.IO;
using Bunifu.Framework.UI;
using NAudio.Utils;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace new_design
{
    public partial class MainPage : Form
    {
        private WaveStream waveStream;
        private WaveChannel32 waveChannel;
        private byte[] songBytes;
        //private Timer timer;
        private double durationInSeconds;
        private TimeSpan songDuration;
        private bool isDraggingSlider = false;
        private WaveOutEvent waveOut;
        private Size formOriginalSize;
        ApiService apiService = new ApiService();
        private async void getTrack()
        {
            using (HttpClient client = new HttpClient()) 
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.GetAccessToken());
                try
                {
                    // Gửi yêu cầu GET tới URL
                    HttpResponseMessage response = await client.GetAsync("https://rhythmboxserver.azurewebsites.net/api/Home/track");

                    // Kiểm tra mã trạng thái của phản hồi
                    if (response.IsSuccessStatusCode)
                    {
                        
                        string content = await response.Content.ReadAsStringAsync();

                        List<Tracks> tracks = JsonConvert.DeserializeObject<List<Tracks>>(content);
                        
                        Item[] items = new Item[tracks.Count];
                        
                        int i = 0;
                        foreach (var track in tracks)
                        {
                            items[i] = new Item();
                            items[i].lbIdText = Convert.ToString(track.TrackID);
                            items[i].lbTitleText = track.Title;
                            items[i].LBNameText = track.FullName;
                            items[i].image = track.TrackImage;
                            flowLayoutPanel1.Controls.Add(items[i]);
                            items[i].Click += item_Click;
                            i++;
                        }    
                        
                    }
                    else
                    {
                        Console.WriteLine("Yêu cầu không thành công. Mã trạng thái: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }
        private async void item_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện Click của User Control
            
            Item clickedControl = (Item)sender;
            int id = Convert.ToInt32(clickedControl.lbIdText);
            string url = "https://rhythmboxserver.azurewebsites.net/api/Play/" + id;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenManager.GetAccessToken());
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<SongInfo> songInfo = JsonConvert.DeserializeObject<List<SongInfo>>(content);
                    lbTrackName.Text = songInfo[0].Title;
                    lbArtist.Text = songInfo[0].FullName;
                    songBytes = songInfo[0].MusicData;
                    durationInSeconds = songInfo[0].Duration.TotalSeconds;
                }
            }    
        }

        private void Play(byte[] audioData)
        {
            Stop(); // Dừng phát trước khi phát một bài hát mới (nếu có)

            // Tạo một MemoryStream từ mảng byte nhạc
            Task.Run(() =>
            {
                using (MemoryStream ms = new MemoryStream(audioData))
                {
                    using (Mp3FileReader mp3Reader = new Mp3FileReader(ms))
                    {
                        // Tạo đối tượng WaveOut để phát âm thanh
                        using (WaveOutEvent waveOut = new WaveOutEvent())
                        {
                            // Gán đối tượng Mp3FileReader cho đối tượng WaveOut
                            waveOut.Init(mp3Reader);

                            // Bắt đầu phát âm thanh
                            waveOut.Play();

                            // Đợi cho đến khi phát xong

                            while (waveOut.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(100);
                            }
                        }
                    }
                }
                // Tạo một RawSourceWaveStream từ MemoryStream
                //waveStream = new RawSourceWaveStream(ms, new WaveFormat(44100, 16, 2));

                //// Tạo một WaveChannel32 để tuỳ chỉnh tua bài hát
                //waveChannel = new WaveChannel32(waveStream);

                //// Tạo một instance của WaveOutEvent
                //waveOut = new WaveOutEvent();

                //// Gán waveChannel là source của waveOut
                //waveOut.Init(waveChannel);

                //// Bắt đầu phát âm thanh
                //waveOut.Play();
            });
        }
        private void Stop()
        {
            if (waveOut != null)
            {
                // Dừng phát âm thanh (nếu đang phát)
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }

            if (waveChannel != null)
            {
                // Đóng và giải phóng waveChannel và waveStream
                waveChannel.Dispose();
                waveChannel = null;
            }

            if (waveStream != null)
            {
                waveStream.Dispose();
                waveStream = null;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            getTrack();
        }
        private int borderSize = 2;
        private Size formSize;
        private Panel leftBorderBtn;

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

        }
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //Remove transparent border in maximized state
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel_introduction_Paint(object sender, PaintEventArgs e)
        {

        }
        bool userExpand = true;
        private void menu_transition_Tick(object sender, EventArgs e)
        {

        }

        private void btn_user_Click(object sender, EventArgs e)
        {

        }

        private void btn_user_Click_1(object sender, EventArgs e)
        {
            userTransition.Start();
        }

        private void userTransition_Tick(object sender, EventArgs e)
        {
            if (userExpand == false)
            {
                userContainer.Height += 10;
                if (userContainer.Height >= 160)
                {
                    userTransition.Stop();
                    userExpand = true;
                }
            }
            else
            {
                userContainer.Height -= 10;
                if (userContainer.Height <= 45)
                {
                    userTransition.Stop();
                    userExpand = false;
                }
            }
        }
        bool menuExpand = true;
        private void bunifuIconButton1_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

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
        
        private void bunifuHSlider1_Scroll(object sender, Utilities.BunifuSlider.BunifuHScrollBar.ScrollEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            loadform(new ProfileNew());
            
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            loadform(new HomeNew());
        }

        private void btn_playlist_Click(object sender, EventArgs e)
        {
            loadform(new PlaylistNew());
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            Play(songBytes);

            // Đặt thời lượng bài hát
            songDuration = TimeSpan.FromSeconds(durationInSeconds);


            bunifuHSlider1.Maximum = (int)songDuration.TotalSeconds;
            bunifuHSlider1.Value = 0;
            // Bắt đầu timer và cập nhật tiến độ
            //timer = new Timer();
            //timer.Interval = 1000; // Cập nhật mỗi giây
            //timer.Tick += Timer_Tick;
            //timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Lấy thời gian đã phát hiện tại
            TimeSpan elapsedTime = waveOut?.GetPositionTimeSpan() ?? TimeSpan.Zero;

            // Kiểm tra nếu người dùng đang kéo slider
            if (!isDraggingSlider)
            {
                // Cập nhật giá trị slider với tiến độ hiện tại
                bunifuHSlider1.Value = (int)elapsedTime.TotalSeconds;
            }

            // Cập nhật label với tiến độ của bài hát
            progressLabel.Text = elapsedTime.ToString(@"mm\:ss") + " / " + songDuration.ToString(@"mm\:ss");

            // Kiểm tra nếu bài hát đã hoàn thành
            if (elapsedTime >= songDuration)
            {
                Stop();
                //timer.Stop();
                progressLabel.Text = "00:00 / " + songDuration.ToString(@"mm\:ss");
                bunifuHSlider1.Value = 0;
            }
        }

        private void bunifuHSlider1_MouseDown(object sender, MouseEventArgs e)
        {
            isDraggingSlider = true;
        }

        private void bunifuHSlider1_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggingSlider = false;

            // Tua bài hát đến vị trí mới
            TimeSpan newPosition = TimeSpan.FromSeconds(bunifuHSlider1.Value);

            if (waveChannel != null)
            {
                // Đặt vị trí của waveChannel (tua bài hát)
                waveChannel.Position = (long)newPosition.TotalSeconds * waveChannel.WaveFormat.AverageBytesPerSecond;
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            Stop();
        }
    }
    }

