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
            //string test = "Hello to server";
            //string Hash = SecurityServices.ComputeSha256Hash(test);
            //string public_key = Hash.Substring(0, 8);
            //string final_string = Hash + "*&*&*" + SecurityServices.Encrypt(test,public_key) + "*&*&*";
            //byte[] bytes_data = Encoding.ASCII.GetBytes(final_string);
            //await SendReceiveProcess(bytes_data);
        }

        private static async Task ConnectToServerAsync()
        {
            int attempts = 0;
            bool flag = false;
            while (flag == false)
            {
                try
                {
                    attempts++;
                    await ClientSocket.ConnectAsync(IPAddress.Parse("172.29.48.1"), PORT);
                    Connection = new NetworkStream(ClientSocket);
                    flag = true;
                }
                catch (SocketException e)
                {
                    await Application.Current.MainPage.DisplayAlert("Notification", e.ToString(), "OK.");
                }
            }
        }

        public static async Task<String> SendReceiveProcess(byte[] data)
        {
            sendData(data);
            string receive = await Receiving();
            //await Application.Current.MainPage.DisplayAlert("Notification", "Successful received data: " + receive, "OK.");
            return receive;
        }

        public static async Task<String> SendReceiveImageProcess(byte[] data)
        {
            SendImage(data);
            string receive = await Receiving();
            //await Application.Current.MainPage.DisplayAlert("Notification", "Successful received data: " + receive, "OK.");
            return receive;
        }
        public static async void SendImage(byte[] data)
        {
            ClientSocket.SendBufferSize = 100*1024*1024;
            if (Connection.CanWrite)
            {
                Connection.Write(data, 0, data.Length);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "Sorry.  You cannot write to this NetworkStream.", "OK.");
            }
        }
        public static async void sendData(byte[] data)
        {
            if(Connection.CanWrite)
            {
                Connection.Write(data, 0, data.Length);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "Sorry.  You cannot write to this NetworkStream.", "OK.");
            }
        }
        public static async Task<string> Receiving()
        {
            if(Connection.CanRead)
            {
                try
                {
                    const int bytesize = 1024 * 1024;
                    byte[] buffer = new byte[bytesize];
                    string x = Connection.Read(buffer, 0, bytesize).ToString();
                    string data = ASCIIEncoding.ASCII.GetString(buffer);
                    return data;
                }
                catch (Exception exc)
                {
                    await Application.Current.MainPage.DisplayAlert("Notification", exc.ToString(), "OK.");
                    return null;
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "Sorry.  You cannot read from this NetworkStream.", "OK.");
                return null;
            }
        }

    }
}
