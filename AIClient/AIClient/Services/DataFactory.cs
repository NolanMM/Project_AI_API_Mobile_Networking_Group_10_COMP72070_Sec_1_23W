using AIClient.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Essentials;

namespace AIClient.Services
{
    public static class DataFactory
    {
        private static string UserID_For_Key;
        public static string DataPacketCreateForLoginProcess(string Username, string Password)
        {
            string request_type = "Login";
            string username = Username;
            string password = Password;
            string UserID = SecurityServices.ComputeSha256Hash(username);

            // Take 16 chars from userID for the key for AES the data
            string public_key = UserID.Substring(0, 8);
            UserID_For_Key = public_key;
            // Combine all the data together
            // Format: Login-Username-Password

            string final_string = request_type + "-" + username + "-" + password;

            // Encypted the final_string (User data) by the key
            string send_infor_string = SecurityServices.Encrypt(final_string, public_key);

            DataPacket dataheader = new DataPacket(send_infor_string, public_key);

            // source>Destination>DataLength-send_infor_string(data encrypted. Format: Login-Username-Password) 
            // using DataPacket.getUserID() to be the key to decrypted the send_infor_string
            string final = dataheader.DataPacketToString() + "-" + send_infor_string;
            return final;
        }

        public static string DataPacketCreateForSignUpProcess(string Username, string Password,string Email)
        {
            string request_type = "SignUp";
            string UserID = SecurityServices.ComputeSha256Hash(Username);
            string public_key = UserID.Substring(0, 8);
            string final_string = request_type + "-" + Username + "-" + Password + "-" +Email;
            string send_infor_string = SecurityServices.Encrypt(final_string, public_key);
            DataPacket dataheader = new DataPacket(send_infor_string, public_key);
            string final = dataheader.DataPacketToString() + "-" + send_infor_string;
            return final;
        }

        public static string DataPacketCreateForTextToTextRequest(string question)
        {
            string request_type = "Text_To_Text";
            string final_string = request_type + "-" + question;
            string send_infor_string = SecurityServices.Encrypt(final_string, UserID_For_Key);
            DataPacket dataheader = new DataPacket(send_infor_string, UserID_For_Key);
            string final = dataheader.DataPacketToString() + "-" + send_infor_string;
            return final;
        }

        //public static string DataPacketCreateForForgotPasswordProcess()
        //{

        //}

        //public static string DataPacketCreateForImageToTextRequest()
        //{

        //}

        //public static string DataPacketCreateForTextToImageRequest()
        //{

        //}
        //public static string DataPacketCreateForSignOutProcess()
        //{

        //}
    }
}
