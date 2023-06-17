namespace RhythmBox
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelShow = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLibrary = new System.Windows.Forms.Panel();
            this.panelCover = new System.Windows.Forms.Panel();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_album = new FontAwesome.Sharp.IconButton();
            this.btn_artist = new FontAwesome.Sharp.IconButton();
            this.btn_playlist = new FontAwesome.Sharp.IconButton();
            this.panelMainPage = new System.Windows.Forms.Panel();
            this.btn_search = new FontAwesome.Sharp.IconButton();
            this.btn_logout = new FontAwesome.Sharp.IconButton();
            this.btn_settings = new FontAwesome.Sharp.IconButton();
            this.btn_profile = new FontAwesome.Sharp.IconButton();
            this.btn_user = new FontAwesome.Sharp.IconButton();
            this.btn_home = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.splitContainerPage = new System.Windows.Forms.SplitContainer();
            this.panelTrackControl = new System.Windows.Forms.Panel();
            this.panelController = new System.Windows.Forms.Panel();
            this.labelTrackRunning = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.labelDuration = new System.Windows.Forms.Label();
            this.iconRandom = new FontAwesome.Sharp.IconButton();
            this.iconPlay = new FontAwesome.Sharp.IconButton();
            this.iconLooping = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.lbTrackTitle = new System.Windows.Forms.Label();
            this.splitContainerControl = new System.Windows.Forms.SplitContainer();
            this.panelLibrary.SuspendLayout();
            this.panelCover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelMainPage.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPage)).BeginInit();
            this.splitContainerPage.Panel1.SuspendLayout();
            this.splitContainerPage.Panel2.SuspendLayout();
            this.splitContainerPage.SuspendLayout();
            this.panelTrackControl.SuspendLayout();
            this.panelController.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.Panel1.SuspendLayout();
            this.splitContainerControl.Panel2.SuspendLayout();
            this.splitContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelShow
            // 
            this.flowLayoutPanelShow.AutoScroll = true;
            this.flowLayoutPanelShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelShow.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanelShow.Name = "flowLayoutPanelShow";
            this.flowLayoutPanelShow.Size = new System.Drawing.Size(1067, 524);
            this.flowLayoutPanelShow.TabIndex = 1;
            // 
            // panelLibrary
            // 
            this.panelLibrary.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panelLibrary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLibrary.Controls.Add(this.panelCover);
            this.panelLibrary.Controls.Add(this.panel3);
            this.panelLibrary.Controls.Add(this.panelMainPage);
            this.panelLibrary.Controls.Add(this.panel4);
            this.panelLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLibrary.Location = new System.Drawing.Point(0, 0);
            this.panelLibrary.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelLibrary.Name = "panelLibrary";
            this.panelLibrary.Size = new System.Drawing.Size(159, 662);
            this.panelLibrary.TabIndex = 4;
            // 
            // panelCover
            // 
            this.panelCover.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelCover.Controls.Add(this.pictureBoxCover);
            this.panelCover.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCover.Location = new System.Drawing.Point(0, 526);
            this.panelCover.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCover.Name = "panelCover";
            this.panelCover.Size = new System.Drawing.Size(157, 134);
            this.panelCover.TabIndex = 0;
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.Location = new System.Drawing.Point(20, 14);
            this.pictureBoxCover.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(117, 107);
            this.pictureBoxCover.TabIndex = 12;
            this.pictureBoxCover.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel3.Controls.Add(this.btn_album);
            this.panel3.Controls.Add(this.btn_artist);
            this.panel3.Controls.Add(this.btn_playlist);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 290);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(157, 140);
            this.panel3.TabIndex = 9;
            // 
            // btn_album
            // 
            this.btn_album.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_album.FlatAppearance.BorderSize = 0;
            this.btn_album.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_album.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_album.ForeColor = System.Drawing.Color.White;
            this.btn_album.IconChar = FontAwesome.Sharp.IconChar.CompactDisc;
            this.btn_album.IconColor = System.Drawing.Color.White;
            this.btn_album.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_album.IconSize = 30;
            this.btn_album.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_album.Location = new System.Drawing.Point(0, 90);
            this.btn_album.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_album.Name = "btn_album";
            this.btn_album.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btn_album.Size = new System.Drawing.Size(157, 45);
            this.btn_album.TabIndex = 4;
            this.btn_album.Text = "Album";
            this.btn_album.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_album.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_album.UseVisualStyleBackColor = true;
            // 
            // btn_artist
            // 
            this.btn_artist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_artist.FlatAppearance.BorderSize = 0;
            this.btn_artist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_artist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_artist.ForeColor = System.Drawing.Color.White;
            this.btn_artist.IconChar = FontAwesome.Sharp.IconChar.Guitar;
            this.btn_artist.IconColor = System.Drawing.Color.White;
            this.btn_artist.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_artist.IconSize = 30;
            this.btn_artist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_artist.Location = new System.Drawing.Point(0, 45);
            this.btn_artist.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_artist.Name = "btn_artist";
            this.btn_artist.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btn_artist.Size = new System.Drawing.Size(157, 45);
            this.btn_artist.TabIndex = 2;
            this.btn_artist.Text = "Artist";
            this.btn_artist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_artist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_artist.UseVisualStyleBackColor = true;
            // 
            // btn_playlist
            // 
            this.btn_playlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_playlist.FlatAppearance.BorderSize = 0;
            this.btn_playlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_playlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_playlist.ForeColor = System.Drawing.Color.White;
            this.btn_playlist.IconChar = FontAwesome.Sharp.IconChar.Music;
            this.btn_playlist.IconColor = System.Drawing.Color.White;
            this.btn_playlist.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_playlist.IconSize = 30;
            this.btn_playlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_playlist.Location = new System.Drawing.Point(0, 0);
            this.btn_playlist.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_playlist.Name = "btn_playlist";
            this.btn_playlist.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btn_playlist.Size = new System.Drawing.Size(157, 45);
            this.btn_playlist.TabIndex = 1;
            this.btn_playlist.Text = "Playlist";
            this.btn_playlist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_playlist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_playlist.UseVisualStyleBackColor = true;
            // 
            // panelMainPage
            // 
            this.panelMainPage.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panelMainPage.Controls.Add(this.btn_search);
            this.panelMainPage.Controls.Add(this.btn_logout);
            this.panelMainPage.Controls.Add(this.btn_settings);
            this.panelMainPage.Controls.Add(this.btn_profile);
            this.panelMainPage.Controls.Add(this.btn_user);
            this.panelMainPage.Controls.Add(this.btn_home);
            this.panelMainPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMainPage.Location = new System.Drawing.Point(0, 16);
            this.panelMainPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelMainPage.Name = "panelMainPage";
            this.panelMainPage.Size = new System.Drawing.Size(157, 274);
            this.panelMainPage.TabIndex = 8;
            // 
            // btn_search
            // 
            this.btn_search.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_search.FlatAppearance.BorderSize = 0;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btn_search.IconColor = System.Drawing.Color.White;
            this.btn_search.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_search.IconSize = 30;
            this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.Location = new System.Drawing.Point(0, 171);
            this.btn_search.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_search.Name = "btn_search";
            this.btn_search.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btn_search.Size = new System.Drawing.Size(157, 45);
            this.btn_search.TabIndex = 7;
            this.btn_search.Text = "Search";
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // btn_logout
            // 
            this.btn_logout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_logout.FlatAppearance.BorderSize = 0;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.ForeColor = System.Drawing.Color.White;
            this.btn_logout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btn_logout.IconColor = System.Drawing.Color.White;
            this.btn_logout.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_logout.IconSize = 20;
            this.btn_logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.Location = new System.Drawing.Point(0, 146);
            this.btn_logout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Padding = new System.Windows.Forms.Padding(30, 0, 15, 0);
            this.btn_logout.Size = new System.Drawing.Size(157, 25);
            this.btn_logout.TabIndex = 6;
            this.btn_logout.Text = "Log out";
            this.btn_logout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_logout.UseVisualStyleBackColor = true;
            // 
            // btn_settings
            // 
            this.btn_settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_settings.FlatAppearance.BorderSize = 0;
            this.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_settings.ForeColor = System.Drawing.Color.White;
            this.btn_settings.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btn_settings.IconColor = System.Drawing.Color.White;
            this.btn_settings.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_settings.IconSize = 20;
            this.btn_settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_settings.Location = new System.Drawing.Point(0, 121);
            this.btn_settings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Padding = new System.Windows.Forms.Padding(30, 0, 15, 0);
            this.btn_settings.Size = new System.Drawing.Size(157, 25);
            this.btn_settings.TabIndex = 5;
            this.btn_settings.Text = "Settings";
            this.btn_settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_settings.UseVisualStyleBackColor = true;
            // 
            // btn_profile
            // 
            this.btn_profile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_profile.FlatAppearance.BorderSize = 0;
            this.btn_profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_profile.ForeColor = System.Drawing.Color.White;
            this.btn_profile.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.btn_profile.IconColor = System.Drawing.Color.White;
            this.btn_profile.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_profile.IconSize = 20;
            this.btn_profile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_profile.Location = new System.Drawing.Point(0, 96);
            this.btn_profile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_profile.Name = "btn_profile";
            this.btn_profile.Padding = new System.Windows.Forms.Padding(30, 0, 15, 0);
            this.btn_profile.Size = new System.Drawing.Size(157, 25);
            this.btn_profile.TabIndex = 4;
            this.btn_profile.Text = "Profile";
            this.btn_profile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_profile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_profile.UseVisualStyleBackColor = true;
            // 
            // btn_user
            // 
            this.btn_user.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_user.FlatAppearance.BorderSize = 0;
            this.btn_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_user.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.btn_user.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btn_user.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_user.IconSize = 30;
            this.btn_user.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_user.Location = new System.Drawing.Point(0, 51);
            this.btn_user.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_user.Name = "btn_user";
            this.btn_user.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btn_user.Size = new System.Drawing.Size(157, 45);
            this.btn_user.TabIndex = 2;
            this.btn_user.Text = "User";
            this.btn_user.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_user.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_user.UseVisualStyleBackColor = true;
            // 
            // btn_home
            // 
            this.btn_home.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_home.FlatAppearance.BorderSize = 0;
            this.btn_home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_home.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_home.ForeColor = System.Drawing.Color.White;
            this.btn_home.IconChar = FontAwesome.Sharp.IconChar.House;
            this.btn_home.IconColor = System.Drawing.Color.White;
            this.btn_home.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_home.IconSize = 30;
            this.btn_home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_home.Location = new System.Drawing.Point(0, 0);
            this.btn_home.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_home.Name = "btn_home";
            this.btn_home.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btn_home.Size = new System.Drawing.Size(157, 51);
            this.btn_home.TabIndex = 1;
            this.btn_home.Text = "Home";
            this.btn_home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_home.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(157, 16);
            this.panel4.TabIndex = 0;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelDesktop.Controls.Add(this.splitContainerPage);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1067, 662);
            this.panelDesktop.TabIndex = 4;
            // 
            // splitContainerPage
            // 
            this.splitContainerPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPage.Location = new System.Drawing.Point(0, 0);
            this.splitContainerPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainerPage.Name = "splitContainerPage";
            this.splitContainerPage.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerPage.Panel1
            // 
            this.splitContainerPage.Panel1.Controls.Add(this.flowLayoutPanelShow);
            // 
            // splitContainerPage.Panel2
            // 
            this.splitContainerPage.Panel2.Controls.Add(this.panelTrackControl);
            this.splitContainerPage.Size = new System.Drawing.Size(1067, 662);
            this.splitContainerPage.SplitterDistance = 524;
            this.splitContainerPage.SplitterWidth = 3;
            this.splitContainerPage.TabIndex = 1;
            // 
            // panelTrackControl
            // 
            this.panelTrackControl.AutoSize = true;
            this.panelTrackControl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTrackControl.Controls.Add(this.panelController);
            this.panelTrackControl.Controls.Add(this.lbTrackTitle);
            this.panelTrackControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTrackControl.Location = new System.Drawing.Point(0, 0);
            this.panelTrackControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTrackControl.Name = "panelTrackControl";
            this.panelTrackControl.Size = new System.Drawing.Size(1067, 135);
            this.panelTrackControl.TabIndex = 15;
            // 
            // panelController
            // 
            this.panelController.Controls.Add(this.labelTrackRunning);
            this.panelController.Controls.Add(this.trackBar);
            this.panelController.Controls.Add(this.labelDuration);
            this.panelController.Controls.Add(this.iconRandom);
            this.panelController.Controls.Add(this.iconPlay);
            this.panelController.Controls.Add(this.iconLooping);
            this.panelController.Controls.Add(this.iconButton2);
            this.panelController.Controls.Add(this.iconButton5);
            this.panelController.Location = new System.Drawing.Point(115, 14);
            this.panelController.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelController.Name = "panelController";
            this.panelController.Size = new System.Drawing.Size(837, 88);
            this.panelController.TabIndex = 14;
            // 
            // labelTrackRunning
            // 
            this.labelTrackRunning.AutoSize = true;
            this.labelTrackRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrackRunning.Location = new System.Drawing.Point(28, 45);
            this.labelTrackRunning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTrackRunning.Name = "labelTrackRunning";
            this.labelTrackRunning.Size = new System.Drawing.Size(18, 13);
            this.labelTrackRunning.TabIndex = 13;
            this.labelTrackRunning.Text = "-|--";
            this.labelTrackRunning.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // trackBar
            // 
            this.trackBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.trackBar.Location = new System.Drawing.Point(51, 41);
            this.trackBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(729, 45);
            this.trackBar.TabIndex = 12;
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDuration.Location = new System.Drawing.Point(779, 43);
            this.labelDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(18, 13);
            this.labelDuration.TabIndex = 14;
            this.labelDuration.Text = "-|--";
            // 
            // iconRandom
            // 
            this.iconRandom.FlatAppearance.BorderSize = 0;
            this.iconRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconRandom.IconChar = FontAwesome.Sharp.IconChar.Random;
            this.iconRandom.IconColor = System.Drawing.Color.DimGray;
            this.iconRandom.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconRandom.IconSize = 30;
            this.iconRandom.Location = new System.Drawing.Point(248, 12);
            this.iconRandom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iconRandom.Name = "iconRandom";
            this.iconRandom.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.iconRandom.Size = new System.Drawing.Size(30, 25);
            this.iconRandom.TabIndex = 9;
            this.iconRandom.UseVisualStyleBackColor = true;
            this.iconRandom.Click += new System.EventHandler(this.iconRandom_Click);
            // 
            // iconPlay
            // 
            this.iconPlay.FlatAppearance.BorderSize = 0;
            this.iconPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.iconPlay.IconColor = System.Drawing.Color.Black;
            this.iconPlay.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPlay.IconSize = 40;
            this.iconPlay.Location = new System.Drawing.Point(416, 6);
            this.iconPlay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iconPlay.Name = "iconPlay";
            this.iconPlay.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.iconPlay.Size = new System.Drawing.Size(43, 38);
            this.iconPlay.TabIndex = 8;
            this.iconPlay.UseVisualStyleBackColor = true;
            this.iconPlay.Click += new System.EventHandler(this.iconPlay_Click);
            // 
            // iconLooping
            // 
            this.iconLooping.FlatAppearance.BorderSize = 0;
            this.iconLooping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconLooping.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconLooping.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.iconLooping.IconColor = System.Drawing.Color.DimGray;
            this.iconLooping.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconLooping.IconSize = 30;
            this.iconLooping.Location = new System.Drawing.Point(576, 12);
            this.iconLooping.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iconLooping.Name = "iconLooping";
            this.iconLooping.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.iconLooping.Size = new System.Drawing.Size(30, 25);
            this.iconLooping.TabIndex = 10;
            this.iconLooping.UseVisualStyleBackColor = true;
            this.iconLooping.Click += new System.EventHandler(this.iconLooping_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.BackwardStep;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton2.IconSize = 30;
            this.iconButton2.Location = new System.Drawing.Point(334, 14);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.iconButton2.Size = new System.Drawing.Size(30, 25);
            this.iconButton2.TabIndex = 11;
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton5
            // 
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.ForwardStep;
            this.iconButton5.IconColor = System.Drawing.Color.Black;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton5.IconSize = 30;
            this.iconButton5.Location = new System.Drawing.Point(492, 12);
            this.iconButton5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.iconButton5.Size = new System.Drawing.Size(30, 25);
            this.iconButton5.TabIndex = 7;
            this.iconButton5.UseVisualStyleBackColor = true;
            // 
            // lbTrackTitle
            // 
            this.lbTrackTitle.AutoSize = true;
            this.lbTrackTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrackTitle.Location = new System.Drawing.Point(8, 105);
            this.lbTrackTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTrackTitle.Name = "lbTrackTitle";
            this.lbTrackTitle.Size = new System.Drawing.Size(0, 25);
            this.lbTrackTitle.TabIndex = 13;
            this.lbTrackTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainerControl.Name = "splitContainerControl";
            // 
            // splitContainerControl.Panel1
            // 
            this.splitContainerControl.Panel1.Controls.Add(this.panelLibrary);
            // 
            // splitContainerControl.Panel2
            // 
            this.splitContainerControl.Panel2.Controls.Add(this.panelDesktop);
            this.splitContainerControl.Size = new System.Drawing.Size(1229, 662);
            this.splitContainerControl.SplitterDistance = 159;
            this.splitContainerControl.SplitterWidth = 3;
            this.splitContainerControl.TabIndex = 2;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1229, 662);
            this.Controls.Add(this.splitContainerControl);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainPage";
            this.Text = "RhythmBox";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainPage_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLibrary.ResumeLayout(false);
            this.panelCover.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panelMainPage.ResumeLayout(false);
            this.panelDesktop.ResumeLayout(false);
            this.splitContainerPage.Panel1.ResumeLayout(false);
            this.splitContainerPage.Panel2.ResumeLayout(false);
            this.splitContainerPage.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPage)).EndInit();
            this.splitContainerPage.ResumeLayout(false);
            this.panelTrackControl.ResumeLayout(false);
            this.panelTrackControl.PerformLayout();
            this.panelController.ResumeLayout(false);
            this.panelController.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.splitContainerControl.Panel1.ResumeLayout(false);
            this.splitContainerControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelShow;
        private System.Windows.Forms.Panel panelLibrary;
        private System.Windows.Forms.Panel panelCover;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btn_album;
        private FontAwesome.Sharp.IconButton btn_artist;
        private FontAwesome.Sharp.IconButton btn_playlist;
        private System.Windows.Forms.Panel panelMainPage;
        private FontAwesome.Sharp.IconButton btn_search;
        private FontAwesome.Sharp.IconButton btn_logout;
        private FontAwesome.Sharp.IconButton btn_settings;
        private FontAwesome.Sharp.IconButton btn_profile;
        private FontAwesome.Sharp.IconButton btn_user;
        private FontAwesome.Sharp.IconButton btn_home;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.SplitContainer splitContainerPage;
        private System.Windows.Forms.Panel panelTrackControl;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconLooping;
        private FontAwesome.Sharp.IconButton iconPlay;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconRandom;
        private System.Windows.Forms.Label lbTrackTitle;
        private System.Windows.Forms.SplitContainer splitContainerControl;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label labelTrackRunning;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Panel panelController;
    }
}

