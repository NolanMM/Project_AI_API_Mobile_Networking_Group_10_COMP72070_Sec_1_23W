using AIClient.Views;
using Xamarin.Forms;

namespace AIClient
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage),
                typeof(MainPage));
            Routing.RegisterRoute(nameof(RequestPage),
                typeof(RequestPage));
            Routing.RegisterRoute(nameof(SignUpPage),
                typeof(SignUpPage));
        }

    }
}
