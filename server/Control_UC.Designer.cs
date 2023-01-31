namespace server
{
    partial class Control_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.On_Btn = new System.Windows.Forms.Button();
            this.OFF_btn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.Disconnect_Btn = new System.Windows.Forms.Button();
            this.ON_OFF_log_listview = new System.Windows.Forms.ListView();
            this.UserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // On_Btn
            // 
            this.On_Btn.BackColor = System.Drawing.Color.Black;
            this.On_Btn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.On_Btn.ForeColor = System.Drawing.Color.Snow;
            this.On_Btn.Location = new System.Drawing.Point(38, 239);
            this.On_Btn.Name = "On_Btn";
            this.On_Btn.Size = new System.Drawing.Size(144, 45);
            this.On_Btn.TabIndex = 26;
            this.On_Btn.Text = "ON";
            this.On_Btn.UseVisualStyleBackColor = false;
            // 
            // OFF_btn
            // 
            this.OFF_btn.BackColor = System.Drawing.Color.Black;
            this.OFF_btn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OFF_btn.ForeColor = System.Drawing.Color.IndianRed;
            this.OFF_btn.Location = new System.Drawing.Point(260, 239);
            this.OFF_btn.Name = "OFF_btn";
            this.OFF_btn.Size = new System.Drawing.Size(144, 45);
            this.OFF_btn.TabIndex = 27;
            this.OFF_btn.Text = "OFF";
            this.OFF_btn.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(462, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(298, 162);
            this.listView1.TabIndex = 28;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(38, 308);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(722, 228);
            this.listView2.TabIndex = 29;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // Disconnect_Btn
            // 
            this.Disconnect_Btn.BackColor = System.Drawing.Color.Black;
            this.Disconnect_Btn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Disconnect_Btn.ForeColor = System.Drawing.Color.IndianRed;
            this.Disconnect_Btn.Location = new System.Drawing.Point(531, 239);
            this.Disconnect_Btn.Name = "Disconnect_Btn";
            this.Disconnect_Btn.Size = new System.Drawing.Size(154, 45);
            this.Disconnect_Btn.TabIndex = 30;
            this.Disconnect_Btn.Text = "Disconnect";
            this.Disconnect_Btn.UseVisualStyleBackColor = false;
            // 
            // ON_OFF_log_listview
            // 
            this.ON_OFF_log_listview.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ON_OFF_log_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserID,
            this.Date,
            this.Status});
            this.ON_OFF_log_listview.ForeColor = System.Drawing.Color.SeaGreen;
            this.ON_OFF_log_listview.HideSelection = false;
            this.ON_OFF_log_listview.Location = new System.Drawing.Point(38, 49);
            this.ON_OFF_log_listview.Name = "ON_OFF_log_listview";
            this.ON_OFF_log_listview.Size = new System.Drawing.Size(366, 162);
            this.ON_OFF_log_listview.TabIndex = 31;
            this.ON_OFF_log_listview.UseCompatibleStateImageBehavior = false;
            this.ON_OFF_log_listview.View = System.Windows.Forms.View.Details;
            // 
            // UserID
            // 
            this.UserID.Text = "UserID";
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
            // Control_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.ON_OFF_log_listview);
            this.Controls.Add(this.Disconnect_Btn);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.OFF_btn);
            this.Controls.Add(this.On_Btn);
            this.Name = "Control_UC";
            this.Size = new System.Drawing.Size(811, 558);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button On_Btn;
        public System.Windows.Forms.Button OFF_btn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        public System.Windows.Forms.Button Disconnect_Btn;
        private System.Windows.Forms.ListView ON_OFF_log_listview;
        private System.Windows.Forms.ColumnHeader UserID;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Status;
    }
}
