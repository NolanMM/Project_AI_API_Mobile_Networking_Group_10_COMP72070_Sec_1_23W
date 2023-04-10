using AIClient.Models;
using AIClient.Services;
using AIClient.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Drawing;
using Command = MvvmHelpers.Commands.Command;
using Newtonsoft.Json;
using System.Net.WebSockets;

namespace AIClient.ViewModels
{
    public class ImageToTextRequestPageViewModel: ObservableObject
    {
        public ImageToTextRequestPageViewModel()
        {
            ImageToTextSendButton = new Command(SendRequestToSerVerImageToTextAsync);
            CamareButton = new Command(TakePictureFromCamera);
            FileStorageAccess = new Command(TakePictureFromFileStorageAccess);
        }

        string descriptionForPicture = "";
        public string DescriptionForPicture { get => descriptionForPicture; set => SetProperty(ref descriptionForPicture, value); }
        public Command ImageToTextSendButton { get; }
        public Command CamareButton { get; }
        public Command FileStorageAccess { get; }

        private string respond_Server { get; set; }

        public ImageSource ResultImage { get; set; }

        public string File_result_Path { get; set; }

        async void SendRequestToSerVerImageToTextAsync()
        {
            string imageToString = DataFactory.ImageToBase64(File_result_Path);
            // Create a JSON object with the base64-encoded image string

            // Serialize the JSON object to a string
            //string jsonString = JsonSerializer.Serialize(WebSocketState,jsonObject);
            string SendCreateHeaderPacket = DataFactory.DataPacketCreateForHeaderCustomsizeFileRequest(imageToString);
            //string send = DataFactory.DataPacketCreateForImageToTextRequest(imageToString);

            byte[] bytes_data = Encoding.ASCII.GetBytes(SendCreateHeaderPacket);
            string respond = await ConnectionServices.SendReceiveProcess(bytes_data);

            // Format Server>UserID>DataLength-send_infor_string(data encrypted. Format: Declined(if failed) or "Text")
            if (respond == "Declined")
            {
                respond_Server = "Error Occured";
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
                string[] Items_In_Decrypted_Data = decrypted_data.Split('-');
                if (Items_In_Decrypted_Data[0] == "Image_To_TextRespond")
                {
                    respond_Server = Items_In_Decrypted_Data[1];
                }
                else
                {
                    respond_Server = "Error Occured";
                }
            }

            var route = $"{nameof(ImageToTextRespondPage)}?FullPath={File_result_Path}&desciptionRespond={respond_Server}";
            await Shell.Current.GoToAsync(route);
        }
        async void TakePictureFromCamera()
        {
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
            {
                Title = "Please Pick A Photo You Want To Sent"
            });
            // Take the stream out of result
            var stream = await result.OpenReadAsync();
            ResultImage = ImageSource.FromStream(() => stream);
            OnPropertyChanged(nameof(ResultImage));
        }
        async void TakePictureFromFileStorageAccess()
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please Pick A Photo You Want To Sent"
            });
            File_result_Path = result.FullPath;
            var stream = await result.OpenReadAsync();
            ResultImage = ImageSource.FromStream(() => stream);
            OnPropertyChanged(nameof(ResultImage));
        }
    }
}
