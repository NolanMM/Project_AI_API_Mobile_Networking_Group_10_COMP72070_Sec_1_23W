using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MultiServer
{
    class Program
    {
        public static TcpClient client;
        private static TcpListener listener;
        private static string ipString;
        private static NetworkStream ConnectedClient;

        // Main Method
        static public void Main(String[] args)
        {

            returnIP();
            Accept();
            Receiving();
            Console.WriteLine(0);
        }

        public static void returnIP()
        {
            IPAddress[] localIp = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIp)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipString = address.ToString();
                }
            }
        }

        public static void Accept()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipString), 27000);
            listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine(@"    
            ===================================================    
                   Started listening requests at: {0}:{1}    
            ===================================================",
            ep.Address, ep.Port);
            client = listener.AcceptTcpClient();
            ConnectedClient = client.GetStream();
            Console.WriteLine("Connected to client!" + " \n");
        }
        public static void Receiving()
        {
            while (client.Connected)
            {
                try
                {
                    const int bytesize = 1024 * 1024;
                    byte[] buffer = new byte[bytesize];
                    string x = ConnectedClient.Read(buffer, 0, bytesize).ToString();
                    string data = Encoding.ASCII.GetString(buffer);
                    Console.WriteLine("Data before decrypted: " + data);
                    string[] Items = data.Split("*&*&*");
                    string public_key = Items[0].Substring(0, 8);
                    string decrypted_data = Sercurity.Decrypt(Items[1], public_key);
                    Console.WriteLine("Data after decrypted: " + decrypted_data);
                    string test = "Recieved";
                    byte[] bytes_data = Encoding.ASCII.GetBytes(test);
                    sendRespond(bytes_data);
                }
                catch (Exception exc)
                {
                    client.Dispose();
                    client.Close();
                }
            }
        }
        public static void sendRespond(byte[] data)
        {
            if (ConnectedClient.CanWrite)
            {
                ConnectedClient.Write(data, 0, data.Length);
            }
            else
            {
                Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");
            }
        }
    }
}