using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace MultiClient
{
    public class Clients_infor
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public static class Main_Menu_Client
    {
        public static string resond_from_server = "Empty";

        public static void _menu_client(Clients_infor clients_Infor)
        {
            bool flag = true;
            while (flag == true)
            {
                Console.WriteLine("Please Enter the mode you want to\n");
                Console.WriteLine("1. Text\n");
                Console.WriteLine("2. Image\n");
                Console.WriteLine("3. Image to Text\n");
                Console.WriteLine("4. Exit\n");

                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "1":
                        Request_Text_to_Text(clients_Infor);
                        break;

                    case "2":
                        Request_Text_to_Image(clients_Infor);
                        break;

                    case "3":
                        break;

                    case "image to text":
                        break;

                    case "4":
                        string respond_message_disconnect = "disconnected";
                        Client.SendString(respond_message_disconnect);
                        flag = false;
                        Client.Exit();
                        break;

                    case "exit":
                        string respond_message_disconnect_exit = "disconnected";
                        Client.SendString(respond_message_disconnect_exit);
                        flag = false;
                        Client.Exit();
                        break;

                    case "text":
                        Request_Text_to_Text(clients_Infor);
                        break;

                    case "image":
                        Request_Text_to_Image(clients_Infor);
                        break;

                    default:
                        Console.WriteLine("\nWrong input. Please input again\n");
                        break;
                }
            }
        }

        public static void Request_Text_to_Image(Clients_infor clients_Infor)
        {
            // Declare the type of Request
            string request_type = "Text_to_Image";
            string prompt_input = "Empty";
            Console.WriteLine("Please enter the prompt\n");
            prompt_input = Console.ReadLine();

            // Create send message to server by format RequestPrompt-Username-PromptContent
            string send_message_raw = request_type + "-" + clients_Infor.Username + "-" + prompt_input;

            // Take 16 chars from userID for the key for AES the data
            string public_key = clients_Infor.UserID.Substring(0, 8);
            string secret_key = clients_Infor.UserID.Substring(8, 8);

            string send_infor_string = Encryption_.Encrypt(send_message_raw, public_key, secret_key);

            string respond = clients_Infor.UserID + "-" + send_infor_string;

            Client.SendString(respond);

            // Receive the respond from server
            //resond_from_server = Client.ReceiveResponse();
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) { Console.WriteLine("cannot receive\n"); }
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            resond_from_server = text;
            Decrypted_and_show_respond_Text_to_Text();
        }

        public static void Request_Text_to_Text(Clients_infor clients_Infor)
        {
            // Declare the type of Request
            string request_type = "Text_to_Text";
            string prompt_input = "Empty";
            Console.WriteLine("Please enter the prompt\n");
            prompt_input = Console.ReadLine();

            // Create send message to server by format RequestPrompt-Username-PromptContent
            string send_message_raw = request_type + "-" + clients_Infor.Username + "-" + prompt_input;

            // Take 16 chars from userID for the key for AES the data
            string public_key = clients_Infor.UserID.Substring(0, 8);
            string secret_key = clients_Infor.UserID.Substring(8, 8);

            string send_infor_string = Encryption_.Encrypt(send_message_raw, public_key, secret_key);

            string respond = clients_Infor.UserID + "-" + send_infor_string;

            Client.SendString(respond);

            // Receive the respond from server
            //resond_from_server = Client.ReceiveResponse();
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) { Console.WriteLine("cannot receive\n"); }
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            resond_from_server = text;
            Decrypted_and_show_respond_Text_to_Text();
        }

        private static readonly Socket ClientSocket = Client.ClientSocket;
        private const int PORT = 100;

        public static void Decrypted_and_show_respond_Text_to_Text()
        {
            // Take the items from respond
            // Items_in_respond[0] = Key
            // Items_in_respond[1] = Data encrypted (Prompt-Respond)
            string[] Items_in_respond = resond_from_server.Split('-');

            // Decrypted to take the data by key from Items_in_respond[0]
            string public_key = Items_in_respond[0].Substring(0, 8);
            string secret_key = Items_in_respond[0].Substring(8, 8);

            string decrypted_data = Encryption_.Decrypt(Items_in_respond[1], public_key, secret_key);

            // Take items from decrypted_data
            // decrypted_data[0] Prompt
            // decrypted_data[1] Respond
            string[] Items_in_decrypted_data = decrypted_data.Split("*/()/*");

            Console.WriteLine("The prompt is: " + Items_in_decrypted_data[0]);
            Console.WriteLine("The Respond is: " + Items_in_decrypted_data[1]);
        }
    }

    public static class Encryption_
    {
        internal static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public static string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        public static string Quick_Encypted_Account_by_Using_Hashing_Key_By_Username(string username, string password, string email)
        {
            string raw_material = username;
            string UserID = Encryption_.ComputeSha256Hash(raw_material);

            // Take 16 chars from userID for the key for AES the data
            string public_key = UserID.Substring(0, 8);
            string secret_key = UserID.Substring(8, 8);

            // Combine all the data together
            string final_string = username + "-" + password + "-" + email;

            // Encypted the final_string (User data) by the key
            string final_encryption = Encryption_.Encrypt(final_string, public_key, secret_key);

            return final_encryption;
        }

        //public static string ShuffleKeyEncryption(string raw_key)
        //{
        //    return
        //}
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string Encrypt(string str, string public_key, string secret_key)
        {
            try
            {
                string textToEncrypt = str;
                string ToReturn = "";
                string publickey = public_key;
                string secretkey = secret_key;
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                //Console.WriteLine(ToReturn);
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static string Decrypt(string str, string public_key, string secret_key)
        {
            try
            {
                string textToDecrypt = str;
                string ToReturn = "";
                string publickey = public_key;
                string privatekey = secret_key;
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(privatekey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                //Console.WriteLine(ToReturn);
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
    }

    public static class Clients_Services
    {
        public static string Sing_Up_Clients()
        {
            string return_message = "Empty";
            try
            {
                string request_type = "Register";
                Console.WriteLine("Please Enter Username\n");
                string username = Console.ReadLine();
                Console.WriteLine("Please Enter Password\n");
                string password = Console.ReadLine();
                Console.WriteLine("Please Enter Emails\n");
                string email = Console.ReadLine();

                string raw_material = username;
                string UserID = Encryption_.ComputeSha256Hash(raw_material);

                // Take 16 chars from userID for the key for AES the data
                string public_key = UserID.Substring(0, 8);
                string secret_key = UserID.Substring(8, 8);

                // Combine all the data together
                // Format: Register - Username - Password - Email

                string final_string = request_type + "-" + username + "-" + password + "-" + email;

                // Encypted the final_string (User data) by the key
                string send_infor_string = Encryption_.Encrypt(final_string, public_key, secret_key);

                string respond = UserID + "-" + send_infor_string;

                Client.SendString(respond);

                Console.WriteLine();
                Console.WriteLine("String send: " + respond);
                Console.WriteLine();

                return_message = "\nSend Successful to server Sign Up request\n";
                return return_message;
            }
            catch
            {
                return_message = "\nCannot send to server Sign Up request\n";
                return return_message;
            }
        }

        public static string Sign_In_Client()
        {
            string return_message = "Empty";
            try
            {
                string request_type = "Login";
                Console.WriteLine("Please Enter Username\n");
                string username = Console.ReadLine();
                Console.WriteLine("Please Enter Password\n");
                string password = Console.ReadLine();

                string raw_material = username;
                string UserID = Encryption_.ComputeSha256Hash(raw_material);

                // Take 16 chars from userID for the key for AES the data
                string public_key = UserID.Substring(0, 8);
                string secret_key = UserID.Substring(8, 8);

                // Combine all the data together
                // Format: Register - Username - Password - Email

                string final_string = request_type + "-" + username + "-" + password;

                // Encypted the final_string (User data) by the key
                string send_infor_string = Encryption_.Encrypt(final_string, public_key, secret_key);

                string respond = UserID + "-" + send_infor_string;

                Client.SendString(respond);

                Console.WriteLine();
                Console.WriteLine("String send: " + respond);
                Console.WriteLine();

                return_message = "\nSend Successful to server Sign In request\n";
                return return_message;
            }
            catch
            {
                return_message = "\nCannot send to server Sign In request\n";
                return return_message;
            }
        }
    }
}