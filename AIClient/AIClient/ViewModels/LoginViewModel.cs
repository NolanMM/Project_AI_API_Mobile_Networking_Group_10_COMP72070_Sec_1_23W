using AIClient.Models;
using AIClient.Services;
using System;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AIClient.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }
        public string Password { get; set; }
        public string Username { get; set; }

        public bool checking_Status = false;

        public async Task setStatus()
        {
            try
            {
                string request_type = "Login";
                string username = Username;
                string password = Password;
                string UserID = SecurityServices.ComputeSha256Hash(username);

                // Take 16 chars from userID for the key for AES the data
                string public_key = UserID.Substring(0, 8);

                // Combine all the data together
                // Format: Login-Username-Password

                string final_string = request_type + "-" + username + "-" + password;

                // Encypted the final_string (User data) by the key
                string send_infor_string = SecurityServices.Encrypt(final_string, public_key);

                DataPacket dataheader = new DataPacket(send_infor_string, public_key);

                // source>Destination>DataLength-send_infor_string(data encrypted. Format: Login-Username-Password) 
                // using DataPacket.getUserID() to be the key to decrypted the send_infor_string
                string send = dataheader.DataPacketToString() + "-" + send_infor_string;
                byte[] bytes_data = Encoding.ASCII.GetBytes(send);

                string respond = await ConnectionServices.SendReceiveProcess(bytes_data);
                checking_Status = true;
                await Application.Current.MainPage.DisplayAlert("Notification", respond, "OK.");

            }
            catch (Exception ex)
            {
                checking_Status = false;
            }

        }

        public Command Login_Checking => new Command(async () =>
        {
            await setStatus();
            if (checking_Status)
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "LoginSuccessFully", "OK.");
                //await Shell.Current.GoToAsync("//HomePage");
                //await Application.Current.MainPage.Navigation.PushModalAsync(new AppShell());
                await Shell.Current.GoToAsync("//Main_Page_Route");

            }
            else { await Application.Current.MainPage.DisplayAlert("Notification", "LoginFailed", "OK."); }
        });
        public Command ForgotPassword => new Command(async () =>
        {
            //Connect to SMTP and send the email to the client
        });
    }
}
