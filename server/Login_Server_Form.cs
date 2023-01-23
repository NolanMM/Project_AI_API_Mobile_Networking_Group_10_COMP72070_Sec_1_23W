using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Login_Server_Form : Form
    {
        public Login_Server_Form()
        {
            InitializeComponent();
        }

        private void Username_txtbox_TextChanged(object sender, EventArgs e)
        {
            try {

                Username_txtbox.ForeColor = Color.White;

                //else { Username_txtbox.ForeColor = Color.Gray; Username_txtbox.Text = "Username"; }
            }
            catch { }
        }

        private void Password_txtbox_TextChanged(object sender, EventArgs e)
        {
            try {
                Password_txtbox.ForeColor = Color.White;
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
                else if (Password_txtbox.Text.Length == 0) { Password_txtbox.ForeColor = Color.Gray; Password_txtbox.Text = "Password"; }
            }
            catch { }
        }
    }
}
