using AIClient.Models;
using AIClient.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIClient.ViewModels
{
    public class TextToImageRequestPageViewModel : ObservableObject
    {
        public TextToImageRequestPageViewModel()
        {
            TextToImageSendButton = new Command(SendRequestToSerVerTextToImageAsync);
        }
        string question = "";
        string respond = "";
        public string DescriptionForPicture { get => question; set => SetProperty(ref question, value); }
        public Command TextToImageSendButton { get; }
        public string RespondFromServer { get => respond; set => SetProperty(ref respond, value); }
        async void SendRequestToSerVerTextToImageAsync()
        {
            try
            {
                // Send process
                string send = DataFactory.DataPacketCreateForTextToImageRequest(DescriptionForPicture);
                byte[] bytes_data = Encoding.ASCII.GetBytes(send);
                //Take Respond
                string respond = await ConnectionServices.SendReceiveProcess(bytes_data);

                // Process Respond
                // Format Server>UserID>DataLength-send_infor_string(data encrypted. Format: Declined(if failed) or "Text")
                if (respond == "Declined")
                {
                    RespondFromServer = "Error Occured";
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
                    //string[] Items_In_Decrypted_Data = decrypted_data.Split(, StringSplitOptions.None);
                    string[] Items_In_Decrypted_Data = decrypted_data.Split(new[] { "*__*" }, StringSplitOptions.None);
                    if (Items_In_Decrypted_Data[0] == "Text_To_TextRespond")
                    {
                        RespondFromServer = Items_In_Decrypted_Data[1];
                    }
                    else
                    {
                        RespondFromServer = "Error Occured";
                    }
                }

            }
            catch (Exception ex)
            {
                RespondFromServer = ex.ToString();
            }
        }
    }
}
