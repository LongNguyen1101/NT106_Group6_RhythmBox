namespace RhythmBox
{
    partial class forgotPassword
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
            this.txt_emailReset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_sendEmail = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password Reset";
            // 
            // txt_emailReset
            // 
            this.txt_emailReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_emailReset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_emailReset.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_emailReset.Location = new System.Drawing.Point(27, 250);
            this.txt_emailReset.Multiline = true;
            this.txt_emailReset.Name = "txt_emailReset";
            this.txt_emailReset.Size = new System.Drawing.Size(303, 29);
            this.txt_emailReset.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(23, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Email address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(24, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = "Enter your email address that you used to\r\nregister. We\'ll send you a number code" +
    " that \r\nyou can reset your password.";
            // 
            // btn_sendEmail
            // 
            this.btn_sendEmail.BackColor = System.Drawing.SystemColors.InfoText;
            this.btn_sendEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sendEmail.FlatAppearance.BorderSize = 0;
            this.btn_sendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sendEmail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_sendEmail.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.btn_sendEmail.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_sendEmail.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_sendEmail.IconSize = 30;
            this.btn_sendEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sendEmail.Location = new System.Drawing.Point(81, 311);
            this.btn_sendEmail.Name = "btn_sendEmail";
            this.btn_sendEmail.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.btn_sendEmail.Size = new System.Drawing.Size(200, 44);
            this.btn_sendEmail.TabIndex = 10;
            this.btn_sendEmail.Text = "Send";
            this.btn_sendEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_sendEmail.UseVisualStyleBackColor = false;
            this.btn_sendEmail.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // forgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(373, 544);
            this.Controls.Add(this.btn_sendEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_emailReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "forgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "forgotPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_emailReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btn_sendEmail;
    }
}