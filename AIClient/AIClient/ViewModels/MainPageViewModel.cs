using Android.App;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace AIClient.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            Picks = GetPicks();
            ChooseItem = new Command(ShortcutLink);
        }
        public List<Pick> Picks { get; set; }

        public ICommand OrderCommand => new AsyncCommand(QuestionNow);

        public Command ChooseItem { get; set; }
        public string Title { get; set; }
        async Task QuestionNow()
        {
            await Shell.Current.GoToAsync("//Request_Page_Route");
        }
        async void ShortcutLink()
        {
            if (Title == "Text To Text")
            {
                await Shell.Current.GoToAsync("/TextToTextRequestPage");
            }
            else if (Title == "Text To Image")
            {
                await Shell.Current.GoToAsync("/TextToImageRequestPage");
            }
            else
            {
                await Shell.Current.GoToAsync("/ImageToTextRequestPage");
            }
        }

        private List<Pick> GetPicks()
        {
            ChooseItem = new Command(ShortcutLink);
            return new List<Pick>
            {
                new Pick { Title = "Text To Text", Image = "IMG01.png",
                    Description = "Request the question and we will answer it for you" },
                new Pick { Title = "Text To Image", Image = "IMG03.png",
                    Description = "Describe an Image and we will draw it for you" },
                new Pick { Title = "Image To Text", Image = "IMG03.png",
                    Description = "Input an Image and we will describe it for you" }
            };
        }
    }
}
