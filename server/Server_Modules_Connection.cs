﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static server.ExcelApiTest;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace server
{
    public static class server_connection
    {
        //Define the port number, buffer size, server and client sockets
        public static TcpClient client;
        private static TcpListener listener;
        private static string ipString;
        private static NetworkStream ConnectedClient;
        private const int bytesize = 2048 * 1024;
        private static readonly byte[] buffer = new byte[bytesize];

        // Create clients socket that active with string authorized-information of clients
        public static  List<Active_Clients> clientSockets_active = new List<Active_Clients>();

        public class Active_Clients
        {
            public NetworkStream Currently_Active_Client_Socket { get; set; }
            public string UserID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }

        public static async Task<List<Active_Clients>> SetupServer()
        {
            returnIP();
            AcceptAsync();
            return clientSockets_active;
        }

        public static async void AcceptAsync()
        {
            AsyncCallback callBack = new AsyncCallback(ReceiveCallback);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipString), 27000);
            listener = new TcpListener(ep);
            listener.Start();
            Console.WriteLine(@"    
            ===================================================    
                   Started listening requests at: {0}:{1}    
            ===================================================",
            ep.Address, ep.Port);
            client = await listener.AcceptTcpClientAsync();
            ConnectedClient = client.GetStream();
            ConnectedClient.BeginRead(buffer, 0, bytesize, callBack, buffer);
            Console.WriteLine("Connected to client!" + " \n");
        }

        // Close all connected client (we do not need to shutdown the server socket as its connections
        // are already closed with the clients).
        public static void CloseAllSockets()
        {
            listener.Stop();
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

        //This method accepts a data packet from the client and based on the provided information and commands 
        //Performs certain actions such as login, sign up, or proceed one of three prompts. 
        private static void ReceiveCallback(IAsyncResult result)
        {
            AsyncCallback callBack = new AsyncCallback(ReceiveCallback);
            byte[] buffer_received = (byte[])result.AsyncState;
            //Check if the server connecter or not. If no, then return 
            /*            if (!ConnectedClient.CanRead)
                            return;*/
            string final_response = "Empty";
            if(!ConnectedClient.CanRead)
            {
                return;
            }
            try
            {
                ConnectedClient.EndRead(result);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }


            string text = Encoding.ASCII.GetString(buffer_received);

            //Close the socket if disconnected 
            if (text.ToLower() == "disconnected")
            {
                foreach (Active_Clients temp in clientSockets_active.ToList())
                {
                    if(temp.Currently_Active_Client_Socket == ConnectedClient)
                    {
                        clientSockets_active.Remove(temp);
                    }
                }
                CloseAllSockets();
                Console.WriteLine("Client disconnected");
                return;
            }

            // Text equal to encypted data receive from User First check for the Login then check for the Prompt
            // String Split to take the UniqueKey for decyption the message from Clients
            // The first part is a key,
            // The second is the actual data,
            // The splitter is "-".
            string[] Items = text.Split('-');

			// String Items[0] = Key
			DataPacket Received_Datapacket = new DataPacket(Items[0]);
            string decrypted_data = "Empty";
            //Assign the public key
            string public_key = Received_Datapacket.source;

            //Parse the lenght of the data
			int Datalength;
			bool success = int.TryParse(Received_Datapacket.DataLength, out Datalength);

			// String Items[1] = Message_From_Clients
			string data_encypted_received = Items[1].Substring(0, Datalength);

            //Decrypt the string using the public key 
            decrypted_data = Encryption_.Decrypt(data_encypted_received, public_key);

            //Login-Minh-Nguyen
            //Print the decrypting string 

            // Best Break Point 
			Console.WriteLine("Data after decrypttion: " + decrypted_data);

			// Using string split take the first items to get the type of request
			string[] Items_After_Decypted = decrypted_data.Split('-');

            //To setup the switch case statement. This will be used to determine the option the program should perform 
            int optionNum = Items_After_Decypted.Length;
            string optionString = Items_After_Decypted[0];

			// The decypted data will be one of format below:
			/* Login-Username-Password
             * Register-Username-Password-Email
             * Forgotpassword-Username
             * Text_To_Image-Username-PromptContent
             * Disconnect-Username-Password
             * Text_To_Text-Username-PromptContent
             * Image_To_Text-Username-PromptContent
             */

			switch (optionNum)
            {
				//Case 2 handles all possible propts. There are 3 of them: 
				//"Text_To_Text" - receives a text request from user to generate a text response.
				//                 Uses GPT-3 Davinchi model developed by openAI
				//"DataHeaderImageToText" - receives a text request from user to generate an image response.
				//                 Uses GPT-3 Davinchi model developed by openAI
				//"Image_Caption" - receives an image from user to generate a caption (text response) of the image.
				//                 Uses BLIP model from LAVIS library developed by Salesforce
				//
				//LAVIS documentation URI: https://opensource.salesforce.com/LAVIS/latest/intro.html
				//GPT-3 documentation URI: https://platform.openai.com/docs/introduction
				case 2:
					//bool flag_Check_Authorized = false;

					//// Check if that client has been authorized or not
					//foreach (Active_Clients temp in clientSockets_active.ToList())
					//{
					//	if (temp.UserID == Items[0])
					//	{
					//		flag_Check_Authorized = true;
					//	}
					//}

     //               //Return if not authorized
     //               if (!flag_Check_Authorized)
     //                   return;

					// Items_After_Decypted[1] = Username
					// Items_After_Decypted[2] = Prompt input
					switch (optionString)
                    {
                        case "Text_To_Text":
							// Take the prompt input and put into AI to take respond
							string response_from_AI = AI_API.TextToText_openAI(Items_After_Decypted[1]);

							string raw_data_be_encrypted = "Text_To_TextRespond" + "*__*" + response_from_AI;

							// Encypted the final_string (User data) by the key
							string send_infor_string = Encryption_.Encrypt(raw_data_be_encrypted, public_key);

							DataPacket dataheader = new DataPacket(send_infor_string, public_key);

							final_response = dataheader.DataPacketToString() + "-" + send_infor_string;

                            //Send the packet
							byte[] data = Encoding.ASCII.GetBytes(final_response);
                            sendRespond(data);

							break;
                        case "Text_To_Image":
                            // Take the prompt input and put into AI to take respond
                            // The settings of the picture are pre-define in AI_API.cs:
                            //
                            // model = image-alpha-001
                            // number = 1
                            // size = 256x256 pixels
                            //
                            // The format of returned images is always .jpg

                            //Send the prompt [2] and the username [1]
                            //string test = AI_API.TextToImage_openAI(Items_After_Decypted[1],public_key);

                            Task<string> GenerateImage = AI_API.TextToImage_PythonUvicornServer(Items_After_Decypted[1]);
                            //response_from_AI = AI_API.TextToImage_openAI(Items_After_Decypted[1], public_key);
                            string url = GenerateImage.Result;
                            //byte[] bytes_images = AI_API.getImageFromUrl(url);
                            //string dataImagestringBase64 = Convert.ToBase64String(bytes_images);
                            //Get userID from the username

                            raw_data_be_encrypted = "TextToImageRespond" + "*__*" + url;

							// Encypted the final_string (User data) by the key
							send_infor_string = Encryption_.Encrypt(raw_data_be_encrypted, public_key);

							dataheader = new DataPacket(send_infor_string, public_key);

							final_response = dataheader.DataPacketToString() + "-" + send_infor_string;

							//Send the packet
							data = Encoding.ASCII.GetBytes(final_response);
							sendRespond(data);
							break;
                        case "DataHeaderImageToText":
							//Send the base64 image [2] to create a prompt
							response_from_AI = AI_API.ImageToText_LAVIS(Items_After_Decypted[1]);

							//Get userID from the username
							raw_data_be_encrypted = Items_After_Decypted[2] + "-" + response_from_AI;

							// Encypted the final_string (User data) by the key
							send_infor_string = Encryption_.Encrypt(raw_data_be_encrypted, public_key);

							dataheader = new DataPacket(send_infor_string, public_key);

							final_response = dataheader + "-" + send_infor_string;

							//Send the packet
							data = Encoding.ASCII.GetBytes(final_response);
							sendRespond(data);
							break;
                        default:
                            Console.WriteLine("Something went wrong: incorrect prompt type\n");
                            break;
					}
                    break;

				//Case 3: Login
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
				case 3:
                    if (optionString == "Login")
                    {
						//Send the username (Items_After_Decypted[1]) and the password (Items_After_Decypted[2])
						//To the Function_Excel_Login_Clients to check if the login data is correct or not
						string respond_From_Functions = Clients_Login.Function_Excel_Login_Clients(Items_After_Decypted[1], Items_After_Decypted[2]);

                        //Split the result using "-" to know the result the previous function
                        //If logged in successfully, then the first item will be "LoginSuccessfully"
                        //Otherwise the login failed.
						string[] Items_in_respond_Login = respond_From_Functions.Split('-');

						if (Items_in_respond_Login[0] == "LoginSuccessful")
						{
							// Format of the response:
							// string Items_in_respond[0] = LoginSuccessful
							// string Items_in_respond[1] = UserID (Clients_LoginSuccessful)
							// string Items_in_respond[2] = username (Clients_LoginSuccessful)
							// string Items_in_respond[3] = password (Clients_LoginSuccessful)
							// string Items_in_respond[4] = email (Clients_LoginSuccessful)

							Active_Clients active_Clients_SignUpSuccessfully = new Active_Clients();

							// Assign to the class object to store the data to be transmitted 
							active_Clients_SignUpSuccessfully.UserID = Items_in_respond_Login[1];
							active_Clients_SignUpSuccessfully.Username = Items_in_respond_Login[2];
							active_Clients_SignUpSuccessfully.Password = Items_in_respond_Login[3];
							active_Clients_SignUpSuccessfully.Email = Items_in_respond_Login[4];

							// Add information of active clients to the list
							clientSockets_active.Add(active_Clients_SignUpSuccessfully);

                            // Encrypt the data to create a response to be send to the Client side
                            //string resnponse = Encryption_.Quick_Encypted_Account_by_Using_Hashing_Key_By_Username(active_Clients_SignUpSuccessfully.Username,
                            //	active_Clients_SignUpSuccessfully.Password, active_Clients_SignUpSuccessfully.Email);
                            string respond_ = "LoginSuccessful-" + Items_in_respond_Login[2] + "-" + Items_in_respond_Login[3] + "-" + Items_in_respond_Login[4];
                            string DataAfterEncrypted = Encryption_.Encrypt(respond_, public_key);
                            //Define the header
                            DataPacket dataheader = new DataPacket(DataAfterEncrypted, public_key);

                            // Modify the response that actually be sent
                            string send_final_response = dataheader.DataPacketToString() + "-" + DataAfterEncrypted;

                            byte[] data = Encoding.ASCII.GetBytes(send_final_response);
                            sendRespond(data);
						}
						else
						{
							final_response = "LoginFailed-Please check your username or password again";
							byte[] data = Encoding.ASCII.GetBytes(final_response);
							sendRespond(data);
						}
					}
                    else
                    {
						Console.WriteLine("Something went wrong: incorrect prompt type\n");
					}
					break;

				//Case 4: Register
				/* If [Encypted-data] -> decypted = "Register-Username-Password-Email";
				 * The program will route the program to bool signup_Client_Function (string username, string password,string email)
				 *
				 * If return true, program will Respond Successfull Register and link the socket with that new UserID
				 * Server will respond "SignUpSuccessfully" like signals to clients side login to the main menu clients
				 * If return false, server will sent respond "SignUpFailed" to Clients side for ask for enter another username that valid
				 *
				 *//////////////////
				case 4:
					bool Flag = Clients_SignUp.Check_If_Duplicate_Username_Clients(Items_After_Decypted[1]);

					// Route to function 2 and Assign the respond back to clients
					string respond_From_Function = Clients_SignUp.Sign_Up_Clients(Items_After_Decypted[1], Items_After_Decypted[2], Items_After_Decypted[3]);

					// Assign sockets to the list that currently active authorized
					string[] Items_in_respond_register = respond_From_Function.Split('-');

                    // String format for the response:
                    // string Items_in_respond[0] = SignUpSuccessfully/SignUpFailed (Signal to route program)
                    // string Items_in_respond[1] = UserID (Clients_SignUpSuccessfully)
                    // string Items_in_respond[2] = username (Clients_SignUpSuccessfully)
                    // string Items_in_respond[3] = password (Clients_SignUpSuccessfully)
                    // string Items_in_respond[4] = email (Clients_SignUpSuccessfully)
                    switch (Items_in_respond_register[0])
                    {
                        case "SignUpSuccessfully":
							Active_Clients active_Clients_SignUpSuccessfully = new Active_Clients();

							// Assign to the class object to store inside the functions
							active_Clients_SignUpSuccessfully.UserID = Items_in_respond_register[1];
							active_Clients_SignUpSuccessfully.Username = Items_in_respond_register[2];
							active_Clients_SignUpSuccessfully.Password = Items_in_respond_register[3];
							active_Clients_SignUpSuccessfully.Email = Items_in_respond_register[4];

							// Add information of active clients to the list
							clientSockets_active.Add(active_Clients_SignUpSuccessfully);

							// Encypted the respond to the Client side
							//string DataAfterEncrypted = Encryption_.Quick_Encypted_Account_by_Using_Hashing_Key_By_Username(active_Clients_SignUpSuccessfully.Username,
							//	active_Clients_SignUpSuccessfully.Password, active_Clients_SignUpSuccessfully.Email);

							//string key = active_Clients_SignUpSuccessfully.UserID;
                            string DataAfterEncrypted = Encryption_.Encrypt(respond_From_Function, public_key);
                            //Define the header
                            DataPacket dataheader = new DataPacket(DataAfterEncrypted, public_key);

							// Modify the response that actually be sent
							string send_final_response = dataheader.DataPacketToString() + "-" + DataAfterEncrypted;

							byte[] data = Encoding.ASCII.GetBytes(send_final_response);
							sendRespond(data);
                            break;

						// Check if SignUpFailed because of duplicate username or not to send SignUp Failed respond to the clients
						case "SignUpFailed":
                            final_response = "SignUpFailed";
                            //If duplicate 
                            if (Flag == true)
                                final_response += "-Duplicate Username";

							byte[] data_test = Encoding.ASCII.GetBytes(final_response);
							sendRespond(data_test);
							break;
                        default:
                            break;
					}
					break;
                default:
                    if(optionString == "DataHeaderImageToText") { 
                        //Send the base64 image [2] to create a prompt
                    string response_from_AI = AI_API.ImageToText_LAVIS(Items_After_Decypted[1]);

                    //Get userID from the username
                    string raw_data_be_encrypted = Items_After_Decypted[2] + "-" + response_from_AI;

                    //// Encypted the final_string (User data) by the key
                    ////send_infor_string = Encryption_.Encrypt(raw_data_be_encrypted, public_key);

                    //dataheader = new DataPacket(send_infor_string, public_key);

                    //final_response = dataheader + "-" + send_infor_string;

                    ////Send the packet
                    //data = Encoding.ASCII.GetBytes(final_response);
                    //sendRespond(data);
                    break;
                    }
                    else
                    {
                    Console.WriteLine("Something went wrong: incorrect option number\n");
					break;
                    }
            }

            Console.WriteLine("Respond sent");
            ConnectedClient.BeginRead(buffer, 0, bytesize, callBack, buffer);
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