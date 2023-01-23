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
    public partial class Sign_Up_Form : Form
    {
        public Sign_Up_Form()
        {
            InitializeComponent();
        }

        private void Sign_Up_btn_Click(object sender, EventArgs e)
        {
            string usernname = Username_txtbox.Text;
            string password = Password_txtbox.Text;
            string email = Email_txtbox.Text;
            Server_SignUp.Sign_Up(usernname,password,email);
        }

        private void Username_txtbox_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Username_txtbox.ForeColor = Color.White;

                //else { Username_txtbox.ForeColor = Color.Gray; Username_txtbox.Text = "Username"; }
            }
            catch { }
        }

        private void Password_txtbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Password_txtbox.PasswordChar = '*';
                Password_txtbox.ForeColor = Color.White;
            }
            catch { }
        }

        private void Email_txtbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Email_txtbox.ForeColor = Color.White;
            }
            catch { }
        }

        private void Username_txtbox_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (Username_txtbox.Text == "Username")
                {
                    Username_txtbox.Clear();
                }
                else if (Username_txtbox.Text.Length == 0) { Username_txtbox.ForeColor = Color.Gray; Username_txtbox.Text = "Username"; }
            }
            catch { }
        }

        private void Password_txtbox_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (Password_txtbox.Text == "Password")
                {
                    Password_txtbox.Clear();
                }
                else if (Password_txtbox.Text.Length == 0) { Password_txtbox.ForeColor = Color.Gray; Password_txtbox.PasswordChar = '\0'; ; Password_txtbox.Text = "Password"; }
            }
            catch { }
        }

        private void Email_txtbox_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (Email_txtbox.Text == "Email")
                {
                    Email_txtbox.Clear();
                }
                else if (Email_txtbox.Text.Length == 0) { Email_txtbox.ForeColor = Color.Gray; Email_txtbox.Text = "Email"; }
            }
            catch { }
        }
    }
}
