﻿using Xamarin.Forms;

namespace AIClient.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }
        public string Password { get; set; }
        public string Username { get; set; }

        public bool checking_Status = false;

        public void setStatus()
        {
            // for testing
            if (Username == "Nguyen" && Password == "Minh")
            {
                checking_Status = true;
            }
            else checking_Status = false;
        }

        public Command Login_Checking => new Command(async () =>
        {
            setStatus();
            if (checking_Status)
            {
                await Application.Current.MainPage.DisplayAlert("Notification", "LoginSuccessFully", "OK.");
                //await Shell.Current.GoToAsync("//HomePage");
                //await Application.Current.MainPage.Navigation.PushModalAsync(new AppShell());
                await Shell.Current.GoToAsync("//Main_Page_Route");

            }
            else { await Application.Current.MainPage.DisplayAlert("Notification", "LoginFailed", "OK."); }
        });
        public Command ForgotPassword => new Command(async () =>
        {
            //Connect to SMTP and send the email to the client
        });
    }
}
