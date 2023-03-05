using Client_UI.Services;
using Client_UI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client_UI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
