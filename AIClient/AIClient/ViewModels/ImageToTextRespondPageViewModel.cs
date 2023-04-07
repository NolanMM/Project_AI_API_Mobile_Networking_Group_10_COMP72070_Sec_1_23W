using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AIClient.ViewModels
{
    [QueryProperty(nameof(FullPath), nameof(FullPath))]
    [QueryProperty(nameof(DesciptionRespond), nameof(desciptionRespond))]
    public class ImageToTextRespondPageViewModel:ObservableObject
    {
        public ImageSource Source { get; set; }
        public string FullPath { get => fullPath; set { 
                if(value == fullPath) return;
                fullPath = value;
                PassImageAsync();
            } }
        public FileResult ItemSelectedFile { get; set; }

        public ImageToTextRespondPageViewModel()
        {
            BackButton = new Command(SendRequestToSerVerImageToTextAsync);
            NewRequest = new Command(NewRequestNavigation);
        }
        async void PassImageAsync()
        {
            ItemSelectedFile = new FileResult(fullPath);
            var stream = await ItemSelectedFile.OpenReadAsync();
            Source = ImageSource.FromStream(() => stream);
            OnPropertyChanged(nameof(Source));
        }

        private string fullPath = "";
        string desciptionRespond = "";
        public string DesciptionRespond { get => desciptionRespond; set => SetProperty(ref desciptionRespond, value); }
        public Command BackButton { get; }

        async void SendRequestToSerVerImageToTextAsync()
        {
            //Send Logic here

            //Go to Respond page and pass the value to it
            await Shell.Current.GoToAsync("..");
        }
        public Command NewRequest { get; }

        async void NewRequestNavigation()
        {
            //Send Logic here

            //Go to Respond page and pass the value to it
            await Shell.Current.GoToAsync("//Request_Page_Route");
        }
    }
}
