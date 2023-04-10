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
                string send = DataFactory.DataPacketCreateForLoginProcess(Username, Password);
                byte[] bytes_data = Encoding.ASCII.GetBytes(send);
                //Take Respond
                string respond = await ConnectionServices.SendReceiveProcess(bytes_data);
                // Format Server>UserID>DataLength-send_infor_string(data encrypted. Format: Declined(if failed) or "LoginSuccessfully")
                if (respond == "Declined")
                {
                    checking_Status = false;
                }
                else
                {
                    string[] Items = respond.Split('-');
                    DataPacket Received_Datapacket = new DataPacket(Items[0]);
                    string public_key = Received_Datapacket.source;
                    int Datalength;
                    bool success = int.TryParse(Received_Datapacket.DataLength, out Datalength);
                    //Take the exactly amount bytes for data be encypted
                    string data_encypted_received = Items[1].Substring(0, Datalength);
                    string decrypted_data = SecurityServices.Decrypt(data_encypted_received, public_key);
                    //await Application.Current.MainPage.DisplayAlert("Notification", "Decrypted data receive: " + decrypted_data, "OK.");
                    string[] Items_in_decrypted_data = decrypted_data.Split('-');
                    if (Items_in_decrypted_data[0] == "LoginSuccessful")
                    { checking_Status = true; } else { checking_Status = false; }
                }
            }
            catch (Exception)
            {
                checking_Status = false;
            }
        }

        public Command Login_Checking => new Command(async () =>
        {
            await setStatus();
            if (checking_Status == true)
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "Login SuccessFully", "OK.");
                //await Shell.Current.GoToAsync("//HomePage");
                //await Application.Current.MainPage.Navigation.PushModalAsync(new AppShell());
                await Shell.Current.GoToAsync("//Main_Page_Route");

            }
            else { await Application.Current.MainPage.DisplayAlert("Notification", "Login Failed", "OK."); }
        });

        public Command SignUp => new Command(async () =>{ await Shell.Current.GoToAsync("//LoginPage/SignUpPage"); });

        public Command ForgotPassword => new Command(async () =>
        {
            //Connect to SMTP and send the email to the client
        });
    }
}
