﻿namespace server
{
    partial class Login_Server_Form
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
            this.Username_txtbox = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Password_txtbox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Forgot_Password_btn = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Sign_Up_btn = new System.Windows.Forms.Button();
            this.Login_Btn = new System.Windows.Forms.Button();
            this.incorrect_message_username = new System.Windows.Forms.Label();
            this.Incorrect_message_Password = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
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
            this.Username_txtbox.TextChanged += new System.EventHandler(this.Username_txtbox_TextChanged);
            this.Username_txtbox.MouseEnter += new System.EventHandler(this.Username_txtbox_MouseEnter);
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
            this.Title.TabIndex = 9;
            this.Title.Text = "Sign In To Access The Portal";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.Username_txtbox);
            this.panel1.Location = new System.Drawing.Point(684, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 45);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(71, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 1);
            this.panel2.TabIndex = 12;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.Password_txtbox);
            this.panel3.Location = new System.Drawing.Point(684, 331);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(315, 45);
            this.panel3.TabIndex = 12;
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
            this.Password_txtbox.TextChanged += new System.EventHandler(this.Password_txtbox_TextChanged);
            this.Password_txtbox.MouseEnter += new System.EventHandler(this.Password_txtbox_MouseEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::server.Properties.Resources.gabriel_dalton_b7aqNnYRntY_unsplash__1_;
            this.pictureBox1.Location = new System.Drawing.Point(0, -143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 785);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Forgot_Password_btn);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(684, 397);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(116, 36);
            this.panel5.TabIndex = 15;
            // 
            // Forgot_Password_btn
            // 
            this.Forgot_Password_btn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Forgot_Password_btn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Forgot_Password_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Forgot_Password_btn.ForeColor = System.Drawing.Color.IndianRed;
            this.Forgot_Password_btn.Location = new System.Drawing.Point(16, 9);
            this.Forgot_Password_btn.Name = "Forgot_Password_btn";
            this.Forgot_Password_btn.ReadOnly = true;
            this.Forgot_Password_btn.Size = new System.Drawing.Size(99, 14);
            this.Forgot_Password_btn.TabIndex = 13;
            this.Forgot_Password_btn.Text = "Forgot Password";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(16, 29);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(94, 1);
            this.panel6.TabIndex = 12;
            // 
            // Sign_Up_btn
            // 
            this.Sign_Up_btn.BackColor = System.Drawing.Color.Black;
            this.Sign_Up_btn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sign_Up_btn.ForeColor = System.Drawing.Color.Snow;
            this.Sign_Up_btn.Location = new System.Drawing.Point(684, 470);
            this.Sign_Up_btn.Name = "Sign_Up_btn";
            this.Sign_Up_btn.Size = new System.Drawing.Size(144, 45);
            this.Sign_Up_btn.TabIndex = 16;
            this.Sign_Up_btn.Text = "Sign Up";
            this.Sign_Up_btn.UseVisualStyleBackColor = false;
            this.Sign_Up_btn.Click += new System.EventHandler(this.Sign_Up_btn_Click);
            // 
            // Login_Btn
            // 
            this.Login_Btn.BackColor = System.Drawing.Color.Black;
            this.Login_Btn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Btn.ForeColor = System.Drawing.Color.IndianRed;
            this.Login_Btn.Location = new System.Drawing.Point(855, 470);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(144, 45);
            this.Login_Btn.TabIndex = 17;
            this.Login_Btn.Text = "Login";
            this.Login_Btn.UseVisualStyleBackColor = false;
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            // 
            // incorrect_message_username
            // 
            this.incorrect_message_username.BackColor = System.Drawing.Color.Transparent;
            this.incorrect_message_username.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.incorrect_message_username.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrect_message_username.ForeColor = System.Drawing.Color.IndianRed;
            this.incorrect_message_username.Location = new System.Drawing.Point(751, 309);
            this.incorrect_message_username.Name = "incorrect_message_username";
            this.incorrect_message_username.Size = new System.Drawing.Size(156, 22);
            this.incorrect_message_username.TabIndex = 18;
            this.incorrect_message_username.Text = "Incorrect Username";
            this.incorrect_message_username.Visible = false;
            // 
            // Incorrect_message_Password
            // 
            this.Incorrect_message_Password.BackColor = System.Drawing.Color.Transparent;
            this.Incorrect_message_Password.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Incorrect_message_Password.Font = new System.Drawing.Font("Franklin Gothic Heavy", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Incorrect_message_Password.ForeColor = System.Drawing.Color.IndianRed;
            this.Incorrect_message_Password.Location = new System.Drawing.Point(752, 372);
            this.Incorrect_message_Password.Name = "Incorrect_message_Password";
            this.Incorrect_message_Password.Size = new System.Drawing.Size(155, 22);
            this.Incorrect_message_Password.TabIndex = 19;
            this.Incorrect_message_Password.Text = "Incorrect Password";
            this.Incorrect_message_Password.Visible = false;
            // 
            // Login_Server_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1011, 641);
            this.Controls.Add(this.Incorrect_message_Password);
            this.Controls.Add(this.incorrect_message_username);
            this.Controls.Add(this.Login_Btn);
            this.Controls.Add(this.Sign_Up_btn);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login_Server_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login_Server_Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Username_txtbox;
        public System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox Password_txtbox;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox Forgot_Password_btn;
        public System.Windows.Forms.Button Sign_Up_btn;
        public System.Windows.Forms.Button Login_Btn;
        public System.Windows.Forms.Label incorrect_message_username;
        public System.Windows.Forms.Label Incorrect_message_Password;
    }
}