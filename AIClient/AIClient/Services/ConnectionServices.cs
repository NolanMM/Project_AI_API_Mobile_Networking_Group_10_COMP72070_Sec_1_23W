using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.NetworkInformation;

namespace AIClient.Services
{
    public static class ConnectionServices
    {
        public static readonly Socket ClientSocket = new Socket
                    (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static NetworkStream Connection;

        private static readonly int PORT = 27000;

        public static async void Set_up_Connection()
        {
            await ConnectToServerAsync();
            string test = "Hello to server";
            byte[] bytes_data = Encoding.ASCII.GetBytes(test);
            sendData(bytes_data);
            Receiving();
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
                Connection = new NetworkStream(ClientSocket);
                await Application.Current.MainPage.DisplayAlert("Notification", "Pass To this", "OK.");
            }
            catch (SocketException)
            {
                await Task.Delay(1000);
            }
            await Application.Current.MainPage.DisplayAlert("Notification", "OutWhileLoop", "OK.");
        }

        public static async void sendData(byte[] data)
        {
            if (Connection.CanWrite)
            {
                Connection.Write(data, 0, data.Length);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "Sorry.  You cannot write to this NetworkStream.", "OK.");
            }
        }
        public static async void Receiving()
        {
            while (Connection.CanRead)
            {
                try
                {
                    const int bytesize = 1024 * 1024;
                    byte[] buffer = new byte[bytesize];
                    string x = Connection.Read(buffer, 0, bytesize).ToString();
                    var data = ASCIIEncoding.ASCII.GetString(buffer);
                }
                catch (Exception exc)
                {
                    await Application.Current.MainPage.DisplayAlert("Notification", "Sorry.  You cannot write to this NetworkStream.", "OK.");
                }
            }
        }

    }
}
