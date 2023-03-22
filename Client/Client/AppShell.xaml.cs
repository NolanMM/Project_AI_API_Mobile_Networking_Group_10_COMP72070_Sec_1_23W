using Client.Views;
using Xamarin.Forms;

namespace Client
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPageWithTabs), typeof(MainPageWithTabs));
            Routing.RegisterRoute(nameof(TabbedPageMain), typeof(TabbedPageMain));
        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    //await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}