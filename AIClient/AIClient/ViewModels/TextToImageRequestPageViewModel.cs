using AIClient.Models;
using AIClient.Services;
using Android.Graphics;
using MvvmHelpers;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

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
        private byte[] imageGlobalBytes { get; set; }
        public ImageSource ResultImage { get; set; }
        public string DescriptionForPicture { get => question; set => SetProperty(ref question, value); }
        public Command TextToImageSendButton { get; }
        public string RespondFromServer { get => respond; set => SetProperty(ref respond, value); }
        public static byte[] getImageFromUrl(string url)
        {
            //System.Net.HttpWebRequest request = null;
            //System.Net.HttpWebResponse response = null;
            byte[] imageBytes = null;
            Uri uri = new Uri(url);
            //request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            //request.UseDefaultCredentials = true;
            //response = (System.Net.HttpWebResponse)request.GetResponse();

            using (var webClient = new WebClient())
            {
                imageBytes = webClient.DownloadData(uri);
            }

            return imageBytes;
        }
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
                    string data_received = Items[1].Substring(0, Datalength);
                    string decrypted_data = SecurityServices.Decrypt(data_received, public_key);
                    //await Application.Current.MainPage.DisplayAlert("Notification", "Decrypted data receive: " + decrypted_data, "OK.");
                    //string[] Items_In_Decrypted_Data = decrypted_data.Split(, StringSplitOptions.None);
                    string[] Items_In_Decrypted_Data = decrypted_data.Split(new[] { "*__*" }, StringSplitOptions.None);
                    if (Items_In_Decrypted_Data[0] == "TextToImageRespond")
                    {
                        RespondFromServer = Items_In_Decrypted_Data[1];
                        int resleng = RespondFromServer.Length;
                        // Convert the "b64_json" value from base64 to a byte array

                        byte[] images = getImageFromUrl(RespondFromServer);
                        // Convert base64 string to byte array

                        //byte[] imageBytes = Convert.FromBase64String(ImageDataJsonBase64);

                        using (MemoryStream stream = new MemoryStream(images))
                        {
                            // Use the MemoryStream.ToArray() method to get the byte array representation of the image data
                            byte[] imageBuffer = stream.ToArray();

                            // Create a BitmapFactory object and use the DecodeByteArray() method to decode the byte array and create a Bitmap object
                            Bitmap bitmap = BitmapFactory.DecodeByteArray(imageBuffer, 0, imageBuffer.Length);

                            // Set the Bitmap object as the source of an ImageView in your Xamarin app
                            //imageView.SetImageBitmap(bitmap);
                        }
                        imageGlobalBytes = images;
                        // Create memory stream from byte array
                        var stream1 = new MemoryStream(imageGlobalBytes);
                        ResultImage = ImageSource.FromStream(() => new MemoryStream(imageGlobalBytes));
                        OnPropertyChanged(nameof(ResultImage));
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
