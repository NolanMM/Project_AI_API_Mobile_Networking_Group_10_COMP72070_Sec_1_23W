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
            this.Connection_ID_Online_Listview = new System.Windows.Forms.ListView();
            this.UserID_Client = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status_Client = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OFF_btn = new System.Windows.Forms.Button();
            this.On_Btn = new System.Windows.Forms.Button();
            this.ON_OFF_log_listview = new System.Windows.Forms.ListView();
            this.UserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Side_Panel.SuspendLayout();
            this.Logo_Panel.SuspendLayout();
            this.Tool_Bar_Panel.SuspendLayout();
            this.UC_Control_Panel.SuspendLayout();
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
            this.UC_Control_Panel.Controls.Add(this.textBox1);
            this.UC_Control_Panel.Controls.Add(this.label3);
            this.UC_Control_Panel.Controls.Add(this.label2);
            this.UC_Control_Panel.Controls.Add(this.label1);
            this.UC_Control_Panel.Controls.Add(this.Connection_ID_Online_Listview);
            this.UC_Control_Panel.Controls.Add(this.OFF_btn);
            this.UC_Control_Panel.Controls.Add(this.On_Btn);
            this.UC_Control_Panel.Controls.Add(this.ON_OFF_log_listview);
            this.UC_Control_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UC_Control_Panel.Location = new System.Drawing.Point(200, 83);
            this.UC_Control_Panel.Name = "UC_Control_Panel";
            this.UC_Control_Panel.Size = new System.Drawing.Size(811, 555);
            this.UC_Control_Panel.TabIndex = 2;
            // 
            // Connection_ID_Online_Listview
            // 
            this.Connection_ID_Online_Listview.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Connection_ID_Online_Listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserID_Client,
            this.Status_Client});
            this.Connection_ID_Online_Listview.GridLines = true;
            this.Connection_ID_Online_Listview.HideSelection = false;
            this.Connection_ID_Online_Listview.Location = new System.Drawing.Point(18, 72);
            this.Connection_ID_Online_Listview.Name = "Connection_ID_Online_Listview";
            this.Connection_ID_Online_Listview.Size = new System.Drawing.Size(324, 162);
            this.Connection_ID_Online_Listview.TabIndex = 35;
            this.Connection_ID_Online_Listview.UseCompatibleStateImageBehavior = false;
            this.Connection_ID_Online_Listview.View = System.Windows.Forms.View.Details;
            // 
            // UserID_Client
            // 
            this.UserID_Client.Text = "Client ID";
            this.UserID_Client.Width = 146;
            // 
            // Status_Client
            // 
            this.Status_Client.Text = "Client Status";
            this.Status_Client.Width = 146;
            // 
            // OFF_btn
            // 
            this.OFF_btn.BackColor = System.Drawing.Color.Black;
            this.OFF_btn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OFF_btn.ForeColor = System.Drawing.Color.IndianRed;
            this.OFF_btn.Location = new System.Drawing.Point(393, 390);
            this.OFF_btn.Name = "OFF_btn";
            this.OFF_btn.Size = new System.Drawing.Size(144, 45);
            this.OFF_btn.TabIndex = 34;
            this.OFF_btn.Text = "OFF";
            this.OFF_btn.UseVisualStyleBackColor = false;
            this.OFF_btn.Click += new System.EventHandler(this.OFF_btn_Click);
            // 
            // On_Btn
            // 
            this.On_Btn.BackColor = System.Drawing.Color.Black;
            this.On_Btn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.On_Btn.ForeColor = System.Drawing.Color.Snow;
            this.On_Btn.Location = new System.Drawing.Point(198, 390);
            this.On_Btn.Name = "On_Btn";
            this.On_Btn.Size = new System.Drawing.Size(144, 45);
            this.On_Btn.TabIndex = 33;
            this.On_Btn.Text = "ON";
            this.On_Btn.UseVisualStyleBackColor = false;
            // 
            // ON_OFF_log_listview
            // 
            this.ON_OFF_log_listview.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ON_OFF_log_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserID,
            this.Date,
            this.Status});
            this.ON_OFF_log_listview.ForeColor = System.Drawing.Color.SeaGreen;
            this.ON_OFF_log_listview.GridLines = true;
            this.ON_OFF_log_listview.HideSelection = false;
            this.ON_OFF_log_listview.Location = new System.Drawing.Point(393, 72);
            this.ON_OFF_log_listview.Name = "ON_OFF_log_listview";
            this.ON_OFF_log_listview.Size = new System.Drawing.Size(382, 162);
            this.ON_OFF_log_listview.TabIndex = 32;
            this.ON_OFF_log_listview.UseCompatibleStateImageBehavior = false;
            this.ON_OFF_log_listview.View = System.Windows.Forms.View.Details;
            // 
            // UserID
            // 
            this.UserID.Text = "Manager ID";
            this.UserID.Width = 144;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Date.Width = 121;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Status.Width = 100;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 20.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(48, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 31);
            this.label1.TabIndex = 36;
            this.label1.Text = "Connected Clients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 20.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(462, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 31);
            this.label2.TabIndex = 37;
            this.label2.Text = "State Server Log";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 20.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(261, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 31);
            this.label3.TabIndex = 38;
            this.label3.Text = "Current Status";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(315, 329);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 39);
            this.textBox1.TabIndex = 39;
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
            this.UC_Control_Panel.ResumeLayout(false);
            this.UC_Control_Panel.PerformLayout();
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
        private System.Windows.Forms.ListView ON_OFF_log_listview;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Status;
        public System.Windows.Forms.Button OFF_btn;
        public System.Windows.Forms.Button On_Btn;
        private System.Windows.Forms.ListView Connection_ID_Online_Listview;
        private System.Windows.Forms.ColumnHeader UserID_Client;
        private System.Windows.Forms.ColumnHeader Status_Client;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

