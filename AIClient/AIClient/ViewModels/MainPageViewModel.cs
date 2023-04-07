using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AIClient.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            Picks = GetPicks();
        }
        public List<Pick> Picks { get; set; }

        public ICommand OrderCommand => new AsyncCommand(QuestionNow);

        async Task QuestionNow()
        {
            await Shell.Current.GoToAsync("//Request_Page_Route");
        }
        private List<Pick> GetPicks()
        {
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
