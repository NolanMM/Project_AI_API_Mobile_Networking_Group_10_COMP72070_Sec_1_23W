using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static server.ExcelApiTest;

namespace server
{
    public static class server_connection
    {
        
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static readonly List<Socket> clientSockets = new List<Socket>();
        private const int BUFFER_SIZE = 2048;
        private const int PORT = 100;
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];

        // Create clients socket that active with string authorized-information of clients
        public static  List<Active_Clients> clientSockets_active = new List<Active_Clients>();

        public class Active_Clients
        {
            public Socket Currently_Active_Client_Socket { get; set; }
            public string UserID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }

        ////static void Main()
        ////{
        //    Console.Title = "Server";
        //    SetupServer();
        //    Console.ReadLine(); // When we press enter close everything
        //    CloseAllSockets();
        //}

        public static List<Active_Clients> SetupServer()
        {
            if (serverSocket != null)
            {
                serverSocket.Close();
            }
            Socket temp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            temp.Bind(new IPEndPoint(IPAddress.Any, PORT));
            temp.Listen(0);
            temp.BeginAccept(AcceptCallback, null);
            serverSocket = temp;
            return clientSockets_active;
        }

        /// Close all connected client (we do not need to shutdown the server socket as its connections
        /// are already closed with the clients).
        public static void CloseAllSockets()
        {
            try
            {
                foreach (Socket socket in clientSockets)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }

                serverSocket.Close();
            }
            catch(ObjectDisposedException)
            {
                serverSocket.Close();
                return;
            }
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;
            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }

            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            //Client connected, waiting for request...
            serverSocket.BeginAccept(AcceptCallback, null);
        }
        static bool IsSocketConnected(Socket s)
        {
            //return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);

            /* Logic inside */
            try
            {
                bool part1 = s.Poll(1000, SelectMode.SelectRead);
                bool part2 = (s.Available == 0);
                if ((part1 && part2) || !s.Connected)
                    return false;
                else
                    return true;
            }catch(ObjectDisposedException e)
            {
                return false;
            }

        }
        private static void ReceiveCallback(IAsyncResult AR)
        {
            string respond = "Empty";
            Socket current = (Socket)AR.AsyncState;

            bool flag = IsSocketConnected(current);
            if (flag != true)
            {
                return ;
            }
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                current.Close();
                clientSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            if (text.ToLower() == "disconnected")
            {
                foreach (Active_Clients temp in clientSockets_active.ToList())
                {
                    if(temp.Currently_Active_Client_Socket == current)
                    {
                        clientSockets_active.Remove(temp);
                    }
                }
                // Always Shutdown before closing
                current.Shutdown(SocketShutdown.Both);
                current.Close();
                clientSockets.Remove(current);
                Console.WriteLine("Client disconnected");
                return;
            }
            // Text equal to encypted data receive from User First check for the Login then check for the Prompt

            // Sample String First Time Login From User
            // Hashingcode ( [16 first chars is the key]-[Encypted_data]

            // String Split to take the UniqueKey for decyption the message from Clients
            string[] Items = text.Split('-');
            // string Items[0] = Key
            // string Items[1] = Message_From_Clients
            string public_key = Items[0].Substring(0, 8);
            string secret_key = Items[0].Substring(8, 8);

            string decrypted_data = Encryption_.Decrypt(Items[1], public_key, secret_key);

            // The decypted_data will be one of format below:
            /* Format 1: Login-Username-Password
             * Format 2: Register-Username-Password-Email
             * Format 3: Forgotpassword-Username
             * Format 4: RequestPrompt-Username-PromptContent
             * Format 5: Disconnect-Username-Password
             */

            // Using string split and take the first items to get the type of request
            // string Items_After_Decypted[0] = Login/Register/Forgotpassword/RequestPrompt
            // string Items_After_Decypted[1] = Username
            // string Items_After_Decypted[2] = Password (format 1,2)/ PromptContent (format 4)
            // string Items_After_Decypted[3] = Email (format 2)
            string[] Items_After_Decypted = decrypted_data.Split('-');

            // Then route the program to function due to the request

            //Function 1: Login
            /* If [Encypted-data] -> decypted = "Login-Username-Password";
             * The program will route the program to bool login_Client_Function (string username, string password)
             *
             * If return true, program will add the socket of user to the list and append to the runtime generate list has item has 2 attribute are: Socket-UserID - Authorization( Verified/ Unverified)
             * When ever receive a request prompt from user server just respond to the prompt that come from verified client UserID and Correct Socket link with that userID current time
             * If return "LoginFailed", server will sent respond Unauthorization to Clients side for ask for Login again
             *
             * string Items_After_Decypted[0] = Login
             * string Items_After_Decypted[1] = Username
             * string Items_After_Decypted[2] = Password
             *
             *//////////////////
            if (Items_After_Decypted.Length == 3 && Items_After_Decypted[0] == "Login")
            {
                // Route to function 1
                //
                // Format of Respond_From_Functions are
                // Format 1: LoginSuccessful-UserID-Username-Password-Emails
                // Format 2: LoginFailed-
                //
                //////////////////////////////////
                string respond_From_Functions = Clients_Login.Function_Excel_Login_Clients(Items_After_Decypted[1], Items_After_Decypted[2]);

                string[] Items_in_respond = respond_From_Functions.Split('-');

                if (Items_in_respond[0] == "LoginSuccessful")
                {
                    // Format 1
                    // string Items_in_respond[0] = LoginSuccessful
                    // string Items_in_respond[1] = UserID (Clients_LoginSuccessful)
                    // string Items_in_respond[2] = username (Clients_LoginSuccessful)
                    // string Items_in_respond[3] = password (Clients_LoginSuccessful)
                    // string Items_in_respond[4] = email (Clients_LoginSuccessful)

                    // Assign to the class object to store inside the functions
                    Active_Clients active_Clients_SignUpSuccessfully = new Active_Clients();
                    active_Clients_SignUpSuccessfully.UserID = Items_in_respond[1];
                    active_Clients_SignUpSuccessfully.Username = Items_in_respond[2];
                    active_Clients_SignUpSuccessfully.Password = Items_in_respond[3];
                    active_Clients_SignUpSuccessfully.Email = Items_in_respond[4];
                    active_Clients_SignUpSuccessfully.Currently_Active_Client_Socket = current;

                    // Add information of active clients to the list
                    clientSockets_active.Add(active_Clients_SignUpSuccessfully);

                    // Encypted the respond to the Client side
                    string final_respond = Encryption_.Quick_Encypted_Account_by_Using_Hashing_Key_By_Username(active_Clients_SignUpSuccessfully.Username,
                        active_Clients_SignUpSuccessfully.Password, active_Clients_SignUpSuccessfully.Email);

                    string key = active_Clients_SignUpSuccessfully.UserID;
                    // Modify the respond that actually be sent
                    respond = "LoginSuccessful" + "-" + key + "-" + final_respond;
                    byte[] data = Encoding.ASCII.GetBytes(respond);
                    current.Send(data);
                }
                else
                {
                    respond = "LoginFailed-Please check your username or password again";
                    byte[] data = Encoding.ASCII.GetBytes(respond);
                    current.Send(data);
                }
            }

            //Function 2: Register
            /* If [Encypted-data] -> decypted = "Register-Username-Password-Email";
             * The program will route the program to bool signup_Client_Function (string username, string password,string email)
             *
             * If return true, program will Respond Successfull Register and link the socket with that new UserID
             * Server will respond "SignUpSuccessfully" like signals to clients side login to the main menu clients
             * If return false, server will sent respond "SignUpFailed" to Clients side for ask for enter another username that valid
             *
             *//////////////////
            if (Items_After_Decypted.Length == 4) // Register
            {
                bool Flag = Clients_SignUp.Check_If_Duplicate_Username_Clients(Items_After_Decypted[1]);

                // Route to function 2 and Assign the respond back to clients
                string respond_From_Function = Clients_SignUp.Sign_Up_Clients(Items_After_Decypted[1], Items_After_Decypted[2], Items_After_Decypted[3]);
                // Assign sockets to the list that currently active authorized
                string[] Items_in_respond = respond_From_Function.Split('-');
                // string Items_in_respond[0] = SignUpSuccessfully/SignUpFailed (Signal to route program)
                // string Items_in_respond[1] = UserID (Clients_SignUpSuccessfully)
                // string Items_in_respond[2] = username (Clients_SignUpSuccessfully)
                // string Items_in_respond[3] = password (Clients_SignUpSuccessfully)
                // string Items_in_respond[4] = email (Clients_SignUpSuccessfully)
                if (Items_in_respond[0] == "SignUpSuccessfully")
                {
                    // Assign to the class object to store inside the functions
                    Active_Clients active_Clients_SignUpSuccessfully = new Active_Clients();
                    active_Clients_SignUpSuccessfully.UserID = Items_in_respond[1];
                    active_Clients_SignUpSuccessfully.Username = Items_in_respond[2];
                    active_Clients_SignUpSuccessfully.Password = Items_in_respond[3];
                    active_Clients_SignUpSuccessfully.Email = Items_in_respond[4];
                    active_Clients_SignUpSuccessfully.Currently_Active_Client_Socket = current;

                    // Add information of active clients to the list
                    clientSockets_active.Add(active_Clients_SignUpSuccessfully);

                    // Encypted the respond to the Client side
                    string final_respond = Encryption_.Quick_Encypted_Account_by_Using_Hashing_Key_By_Username(active_Clients_SignUpSuccessfully.Username,
                        active_Clients_SignUpSuccessfully.Password, active_Clients_SignUpSuccessfully.Email);

                    string key = active_Clients_SignUpSuccessfully.UserID;
                    // Modify the respond that actually be sent
                    respond = "SignUpSuccessfully" + "-" + key + "-" + final_respond;
                    byte[] data_test = Encoding.ASCII.GetBytes(respond);
                    current.Send(data_test);
                }
                // Check if SignUpFailed because of duplicate username or not to send SignUp Failed respond to the clients
                else if (Items_in_respond[0] == "SignUpFailed" && Flag == true)
                {
                    respond = "SignUpFailed-Duplicate Username";
                    byte[] data_test = Encoding.ASCII.GetBytes(respond);
                    current.Send(data_test);
                }
                else if (Items_in_respond[0] == "SignUpFailed" && Flag == false)
                {
                    respond = "SignUpFailed-";
                    byte[] data_test = Encoding.ASCII.GetBytes(respond);
                    current.Send(data_test);
                }
            }

            //Function 3: Forgot Password
            /* [Encypted-data] -> decypted = "Forgotpassword-Username"
             * The program will route the program to bool Forgotpassword_Clients(string username) to find the email that link with that username and send otp code to Clients side and wait for respond from that socket
             *
             * The server will receive data be encypted from that socket containts (username-NewPassword-OTPCode)
             * The server will check for the OTP code if it match -> server send respond "ChangepasswordSuccessfully" to clients side for signal to ask for login again by new password
             *
             * If return false, server will sent respond "VerifiedOTPFailed" to Clients side for ask for asking re-sent OTP code and input again
             *
             *//////////////////
            //if (Items_After_Decypted.Length == 2)
            //{
            //    // Route to function 3
            //}

            //Function 4: RequestPrompt
            /* [Encypted-data] -> decypted = "RequestPrompt-Username-PromptContent"
             * The program will route the program to bool Check if that username in the current connected socket that been verified and safe through runtime or not
             *
             * If true, The Server will take the prompt and sent through API AI to take the respond from AI API
             * After take respond back from AI API,
             * Then server will take string respond = "PromptRespond" + "Prompt_Content" hashing to generate Unique ID request
             * Then take first 16 chars from the hashing code to generate the key to Encypted data string encypted = "PromptRespond" + '-' + "Respond_Content";
             * server send the respond back to the socket that link to that clients in the list enrypted data string
             *
             *
             *//////////////////

            if (Items_After_Decypted.Length == 3 && Items_After_Decypted[0] == "Text_to_Text")
            {
                // Route to function 4

                bool flag_Check_Authorized = false;
                // Check if that client has been authorized or not
                foreach (Active_Clients temp in clientSockets_active.ToList())
                {
                    if (temp.UserID == Items[0])
                    {
                        flag_Check_Authorized = true;
                    }
                }

                if ( flag_Check_Authorized == true)
                {
                    // Items_After_Decypted[1] = Username
                    // Items_After_Decypted[2] = Prompt input

                    // Take the prompt input and put into AI to take respond
                    string response_from_AI = AI_API.callOpenAIText(Items_After_Decypted[2]);

                    string UserID = Encryption_.ComputeSha256Hash(Items_After_Decypted[1]);


                    string raw_data_be_encrypted = Items_After_Decypted[2] + "-" + response_from_AI;

                    // Encypted the final_string (User data) by the key
                    string send_infor_string = Encryption_.Encrypt(raw_data_be_encrypted, public_key, secret_key);

                    respond = UserID + "-" + send_infor_string;
                    byte[] data = Encoding.ASCII.GetBytes(respond);
                    current.Send(data);

                    current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);

                }
                else
                {
                    return;
                }
            }

            //byte[] data = Encoding.ASCII.GetBytes(respond);
            //current.Send(data);
            Console.WriteLine("Respond sent");
            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }

        private static void CloseSpecificSockets(Socket socket)
        {
            foreach (Socket items_In_List in clientSockets)
            {
                if (items_In_List == socket)
                {
                    items_In_List.Shutdown(SocketShutdown.Both);
                    items_In_List.Close();
                    // Remove from list Connection
                    clientSockets.Remove((Socket)items_In_List);
                }
            }
        }
    }
}