using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static server.server_connection;

namespace server
{
    public partial class Server_Menu_Form : Form
    {
        public Server_Menu_Form()
        {
            InitializeComponent();
        }

        private void addUC(UserControl uc)
        {
            UC_Control_Panel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            UC_Control_Panel.Controls.Clear();
            UC_Control_Panel.Controls.Add(uc);
        }

        private void movesidepanel_Show(Button btn)
        {
            Side_Panel_Run.Top = btn.Top;
            Side_Panel_Run.Height = btn.Height;
        }

        private void Server_Menu_Form_Load(object sender, EventArgs e)
        {
            //Welcome_Back_Menu_UC temp = new Welcome_Back_Menu_UC();
            //addUC(temp);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Current_Time_Label_Change.Visible = true;
            Current_Time_Label_Change.Text = DateTime.Now.ToLongTimeString();
        }

        private void Main_Control_Btn_Click(object sender, EventArgs e)
        {
            movesidepanel_Show(Main_Control_Btn);
        }

        private void Event_Log_Btn_Click(object sender, EventArgs e)
        {
            movesidepanel_Show(Event_Log_Btn);
        }

        private void Register_New_Member_btn_Click(object sender, EventArgs e)
        {
            movesidepanel_Show(Register_New_Member_btn);
        }

        private void OFF_btn_Click(object sender, EventArgs e)
        {
            server_connection.CloseAllSockets();
        }
            List<Active_Clients> active_Clients1 = new List<Active_Clients>();

        public async void On_Btn_Click(object sender, EventArgs e)
        {
            active_Clients1 = await server_connection.SetupServer();

        }

        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            Connection_ID_Online_Listview.Items.Clear();
            active_Clients1 = server_connection.clientSockets_active;

            foreach (Active_Clients temp in active_Clients1)
            {
                string[] _Item = new string[2];
                _Item[0] = temp.Username;
                _Item[1] = "Connected";

                ListViewItem items = new ListViewItem(_Item);
                Connection_ID_Online_Listview.Items.Add(items);
            }
        }
    }
}