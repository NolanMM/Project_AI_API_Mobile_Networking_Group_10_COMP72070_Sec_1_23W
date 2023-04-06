using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace AIClient.ViewModels
{
    public class SettingPageViewModel
    {
        public Command SignOut => new Command(async () =>
        {
            await Application.Current.MainPage.DisplayAlert("Notification", "Sign Out Successully", "OK.");
            await Shell.Current.GoToAsync("//LoginPage");
        });
    }
}
