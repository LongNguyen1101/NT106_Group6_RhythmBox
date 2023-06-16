namespace RhythmBox
{
    partial class SignIn
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
            this.link_signup = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_signin = new FontAwesome.Sharp.IconButton();
            this.checkbox_show = new System.Windows.Forms.CheckBox();
            this.txt_passwordSI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_userSI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // link_signup
            // 
            this.link_signup.ActiveLinkColor = System.Drawing.Color.White;
            this.link_signup.AutoSize = true;
            this.link_signup.LinkColor = System.Drawing.Color.White;
            this.link_signup.Location = new System.Drawing.Point(154, 402);
            this.link_signup.Name = "link_signup";
            this.link_signup.Size = new System.Drawing.Size(75, 20);
            this.link_signup.TabIndex = 22;
            this.link_signup.TabStop = true;
            this.link_signup.Text = "Sign Up";
            this.link_signup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_signup_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(83, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Don\'t have an Account?";
            // 
            // btn_signin
            // 
            this.btn_signin.BackColor = System.Drawing.SystemColors.InfoText;
            this.btn_signin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_signin.FlatAppearance.BorderSize = 0;
            this.btn_signin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_signin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_signin.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btn_signin.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_signin.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_signin.IconSize = 30;
            this.btn_signin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_signin.Location = new System.Drawing.Point(87, 304);
            this.btn_signin.Name = "btn_signin";
            this.btn_signin.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.btn_signin.Size = new System.Drawing.Size(200, 44);
            this.btn_signin.TabIndex = 20;
            this.btn_signin.Text = "Sign In";
            this.btn_signin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_signin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_signin.UseVisualStyleBackColor = false;
            this.btn_signin.Click += new System.EventHandler(this.btn_signin_Click);
            // 
            // checkbox_show
            // 
            this.checkbox_show.AutoSize = true;
            this.checkbox_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkbox_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkbox_show.Location = new System.Drawing.Point(201, 261);
            this.checkbox_show.Name = "checkbox_show";
            this.checkbox_show.Size = new System.Drawing.Size(160, 24);
            this.checkbox_show.TabIndex = 19;
            this.checkbox_show.Text = "Show Password";
            this.checkbox_show.UseVisualStyleBackColor = true;
            this.checkbox_show.CheckedChanged += new System.EventHandler(this.checkbox_show_CheckedChanged);
            // 
            // txt_passwordSI
            // 
            this.txt_passwordSI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_passwordSI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_passwordSI.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_passwordSI.Location = new System.Drawing.Point(31, 211);
            this.txt_passwordSI.Multiline = true;
            this.txt_passwordSI.Name = "txt_passwordSI";
            this.txt_passwordSI.PasswordChar = '*';
            this.txt_passwordSI.Size = new System.Drawing.Size(303, 29);
            this.txt_passwordSI.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(27, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Password:";
            // 
            // txt_userSI
            // 
            this.txt_userSI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_userSI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_userSI.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userSI.Location = new System.Drawing.Point(31, 142);
            this.txt_userSI.Multiline = true;
            this.txt_userSI.Name = "txt_userSI";
            this.txt_userSI.Size = new System.Drawing.Size(303, 29);
            this.txt_userSI.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(27, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sign In";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(87, 439);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(205, 20);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot Your Password?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(373, 544);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.link_signup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_signin);
            this.Controls.Add(this.checkbox_show);
            this.Controls.Add(this.txt_passwordSI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_userSI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel link_signup;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btn_signin;
        private System.Windows.Forms.CheckBox checkbox_show;
        private System.Windows.Forms.TextBox txt_passwordSI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_userSI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}