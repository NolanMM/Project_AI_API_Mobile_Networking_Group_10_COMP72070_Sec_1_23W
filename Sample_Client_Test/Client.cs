using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Data;

namespace MultiClient
{
    public static class Client
    {
        public static readonly Socket ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static string resond_from_server = "Empty";

        private const int PORT = 100;

        private static void Main()
        {
            Console.Title = "Client";
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
        public static void Exit()
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
                        //Main_Menu_Client.main_menu_client();
                        Flag = false;
                        break;

                    case "2":
                        string respond_message = Clients_Services.Sing_Up_Clients();
                        Console.WriteLine();
                        Console.WriteLine(respond_message);
                        ReceiveResponse();
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
        //public static string resond_from_server = "Empty";
        private static string ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return "Empty";
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            resond_from_server = text;
            Console.WriteLine(text);
            // The respond from server for login have 2 format
            // Format 1: LoginSuccessful-key-[Client_Infor] and Client_ Infor = Username-Password-Email
            // Format 2: LoginFailed-Please check your username or password again

            // Using string split to take items from package
            // Items_in_respond[0] = LoginSuccessful / LoginFailed
            // Items_in_respond[1] = key(UserID) / Please check your username or password again
            // Items_in_respond[2] = Client_Infor ( encypted data )
            string[] Items_in_respond = resond_from_server.Split('-');

            if (Items_in_respond[0] == "LoginSuccessful")
            {
                // decrypted to take the information of client with key from Items_in_respond[1]
                string public_key = Items_in_respond[1].Substring(0, 8);
                string secret_key = Items_in_respond[1].Substring(8, 8);

                // The decypted_data will be one of format below:
                // Format 1: Login-Username-Password-Email
                string decrypted_data = Encryption_.Decrypt(Items_in_respond[2], public_key, secret_key);

                // string Items_in_respond[1] = UserID (Clients_LoginSuccessful)
                // string Items_After_Decypted[0] = username (Clients_LoginSuccessful)
                // string Items_After_Decypted[1] = password (Clients_LoginSuccessful)
                // string Items_After_Decypted[2] = email (Clients_LoginSuccessful)
                string[] Items_After_Decypted = decrypted_data.Split('-');

                // Assign the information of client that login successful to class
                Clients_infor clients_Infor = new Clients_infor();
                clients_Infor.UserID = Items_in_respond[1];
                clients_Infor.Username = Items_After_Decypted[0];
                clients_Infor.Password = Items_After_Decypted[1];
                clients_Infor.Email = Items_After_Decypted[2];

                // Route to the main menu of client and transfer the data of client 
                Main_Menu_Client._menu_client(clients_Infor);
            }
            else
            {
                // Print out "Please check your username or password again"
                Console.WriteLine(Items_in_respond[1]);
            }
            return text;
        }
    }
}