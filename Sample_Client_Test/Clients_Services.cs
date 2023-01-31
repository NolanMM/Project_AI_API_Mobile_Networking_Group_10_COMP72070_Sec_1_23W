using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;
using Microsoft.Win32;
using static MultiClient.Client; 

namespace MultiClient
{
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

    }
}