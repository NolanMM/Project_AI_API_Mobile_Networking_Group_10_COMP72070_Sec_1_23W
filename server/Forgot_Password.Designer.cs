namespace server
{
    partial class Forgot_Password
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Password_txtbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Timer_Sent_Label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Sent_btn = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Username_txtbox = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Confirm_password_txtbox = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.OTP_Input_txtbox = new System.Windows.Forms.TextBox();
            this.Confirm_btn = new System.Windows.Forms.Button();
            this.incorrect_message_OTP = new System.Windows.Forms.Label();
            this.incorrect_message_username = new System.Windows.Forms.Label();
            this.Timer_Sent = new System.Windows.Forms.Timer(this.components);
            this.Wrong_Confirm_lable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::server.Properties.Resources.gabriel_dalton_b7aqNnYRntY_unsplash__1_;
            this.pictureBox1.Location = new System.Drawing.Point(0, -143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 785);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Title.Font = new System.Drawing.Font("Cooper Black", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.IndianRed;
            this.Title.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Title.Location = new System.Drawing.Point(656, 56);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(356, 159);
            this.Title.TabIndex = 11;
            this.Title.Text = "Forgot Password";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.Password_txtbox);
            this.panel3.Location = new System.Drawing.Point(684, 342);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(315, 45);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(71, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(206, 1);
            this.panel4.TabIndex = 12;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::server.Properties.Resources._115724_key_lock_password_locked_secure_icon;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(15, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 38);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // Password_txtbox
            // 
            this.Password_txtbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Password_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_txtbox.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Password_txtbox.Location = new System.Drawing.Point(71, 7);
            this.Password_txtbox.Name = "Password_txtbox";
            this.Password_txtbox.Size = new System.Drawing.Size(206, 24);
            this.Password_txtbox.TabIndex = 7;
            this.Password_txtbox.Text = "Password";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Timer_Sent_Label);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Sent_btn);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.Username_txtbox);
            this.panel1.Location = new System.Drawing.Point(684, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 45);
            this.panel1.TabIndex = 16;
            // 
            // Timer_Sent_Label
            // 
            this.Timer_Sent_Label.AutoSize = true;
            this.Timer_Sent_Label.BackColor = System.Drawing.Color.Black;
            this.Timer_Sent_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer_Sent_Label.ForeColor = System.Drawing.Color.IndianRed;
            this.Timer_Sent_Label.Location = new System.Drawing.Point(250, 13);
            this.Timer_Sent_Label.Name = "Timer_Sent_Label";
            this.Timer_Sent_Label.Size = new System.Drawing.Size(27, 20);
            this.Timer_Sent_Label.TabIndex = 24;
            this.Timer_Sent_Label.Text = "00";
            this.Timer_Sent_Label.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(71, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 1);
            this.panel2.TabIndex = 12;
            // 
            // Sent_btn
            // 
            this.Sent_btn.AutoSize = true;
            this.Sent_btn.BackColor = System.Drawing.Color.Black;
            this.Sent_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sent_btn.ForeColor = System.Drawing.Color.IndianRed;
            this.Sent_btn.Location = new System.Drawing.Point(240, 13);
            this.Sent_btn.Name = "Sent_btn";
            this.Sent_btn.Size = new System.Drawing.Size(37, 17);
            this.Sent_btn.TabIndex = 13;
            this.Sent_btn.Text = "Sent";
            this.Sent_btn.Click += new System.EventHandler(this.Sent_btn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::server.Properties.Resources._2203549_admin_avatar_human_login_user_icon;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(15, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 38);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // Username_txtbox
            // 
            this.Username_txtbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Username_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Username_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_txtbox.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Username_txtbox.Location = new System.Drawing.Point(71, 7);
            this.Username_txtbox.Name = "Username_txtbox";
            this.Username_txtbox.Size = new System.Drawing.Size(206, 24);
            this.Username_txtbox.TabIndex = 7;
            this.Username_txtbox.Text = "Username";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.pictureBox5);
            this.panel7.Controls.Add(this.Confirm_password_txtbox);
            this.panel7.Location = new System.Drawing.Point(684, 413);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(315, 45);
            this.panel7.TabIndex = 19;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(71, 37);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(206, 1);
            this.panel8.TabIndex = 12;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = global::server.Properties.Resources._115724_key_lock_password_locked_secure_icon;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(15, 7);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(38, 38);
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // Confirm_password_txtbox
            // 
            this.Confirm_password_txtbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Confirm_password_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Confirm_password_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm_password_txtbox.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Confirm_password_txtbox.Location = new System.Drawing.Point(71, 7);
            this.Confirm_password_txtbox.Name = "Confirm_password_txtbox";
            this.Confirm_password_txtbox.Size = new System.Drawing.Size(206, 24);
            this.Confirm_password_txtbox.TabIndex = 7;
            this.Confirm_password_txtbox.Text = "Confirm Password";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.pictureBox6);
            this.panel9.Controls.Add(this.OTP_Input_txtbox);
            this.panel9.Location = new System.Drawing.Point(684, 267);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(315, 45);
            this.panel9.TabIndex = 20;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Location = new System.Drawing.Point(71, 37);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(206, 1);
            this.panel10.TabIndex = 12;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImage = global::server.Properties.Resources._134146_mail_email_icon;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(15, 7);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(38, 38);
            this.pictureBox6.TabIndex = 10;
            this.pictureBox6.TabStop = false;
            // 
            // OTP_Input_txtbox
            // 
            this.OTP_Input_txtbox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OTP_Input_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OTP_Input_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OTP_Input_txtbox.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.OTP_Input_txtbox.Location = new System.Drawing.Point(71, 7);
            this.OTP_Input_txtbox.Name = "OTP_Input_txtbox";
            this.OTP_Input_txtbox.Size = new System.Drawing.Size(206, 24);
            this.OTP_Input_txtbox.TabIndex = 7;
            this.OTP_Input_txtbox.Text = "OTP Code";
            // 
            // Confirm_btn
            // 
            this.Confirm_btn.BackColor = System.Drawing.Color.Black;
            this.Confirm_btn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm_btn.ForeColor = System.Drawing.Color.Snow;
            this.Confirm_btn.Location = new System.Drawing.Point(767, 547);
            this.Confirm_btn.Name = "Confirm_btn";
            this.Confirm_btn.Size = new System.Drawing.Size(144, 45);
            this.Confirm_btn.TabIndex = 21;
            this.Confirm_btn.Text = "Confirm";
            this.Confirm_btn.UseVisualStyleBackColor = false;
            this.Confirm_btn.Click += new System.EventHandler(this.Confirm_btn_Click);
            // 
            // incorrect_message_OTP
            // 
            this.incorrect_message_OTP.BackColor = System.Drawing.Color.Transparent;
            this.incorrect_message_OTP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.incorrect_message_OTP.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrect_message_OTP.ForeColor = System.Drawing.Color.IndianRed;
            this.incorrect_message_OTP.Location = new System.Drawing.Point(751, 317);
            this.incorrect_message_OTP.Name = "incorrect_message_OTP";
            this.incorrect_message_OTP.Size = new System.Drawing.Size(123, 22);
            this.incorrect_message_OTP.TabIndex = 22;
            this.incorrect_message_OTP.Text = "Incorrect OTP";
            this.incorrect_message_OTP.Visible = false;
            // 
            // incorrect_message_username
            // 
            this.incorrect_message_username.BackColor = System.Drawing.Color.Transparent;
            this.incorrect_message_username.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.incorrect_message_username.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrect_message_username.ForeColor = System.Drawing.Color.IndianRed;
            this.incorrect_message_username.Location = new System.Drawing.Point(755, 229);
            this.incorrect_message_username.Name = "incorrect_message_username";
            this.incorrect_message_username.Size = new System.Drawing.Size(156, 22);
            this.incorrect_message_username.TabIndex = 23;
            this.incorrect_message_username.Text = "Incorrect Username";
            this.incorrect_message_username.Visible = false;
            // 
            // Timer_Sent
            // 
            this.Timer_Sent.Enabled = true;
            this.Timer_Sent.Interval = 1000;
            this.Timer_Sent.Tick += new System.EventHandler(this.Timer_Sent_Tick);
            // 
            // Wrong_Confirm_lable
            // 
            this.Wrong_Confirm_lable.BackColor = System.Drawing.Color.Transparent;
            this.Wrong_Confirm_lable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Wrong_Confirm_lable.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wrong_Confirm_lable.ForeColor = System.Drawing.Color.IndianRed;
            this.Wrong_Confirm_lable.Location = new System.Drawing.Point(742, 461);
            this.Wrong_Confirm_lable.Name = "Wrong_Confirm_lable";
            this.Wrong_Confirm_lable.Size = new System.Drawing.Size(257, 22);
            this.Wrong_Confirm_lable.TabIndex = 24;
            this.Wrong_Confirm_lable.Text = "Incorrect Confirmation Password";
            this.Wrong_Confirm_lable.Visible = false;
            // 
            // Forgot_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1011, 641);
            this.Controls.Add(this.Wrong_Confirm_lable);
            this.Controls.Add(this.incorrect_message_username);
            this.Controls.Add(this.incorrect_message_OTP);
            this.Controls.Add(this.Confirm_btn);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Forgot_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgot_Password";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox Password_txtbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox Username_txtbox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox Confirm_password_txtbox;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox OTP_Input_txtbox;
        public System.Windows.Forms.Button Confirm_btn;
        private System.Windows.Forms.Label Sent_btn;
        public System.Windows.Forms.Label incorrect_message_OTP;
        public System.Windows.Forms.Label incorrect_message_username;
        private System.Windows.Forms.Timer Timer_Sent;
        private System.Windows.Forms.Label Timer_Sent_Label;
        public System.Windows.Forms.Label Wrong_Confirm_lable;
    }
}