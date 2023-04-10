using AIClient.Models;
using AIClient.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace AIClient.ViewModels
{
    public class SignUpPageViewModel
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public bool checking_Status = false;
        public async Task setStatus()
        {
            try
            {
                string send = DataFactory.DataPacketCreateForSignUpProcess(Username, Password,Email);
                byte[] bytes_data = Encoding.ASCII.GetBytes(send);
                //Take Respond
                string respond = await ConnectionServices.SendReceiveProcess(bytes_data);
                // Format Server>UserID>DataLength-send_infor_string(data encrypted. Format: Declined(if failed) or "LoginSuccessfully")
                if (respond == "SignUpFailed")
                {
                    checking_Status = false;
                }else if(respond == "SignUpFailed-Duplicate Username")
                {
                    await Application.Current.MainPage.DisplayAlert("Notification", "Sign Up Failed\n" + "Duplicate Username Found", "Try Again");
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
                    string[] Items_in_decrypted_data = decrypted_data.Split('-');
                    if (Items_in_decrypted_data[0] == "SignUpSuccessfully")
                    { checking_Status = true; }
                    else { checking_Status = false; }
                }
            }
            catch (Exception)
            {
                checking_Status = false;
            }
        }
        public Command SignUp => new Command(async () =>
        {
            await setStatus();
            if (checking_Status == true)
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "Sign Up SuccessFully", "OK.");
                await Shell.Current.GoToAsync("..//MainPage");

            }
            else { await Application.Current.MainPage.DisplayAlert("Notification", "Login Failed", "OK."); }
        });
    }
}
