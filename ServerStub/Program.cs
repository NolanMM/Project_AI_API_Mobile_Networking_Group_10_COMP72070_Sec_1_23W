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

                    // Split to take the Datapacket part and the data part
                    string[] Items = data.Split("-");
                    // client send we have format source>Destination>DataLength
                    DataPacket Received_Datapacket = new DataPacket(Items[0]);

                    string public_key = Received_Datapacket.source;
                    int Datalength;
                    bool success = int.TryParse(Received_Datapacket.DataLength, out Datalength);
                    //Take the exactly amount bytes for data be encypted
                    string data_encypted_received = Items[1].Substring(0, Datalength);

                    string decrypted_data = Sercurity.Decrypt(data_encypted_received, public_key);
                    Console.WriteLine("Data after decrypted: " + decrypted_data);

                    string final_respond = "Declined";
                    // Data after decypted stub format like request_type-Username-Password
                    string[] Items_After_Derypted = decrypted_data.Split("-");

                    if (Items_After_Derypted[0] == "Login" && Items_After_Derypted.Length == 3)
                    {
                        if (Items_After_Derypted[1] == "Nguyen" && Items_After_Derypted[2] == "Minh")
                        {
                            string respondSucess = "LoginSuccessfully";
                            string send_infor_string = Sercurity.Encrypt(respondSucess, public_key);
                            DataPacket dataheader = new DataPacket(send_infor_string, public_key);
                            final_respond = dataheader.DataPacketToString() + "-" + send_infor_string;
                        }
                    }else if(Items_After_Derypted[0] == "SignUp" && Items_After_Derypted.Length == 4)
                        {
                        string respondSucess = "SignUpSuccessfully";
                        string send_infor_string = Sercurity.Encrypt(respondSucess, public_key);
                        DataPacket dataheader = new DataPacket(send_infor_string, public_key);
                        final_respond = dataheader.DataPacketToString() + "-" + send_infor_string;
                    }
                    byte[] bytes_data = Encoding.ASCII.GetBytes(final_respond);
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