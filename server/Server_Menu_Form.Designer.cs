namespace server
{
    partial class Server_Menu_Form
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
            this.Side_Panel = new System.Windows.Forms.Panel();
            this.Side_Panel_Run = new System.Windows.Forms.Panel();
            this.Event_Log_Btn = new System.Windows.Forms.Button();
            this.Register_New_Member_btn = new System.Windows.Forms.Button();
            this.Main_Control_Btn = new System.Windows.Forms.Button();
            this.Logo_Panel = new System.Windows.Forms.Panel();
            this.Home_btn = new System.Windows.Forms.Button();
            this.Tool_Bar_Panel = new System.Windows.Forms.Panel();
            this.Current_Time_Label_Change = new System.Windows.Forms.Label();
            this.Current_Time_Label = new System.Windows.Forms.Label();
            this.UC_Control_Panel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Side_Panel.SuspendLayout();
            this.Logo_Panel.SuspendLayout();
            this.Tool_Bar_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Side_Panel
            // 
            this.Side_Panel.BackColor = System.Drawing.Color.Black;
            this.Side_Panel.Controls.Add(this.Side_Panel_Run);
            this.Side_Panel.Controls.Add(this.Event_Log_Btn);
            this.Side_Panel.Controls.Add(this.Register_New_Member_btn);
            this.Side_Panel.Controls.Add(this.Main_Control_Btn);
            this.Side_Panel.Controls.Add(this.Logo_Panel);
            this.Side_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Side_Panel.Location = new System.Drawing.Point(0, 0);
            this.Side_Panel.Name = "Side_Panel";
            this.Side_Panel.Size = new System.Drawing.Size(200, 641);
            this.Side_Panel.TabIndex = 0;
            // 
            // Side_Panel_Run
            // 
            this.Side_Panel_Run.BackColor = System.Drawing.Color.White;
            this.Side_Panel_Run.Location = new System.Drawing.Point(186, 83);
            this.Side_Panel_Run.Name = "Side_Panel_Run";
            this.Side_Panel_Run.Size = new System.Drawing.Size(11, 78);
            this.Side_Panel_Run.TabIndex = 4;
            // 
            // Event_Log_Btn
            // 
            this.Event_Log_Btn.BackColor = System.Drawing.Color.Brown;
            this.Event_Log_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Event_Log_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Event_Log_Btn.FlatAppearance.BorderSize = 3;
            this.Event_Log_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Event_Log_Btn.Font = new System.Drawing.Font("Cooper Black", 12.25F);
            this.Event_Log_Btn.ForeColor = System.Drawing.Color.White;
            this.Event_Log_Btn.Image = global::server.Properties.Resources.file;
            this.Event_Log_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Event_Log_Btn.Location = new System.Drawing.Point(0, 239);
            this.Event_Log_Btn.Name = "Event_Log_Btn";
            this.Event_Log_Btn.Size = new System.Drawing.Size(200, 78);
            this.Event_Log_Btn.TabIndex = 3;
            this.Event_Log_Btn.Text = "Events";
            this.Event_Log_Btn.UseVisualStyleBackColor = false;
            this.Event_Log_Btn.Click += new System.EventHandler(this.Event_Log_Btn_Click);
            // 
            // Register_New_Member_btn
            // 
            this.Register_New_Member_btn.BackColor = System.Drawing.Color.Brown;
            this.Register_New_Member_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Register_New_Member_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Register_New_Member_btn.FlatAppearance.BorderSize = 3;
            this.Register_New_Member_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Register_New_Member_btn.Font = new System.Drawing.Font("Cooper Black", 12.25F);
            this.Register_New_Member_btn.ForeColor = System.Drawing.Color.White;
            this.Register_New_Member_btn.Image = global::server.Properties.Resources.register;
            this.Register_New_Member_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Register_New_Member_btn.Location = new System.Drawing.Point(0, 161);
            this.Register_New_Member_btn.Name = "Register_New_Member_btn";
            this.Register_New_Member_btn.Size = new System.Drawing.Size(200, 78);
            this.Register_New_Member_btn.TabIndex = 2;
            this.Register_New_Member_btn.Text = "Register New Manager";
            this.Register_New_Member_btn.UseVisualStyleBackColor = false;
            this.Register_New_Member_btn.Click += new System.EventHandler(this.Register_New_Member_btn_Click);
            // 
            // Main_Control_Btn
            // 
            this.Main_Control_Btn.BackColor = System.Drawing.Color.Brown;
            this.Main_Control_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Main_Control_Btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Main_Control_Btn.FlatAppearance.BorderSize = 3;
            this.Main_Control_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Main_Control_Btn.Font = new System.Drawing.Font("Cooper Black", 12.25F);
            this.Main_Control_Btn.ForeColor = System.Drawing.Color.White;
            this.Main_Control_Btn.Image = global::server.Properties.Resources.control_panel;
            this.Main_Control_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Main_Control_Btn.Location = new System.Drawing.Point(0, 83);
            this.Main_Control_Btn.Name = "Main_Control_Btn";
            this.Main_Control_Btn.Size = new System.Drawing.Size(200, 78);
            this.Main_Control_Btn.TabIndex = 1;
            this.Main_Control_Btn.Text = "Control";
            this.Main_Control_Btn.UseVisualStyleBackColor = false;
            this.Main_Control_Btn.Click += new System.EventHandler(this.Main_Control_Btn_Click);
            // 
            // Logo_Panel
            // 
            this.Logo_Panel.Controls.Add(this.Home_btn);
            this.Logo_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logo_Panel.Location = new System.Drawing.Point(0, 0);
            this.Logo_Panel.Name = "Logo_Panel";
            this.Logo_Panel.Size = new System.Drawing.Size(200, 83);
            this.Logo_Panel.TabIndex = 0;
            // 
            // Home_btn
            // 
            this.Home_btn.BackColor = System.Drawing.Color.Brown;
            this.Home_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Home_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Home_btn.FlatAppearance.BorderSize = 3;
            this.Home_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Home_btn.Font = new System.Drawing.Font("Cooper Black", 18.25F);
            this.Home_btn.ForeColor = System.Drawing.Color.White;
            this.Home_btn.Image = global::server.Properties.Resources.servers2;
            this.Home_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Home_btn.Location = new System.Drawing.Point(0, 0);
            this.Home_btn.Name = "Home_btn";
            this.Home_btn.Size = new System.Drawing.Size(200, 83);
            this.Home_btn.TabIndex = 2;
            this.Home_btn.Text = "Server";
            this.Home_btn.UseVisualStyleBackColor = false;
            // 
            // Tool_Bar_Panel
            // 
            this.Tool_Bar_Panel.BackColor = System.Drawing.Color.Brown;
            this.Tool_Bar_Panel.Controls.Add(this.Current_Time_Label_Change);
            this.Tool_Bar_Panel.Controls.Add(this.Current_Time_Label);
            this.Tool_Bar_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Tool_Bar_Panel.Location = new System.Drawing.Point(200, 0);
            this.Tool_Bar_Panel.Name = "Tool_Bar_Panel";
            this.Tool_Bar_Panel.Size = new System.Drawing.Size(811, 83);
            this.Tool_Bar_Panel.TabIndex = 1;
            // 
            // Current_Time_Label_Change
            // 
            this.Current_Time_Label_Change.AutoSize = true;
            this.Current_Time_Label_Change.Font = new System.Drawing.Font("Cooper Black", 20.25F);
            this.Current_Time_Label_Change.ForeColor = System.Drawing.Color.White;
            this.Current_Time_Label_Change.Location = new System.Drawing.Point(324, 47);
            this.Current_Time_Label_Change.Name = "Current_Time_Label_Change";
            this.Current_Time_Label_Change.Size = new System.Drawing.Size(96, 31);
            this.Current_Time_Label_Change.TabIndex = 1;
            this.Current_Time_Label_Change.Text = "label1";
            this.Current_Time_Label_Change.Visible = false;
            // 
            // Current_Time_Label
            // 
            this.Current_Time_Label.AutoSize = true;
            this.Current_Time_Label.Font = new System.Drawing.Font("Cooper Black", 20.25F);
            this.Current_Time_Label.ForeColor = System.Drawing.Color.White;
            this.Current_Time_Label.Location = new System.Drawing.Point(309, 9);
            this.Current_Time_Label.Name = "Current_Time_Label";
            this.Current_Time_Label.Size = new System.Drawing.Size(207, 31);
            this.Current_Time_Label.TabIndex = 0;
            this.Current_Time_Label.Text = "Current_Time";
            // 
            // UC_Control_Panel
            // 
            this.UC_Control_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UC_Control_Panel.Location = new System.Drawing.Point(200, 83);
            this.UC_Control_Panel.Name = "UC_Control_Panel";
            this.UC_Control_Panel.Size = new System.Drawing.Size(811, 558);
            this.UC_Control_Panel.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Server_Menu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1011, 641);
            this.Controls.Add(this.UC_Control_Panel);
            this.Controls.Add(this.Tool_Bar_Panel);
            this.Controls.Add(this.Side_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Server_Menu_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Server_Menu_Form_Load);
            this.Side_Panel.ResumeLayout(false);
            this.Logo_Panel.ResumeLayout(false);
            this.Tool_Bar_Panel.ResumeLayout(false);
            this.Tool_Bar_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Side_Panel;
        private System.Windows.Forms.Panel Logo_Panel;
        private System.Windows.Forms.Button Event_Log_Btn;
        private System.Windows.Forms.Button Register_New_Member_btn;
        private System.Windows.Forms.Button Main_Control_Btn;
        private System.Windows.Forms.Panel Tool_Bar_Panel;
        private System.Windows.Forms.Panel Side_Panel_Run;
        private System.Windows.Forms.Button Home_btn;
        private System.Windows.Forms.Panel UC_Control_Panel;
        private System.Windows.Forms.Label Current_Time_Label;
        private System.Windows.Forms.Label Current_Time_Label_Change;
        private System.Windows.Forms.Timer timer1;
    }
}

