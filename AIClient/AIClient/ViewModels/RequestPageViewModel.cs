using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace AIClient.ViewModels
{
    public class RequestPageViewModel
    {
        public RequestPageViewModel()
        {
            MenuList = GetMenu();
        }
        public List<Pick> MenuList { get; set; }

        private List<Pick> GetMenu()
        {
            return new List<Pick>
            {
                new Pick { Title = "Text To Text", Image = "IMG05.png", Description = "Request the question and we will answer it for you", Price = "$0.99" },
                new Pick { Title = "Text To Image", Image = "IMG04.png", Description = "Describe an Image and we will draw it for you", Price = "$0.99" },
                new Pick { Title = "Image To Text", Image = "IMG01.png", Description = "Input an Image and we will describe it for you", Price = "$1.25" }
            };
        }

}
    public class Pick
    {
        public Command AddButtonClick { get; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public Pick()
        {
            AddButtonClick = new Command(NavigateToPage);

        }
        async void NavigateToPage()
        {
            if (Title == "Text To Text"){
                await Shell.Current.GoToAsync("/TextToTextRequestPage");
            }
            else if(Title == "Text To Image"){
                await Shell.Current.GoToAsync("/TextToImageRequestPage");
            }
            else{
                await Shell.Current.GoToAsync("/ImageToTextRequestPage");
            }
        }
    }
}
