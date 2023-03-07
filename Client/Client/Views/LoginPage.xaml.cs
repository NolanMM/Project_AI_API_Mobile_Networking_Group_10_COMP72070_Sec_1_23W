using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //var loggedin = true;
        //    //if(loggedin)
        //    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

        //}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomePage");
            //await Navigation.PushModalAsync(new HomePage());

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//RegisterPage");
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}