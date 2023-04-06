using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MultiServer
{
    class Program
    {
        public static TcpClient client;
        private static TcpListener listener;
        private static string ipString;

        // Main Method
        static public void Main(String[] args)
        {

            returnIP();
            Accept();
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
            Console.WriteLine("Connected to client!" + " \n");
        }
    }
}