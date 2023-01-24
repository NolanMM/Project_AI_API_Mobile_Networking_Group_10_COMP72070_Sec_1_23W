namespace server
{
    partial class Welcome_Back_Menu_UC
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
            this.Welcomeback_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Welcomeback_Label
            // 
            this.Welcomeback_Label.AutoSize = true;
            this.Welcomeback_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Welcomeback_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Welcomeback_Label.Font = new System.Drawing.Font("Cooper Black", 32.25F, System.Drawing.FontStyle.Bold);
            this.Welcomeback_Label.ForeColor = System.Drawing.Color.White;
            this.Welcomeback_Label.Location = new System.Drawing.Point(119, 248);
            this.Welcomeback_Label.Name = "Welcomeback_Label";
            this.Welcomeback_Label.Size = new System.Drawing.Size(589, 51);
            this.Welcomeback_Label.TabIndex = 1;
            this.Welcomeback_Label.Text = "Welcome Back To Server";
            // 
            // Welcome_Back_Menu_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.Welcomeback_Label);
            this.Name = "Welcome_Back_Menu_UC";
            this.Size = new System.Drawing.Size(811, 558);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Welcomeback_Label;
    }
}
