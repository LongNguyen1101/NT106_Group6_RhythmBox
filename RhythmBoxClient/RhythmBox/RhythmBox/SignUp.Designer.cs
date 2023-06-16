namespace RhythmBox
{
    partial class SignUp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_userSU = new System.Windows.Forms.TextBox();
            this.txt_passwordSU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_confirmSU = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkbox_show = new System.Windows.Forms.CheckBox();
            this.btn_signup = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.link_signin = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_year = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBox_month = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_day = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_male = new System.Windows.Forms.CheckBox();
            this.checkBox_female = new System.Windows.Forms.CheckBox();
            this.checkBox_no = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign Up";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(26, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username:";
            // 
            // txt_userSU
            // 
            this.txt_userSU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_userSU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_userSU.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userSU.Location = new System.Drawing.Point(30, 130);
            this.txt_userSU.Multiline = true;
            this.txt_userSU.Name = "txt_userSU";
            this.txt_userSU.Size = new System.Drawing.Size(303, 29);
            this.txt_userSU.TabIndex = 3;
            // 
            // txt_passwordSU
            // 
            this.txt_passwordSU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_passwordSU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_passwordSU.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_passwordSU.Location = new System.Drawing.Point(30, 199);
            this.txt_passwordSU.Multiline = true;
            this.txt_passwordSU.Name = "txt_passwordSU";
            this.txt_passwordSU.PasswordChar = '*';
            this.txt_passwordSU.Size = new System.Drawing.Size(303, 29);
            this.txt_passwordSU.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(26, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // txt_confirmSU
            // 
            this.txt_confirmSU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_confirmSU.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_confirmSU.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_confirmSU.Location = new System.Drawing.Point(30, 269);
            this.txt_confirmSU.Multiline = true;
            this.txt_confirmSU.Name = "txt_confirmSU";
            this.txt_confirmSU.PasswordChar = '*';
            this.txt_confirmSU.Size = new System.Drawing.Size(303, 29);
            this.txt_confirmSU.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(26, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Confirm Password:";
            // 
            // checkbox_show
            // 
            this.checkbox_show.AutoSize = true;
            this.checkbox_show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkbox_show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkbox_show.Location = new System.Drawing.Point(203, 304);
            this.checkbox_show.Name = "checkbox_show";
            this.checkbox_show.Size = new System.Drawing.Size(160, 24);
            this.checkbox_show.TabIndex = 8;
            this.checkbox_show.Text = "Show Password";
            this.checkbox_show.UseVisualStyleBackColor = true;
            this.checkbox_show.CheckedChanged += new System.EventHandler(this.checkbox_show_CheckedChanged);
            // 
            // btn_signup
            // 
            this.btn_signup.BackColor = System.Drawing.SystemColors.InfoText;
            this.btn_signup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_signup.FlatAppearance.BorderSize = 0;
            this.btn_signup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_signup.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btn_signup.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_signup.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_signup.IconSize = 30;
            this.btn_signup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_signup.Location = new System.Drawing.Point(85, 613);
            this.btn_signup.Name = "btn_signup";
            this.btn_signup.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.btn_signup.Size = new System.Drawing.Size(200, 44);
            this.btn_signup.TabIndex = 9;
            this.btn_signup.Text = "Sign Up";
            this.btn_signup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_signup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_signup.UseVisualStyleBackColor = false;
            this.btn_signup.Click += new System.EventHandler(this.btn_signup_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(47, 676);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Have an Account?";
            // 
            // link_signin
            // 
            this.link_signin.ActiveLinkColor = System.Drawing.Color.White;
            this.link_signin.AutoSize = true;
            this.link_signin.LinkColor = System.Drawing.Color.White;
            this.link_signin.Location = new System.Drawing.Point(218, 676);
            this.link_signin.Name = "link_signin";
            this.link_signin.Size = new System.Drawing.Size(67, 20);
            this.link_signin.TabIndex = 11;
            this.link_signin.TabStop = true;
            this.link_signin.Text = "Sign In";
            this.link_signin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_signin_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(26, 496);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 20);
            this.label11.TabIndex = 34;
            this.label11.Text = "Gender:";
            // 
            // txt_year
            // 
            this.txt_year.Location = new System.Drawing.Point(271, 451);
            this.txt_year.Name = "txt_year";
            this.txt_year.Size = new System.Drawing.Size(90, 27);
            this.txt_year.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(267, 427);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 20);
            this.label10.TabIndex = 32;
            this.label10.Text = "Year";
            // 
            // cbBox_month
            // 
            this.cbBox_month.FormattingEnabled = true;
            this.cbBox_month.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cbBox_month.Location = new System.Drawing.Point(118, 450);
            this.cbBox_month.Name = "cbBox_month";
            this.cbBox_month.Size = new System.Drawing.Size(121, 28);
            this.cbBox_month.TabIndex = 31;
            this.cbBox_month.SelectedIndexChanged += new System.EventHandler(this.cbBox_month_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(114, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Month:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(26, 397);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(233, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "What is your date of birth?";
            // 
            // txt_day
            // 
            this.txt_day.Location = new System.Drawing.Point(30, 450);
            this.txt_day.Name = "txt_day";
            this.txt_day.Size = new System.Drawing.Size(58, 27);
            this.txt_day.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(26, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "Day:";
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_email.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(30, 344);
            this.txt_email.Multiline = true;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(303, 29);
            this.txt_email.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(26, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Email:";
            // 
            // checkBox_male
            // 
            this.checkBox_male.AutoSize = true;
            this.checkBox_male.Location = new System.Drawing.Point(30, 519);
            this.checkBox_male.Name = "checkBox_male";
            this.checkBox_male.Size = new System.Drawing.Size(71, 24);
            this.checkBox_male.TabIndex = 36;
            this.checkBox_male.Text = "Male";
            this.checkBox_male.UseVisualStyleBackColor = true;
            this.checkBox_male.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox_female
            // 
            this.checkBox_female.AutoSize = true;
            this.checkBox_female.Location = new System.Drawing.Point(158, 519);
            this.checkBox_female.Name = "checkBox_female";
            this.checkBox_female.Size = new System.Drawing.Size(92, 24);
            this.checkBox_female.TabIndex = 37;
            this.checkBox_female.Text = "Female";
            this.checkBox_female.UseVisualStyleBackColor = true;
            this.checkBox_female.CheckedChanged += new System.EventHandler(this.checkBox_female_CheckedChanged);
            // 
            // checkBox_no
            // 
            this.checkBox_no.AutoSize = true;
            this.checkBox_no.Location = new System.Drawing.Point(30, 549);
            this.checkBox_no.Name = "checkBox_no";
            this.checkBox_no.Size = new System.Drawing.Size(189, 24);
            this.checkBox_no.TabIndex = 38;
            this.checkBox_no.Text = "Don\'t prefer to say";
            this.checkBox_no.UseVisualStyleBackColor = true;
            this.checkBox_no.CheckedChanged += new System.EventHandler(this.checkBox_no_CheckedChanged);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(373, 783);
            this.Controls.Add(this.checkBox_no);
            this.Controls.Add(this.checkBox_female);
            this.Controls.Add(this.checkBox_male);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_year);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbBox_month);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_day);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.link_signin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_signup);
            this.Controls.Add(this.checkbox_show);
            this.Controls.Add(this.txt_confirmSU);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_passwordSU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_userSU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.SignUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_userSU;
        private System.Windows.Forms.TextBox txt_passwordSU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_confirmSU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkbox_show;
        private FontAwesome.Sharp.IconButton btn_signup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel link_signin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_year;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbBox_month;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_day;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_male;
        private System.Windows.Forms.CheckBox checkBox_female;
        private System.Windows.Forms.CheckBox checkBox_no;
    }
}