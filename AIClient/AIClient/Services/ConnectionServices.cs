using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AIClient.Services
{
    public static class ConnectionServices
    {
        public static readonly Socket ClientSocket = new Socket
                    (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static string resond_from_server = "Empty";

        private static readonly int PORT = 27000;

        public static async void Set_up_Connection()
        {
            await ConnectToServerAsync();
        }

        private static async Task ConnectToServerAsync()
        {
            int attempts = 0;
            try
            {
                attempts++;
                //Console.WriteLine("Connection attempt " + attempts);
                // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                await ClientSocket.ConnectAsync(IPAddress.Parse("172.29.48.1"), PORT);
                Socket ClientSocke1 = ClientSocket;
                await Application.Current.MainPage.DisplayAlert("Notification", "Pass To this", "OK.");
            }
            catch (SocketException)
            {
                await Task.Delay(1000);
            }

            await Application.Current.MainPage.DisplayAlert("Notification", "OutWhileLoop", "OK.");
        }
    
}
}
