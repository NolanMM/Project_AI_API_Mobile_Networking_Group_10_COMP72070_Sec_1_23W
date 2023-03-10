using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MultiClient
{
    public static class Client
    {
        private static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private const int PORT = 100;

        private static void Main()
        {
            Console.Title = "Client_2";
            ConnectToServer();
            RequestLoop();
            Exit();
        }

        private static void ConnectToServer()
        {
            int attempts = 0;

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts);
                    // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                    ClientSocket.Connect(IPAddress.Loopback, PORT);
                }
                catch (SocketException)
                {
                    Console.Clear();
                }
            }

            Console.Clear();
            Console.WriteLine("Connected");
        }

        private static void RequestLoop()
        {
            Console.WriteLine(@"<Type ""exit"" to properly disconnect client>");

            while (true)
            {
                SendRequest();
                ReceiveResponse();
                Console.WriteLine("Respond from server: " + resond_from_server);
            }
        }

        /// <summary>
        /// Close socket and exit program.
        /// </summary>
        private static void Exit()
        {
            SendString("exit"); // Tell the server we are exiting
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }

        private static void SendRequest()
        {
            bool Flag = true;
            while (Flag)
            {
                Console.WriteLine("Please Enter the mode you want to\n");
                Console.WriteLine("1. Sign In\n");
                Console.WriteLine("2. Sign Up\n");
                Console.WriteLine("3. Disconnect\n");
                Console.WriteLine("4. Exit\n");

                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "1":
                        string respond_message_sign_in = Clients_Services.Sign_In_Client();
                        Console.WriteLine();
                        Console.WriteLine(respond_message_sign_in);
                        Flag = false;
                        break;

                    case "2":
                        string respond_message = Clients_Services.Sing_Up_Clients();
                        Console.WriteLine();
                        Console.WriteLine(respond_message);
                        Flag = false;
                        break;

                    case "3":
                        break;

                    case "Disconnect":
                        break;

                    case "4":
                        string respond_message_disconnect = "disconnected";
                        SendString(respond_message_disconnect);
                        Exit();
                        break;

                    case "exit":
                        Exit();
                        break;

                    case "sign in":
                        break;

                    case "sign up":
                        break;

                    default:
                        Console.WriteLine("Wrong input. Please input again\n");
                        break;
                }
            }
        }

        /// <summary>
        /// Sends a string to the server with ASCII encoding.
        /// </summary>
        public static void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public static string resond_from_server = "Empty";

        private static void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            resond_from_server = text;
            Console.WriteLine(text);
        }
    }
}