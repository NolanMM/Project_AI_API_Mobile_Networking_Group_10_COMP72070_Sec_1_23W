using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static server.ExcelApiTest;

namespace server
{
    public partial class Forgot_Password : Form
    {
        int seconds;
        public Forgot_Password()
        {
            InitializeComponent();
        }

        string OTP_CODE_PUBLIC = "Empty";
        private void Sent_btn_Click(object sender, EventArgs e)
        {
            seconds = Convert.ToInt32("180");
            Timer_Sent.Start();
            Sent_btn.Visible = false;

            string username = Username_txtbox.Text;

            string[] Items = ExcelApiTest.Take_Information_By_Username(username);
            if(Items != null)
            {
                // Hide the message show incorrect username
                incorrect_message_username.Visible = false;
                // Assign email to the variable return by the usernname search
                string email = Items[2];
                // Assign the OTP code to the variable return from the GetUniqueKey Functions
                OTP_CODE_PUBLIC = Encryption_.GetUniqueKey(8);
                // Sent through the email found in system with the uniqueKey
                OTP_module.Send_OTP_Code(OTP_CODE_PUBLIC, email);
            }
            else
            {
                incorrect_message_username.Visible = true;
            }
        }

        private void Timer_Sent_Tick(object sender, EventArgs e)
        {
            Timer_Sent_Label.Visible = true;
            Timer_Sent_Label.Text = seconds--.ToString();
            if (seconds == 0)
            {
                Timer_Sent.Stop();
                Timer_Sent_Label.Visible = false;
                Sent_btn.Visible = true;
            }
        }

        private void Confirm_btn_Click(object sender, EventArgs e)
        {
            string new_password = Password_txtbox.Text;
            string confirm_password = Confirm_password_txtbox.Text;

            // If flag = true, confirmation new password successful
            bool Flag_password = false;

            if(new_password == confirm_password) { Wrong_Confirm_lable.Visible = false; Flag_password = true; }
            else { Wrong_Confirm_lable.Visible = true; Flag_password = false; }

            string OTP_Input = OTP_Input_txtbox.Text;
            // If flag = true, confirmation OTP code sent successful
            bool Flag_OTP_Code = false;

            if(OTP_Input == OTP_CODE_PUBLIC) { incorrect_message_OTP.Visible = false; Flag_OTP_Code = true; }
            else { incorrect_message_OTP.Visible = true; Flag_OTP_Code = false; }

            // Check if the user input in 180 second to confirm the otp code else it will be expried
            if(Flag_password == Flag_OTP_Code == true && seconds > 0)
            {
                // Rewrite the new information to the excel file
                MessageBox.Show("Change password Successfully", "Alert");
            }
            else { MessageBox.Show("Change password Failed", "Warning"); }
        }
    }
}
