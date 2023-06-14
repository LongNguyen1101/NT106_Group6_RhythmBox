namespace RhythmBox
{
    partial class resetPassword
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
            this.btn_resetPassword = new FontAwesome.Sharp.IconButton();
            this.txt_newPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_confirmnewpassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label1.TabIndex = 3;
            this.label1.Text = "Reset Password";
            // 
            // btn_resetPassword
            // 
            this.btn_resetPassword.BackColor = System.Drawing.SystemColors.InfoText;
            this.btn_resetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_resetPassword.FlatAppearance.BorderSize = 0;
            this.btn_resetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resetPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_resetPassword.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.btn_resetPassword.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_resetPassword.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_resetPassword.IconSize = 30;
            this.btn_resetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_resetPassword.Location = new System.Drawing.Point(80, 310);
            this.btn_resetPassword.Name = "btn_resetPassword";
            this.btn_resetPassword.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.btn_resetPassword.Size = new System.Drawing.Size(200, 44);
            this.btn_resetPassword.TabIndex = 16;
            this.btn_resetPassword.Text = "Reset";
            this.btn_resetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_resetPassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_resetPassword.UseVisualStyleBackColor = false;
            // 
            // txt_newPassword
            // 
            this.txt_newPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_newPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_newPassword.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newPassword.Location = new System.Drawing.Point(31, 144);
            this.txt_newPassword.Multiline = true;
            this.txt_newPassword.Name = "txt_newPassword";
            this.txt_newPassword.Size = new System.Drawing.Size(303, 29);
            this.txt_newPassword.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(27, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "New Password:";
            // 
            // txt_confirmnewpassword
            // 
            this.txt_confirmnewpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_confirmnewpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_confirmnewpassword.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_confirmnewpassword.Location = new System.Drawing.Point(31, 208);
            this.txt_confirmnewpassword.Multiline = true;
            this.txt_confirmnewpassword.Name = "txt_confirmnewpassword";
            this.txt_confirmnewpassword.Size = new System.Drawing.Size(303, 29);
            this.txt_confirmnewpassword.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(27, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Confirm New Password:";
            // 
            // resetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(355, 497);
            this.Controls.Add(this.txt_confirmnewpassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_resetPassword);
            this.Controls.Add(this.txt_newPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "resetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "resetPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btn_resetPassword;
        private System.Windows.Forms.TextBox txt_newPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_confirmnewpassword;
        private System.Windows.Forms.Label label3;
    }
}