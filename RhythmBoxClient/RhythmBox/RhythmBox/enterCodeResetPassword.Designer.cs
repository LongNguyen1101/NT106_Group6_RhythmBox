namespace RhythmBox
{
    partial class enterCodeResetPassword
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
            this.label3 = new System.Windows.Forms.Label();
            this.btn_sendCode = new FontAwesome.Sharp.IconButton();
            this.txt_codeReset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Your Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(23, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(321, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "We have sent a code to your email, type them\r\nbelow to reset your password.\r\n";
            // 
            // btn_sendCode
            // 
            this.btn_sendCode.BackColor = System.Drawing.SystemColors.InfoText;
            this.btn_sendCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sendCode.FlatAppearance.BorderSize = 0;
            this.btn_sendCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sendCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sendCode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_sendCode.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.btn_sendCode.IconColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_sendCode.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_sendCode.IconSize = 30;
            this.btn_sendCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sendCode.Location = new System.Drawing.Point(80, 286);
            this.btn_sendCode.Name = "btn_sendCode";
            this.btn_sendCode.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.btn_sendCode.Size = new System.Drawing.Size(200, 44);
            this.btn_sendCode.TabIndex = 13;
            this.btn_sendCode.Text = "Send";
            this.btn_sendCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sendCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_sendCode.UseVisualStyleBackColor = false;
            this.btn_sendCode.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_codeReset
            // 
            this.txt_codeReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.txt_codeReset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_codeReset.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_codeReset.Location = new System.Drawing.Point(26, 225);
            this.txt_codeReset.Multiline = true;
            this.txt_codeReset.Name = "txt_codeReset";
            this.txt_codeReset.Size = new System.Drawing.Size(303, 29);
            this.txt_codeReset.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(22, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Your code:";
            // 
            // enterCodeResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(373, 544);
            this.Controls.Add(this.btn_sendCode);
            this.Controls.Add(this.txt_codeReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "enterCodeResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "enterCodeResetPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btn_sendCode;
        private System.Windows.Forms.TextBox txt_codeReset;
        private System.Windows.Forms.Label label2;
    }
}