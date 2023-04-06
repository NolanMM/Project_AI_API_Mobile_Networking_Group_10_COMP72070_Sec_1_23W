using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AIClient.Models
{
    public sealed class Clients_info
    {
        private string UserID { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Email { get; set; }

        private static Clients_info Instance = null;

        private Clients_info(string UserID, string Username, string Password, string Email)
        {
            //Each Time the Constructor called, increment the Counter value by 1
            this.UserID = UserID;
            this.Username= Username;
            this.Password = Password;
            this.Email = Email;
        }

        public static void SetUpInstance(string UserID, string Username, string Password, string Email)
        {
            if (Instance == null)
            {
                Instance = new Clients_info(UserID,  Username,  Password,  Email);
            }else { return; }
        }
        public static Clients_info GetInstance()
        {
            //Return the Singleton Instance
            return Instance;
        }
        //The following can be accesed from outside of the class by using the Singleton Instance
        public string getUserID()
        {
            return GetInstance().UserID;
        }
        public string getUsername()
        {
            return GetInstance().Username;
        }
        public string getPassword()
        {
            return GetInstance().Password;
        }
        public string getEmail()
        {
            return GetInstance().Email;
        }
    }
}
