using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static server.ExcelApiTest;

namespace server
{
    public static class server_connection
    {
        private static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static readonly List<Socket> clientSockets = new List<Socket>();
        private const int BUFFER_SIZE = 2048;
        private const int PORT = 100;
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];

        // Create clients socket that active with string authorized-information of clients
        private static readonly List<Active_Clients> clientSockets_active = new List<Active_Clients>();

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

        private static void SetupServer()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        /// Close all connected client (we do not need to shutdown the server socket as its connections
        /// are already closed with the clients).
        private static void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSocket.Close();
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

        private static void ReceiveCallback(IAsyncResult AR)
        {
            string respond = "Empty";
            Socket current = (Socket)AR.AsyncState;
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
             */

            // Using string split and take the first items to get the type of request
            string[] Items_After_Decypted = decrypted_data.Split('-');


            // Then route the program to function due to the request


            //Function 1: Login
            /* If [Encypted-data] -> decypted = "Login-Username-Password";
             * The program will route the program to bool login_Client_Function (string username, string password)
             * 
             * If return true, program will add the socket of user to the list and append to the runtime generate list has item has 2 attribute are: Socket-UserID - Authorization( Verified/ Unverified)
             * When ever receive a request prompt from user server just respond to the prompt that come from verified client UserID and Correct Socket link with that userID current time
             * If return false, server will sent respond Unauthorization to Clients side for ask for Login again
             *
             *//////////////////
            if (Items_After_Decypted.Length == 3 && Items_After_Decypted[0] == "Login")
            {
                // Route to function 1
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
                    Active_Clients active_Clients_SignUpSuccessfully = new Active_Clients();
                    active_Clients_SignUpSuccessfully.UserID = Items_in_respond[1];
                    active_Clients_SignUpSuccessfully.Username = Items_in_respond[2];
                    active_Clients_SignUpSuccessfully.Password = Items_in_respond[3];
                    active_Clients_SignUpSuccessfully.Email = Items_in_respond[4];
                    active_Clients_SignUpSuccessfully.Currently_Active_Client_Socket = current;

                    // Add information of active clients to the list
                    clientSockets_active.Add(active_Clients_SignUpSuccessfully);

                    string final_respond = Encryption_.Quick_Encypted_Account_by_Using_Hashing_Key_By_Username(active_Clients_SignUpSuccessfully.Username, 
                        active_Clients_SignUpSuccessfully.Password, active_Clients_SignUpSuccessfully.Email);
                    respond = "SignUpSuccessfully" + "-" + final_respond;
                }
                else
                {
                    respond = "SignUpFailed";
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
            if (Items_After_Decypted.Length == 2)
            {
                // Route to function 3
            }

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

            if (Items_After_Decypted.Length == 3 && Items_After_Decypted[0] == "RequestPrompt")
            {
                // Route to function 4
            }

            byte[] data = Encoding.ASCII.GetBytes(respond);
            current.Send(data);
            Console.WriteLine("Respond sent");
            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }

        private static void CloseSpecificSockets(Socket socket)
        {
            foreach (Socket items_In_List in clientSockets)
            {
                if(items_In_List == socket)
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