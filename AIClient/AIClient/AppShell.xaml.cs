using AIClient.Views;
using Xamarin.Forms;

namespace AIClient
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterLink();

        }
        void RegisterLink()
        {
            Routing.RegisterRoute(nameof(MainPage),
                typeof(MainPage));
            Routing.RegisterRoute(nameof(RequestPage),
                typeof(RequestPage));
            Routing.RegisterRoute(nameof(SignUpPage),
                typeof(SignUpPage));
            Routing.RegisterRoute(nameof(TextToTextRequestPage),
                typeof(TextToTextRequestPage));
            Routing.RegisterRoute(nameof(ImageToTextRequestPage),
                typeof(ImageToTextRequestPage));
            Routing.RegisterRoute(nameof(TextToImageRequestPage),
                typeof(TextToImageRequestPage));
            Routing.RegisterRoute(nameof(ImageToTextRespondPage),
                typeof(ImageToTextRespondPage));
        }

    }
}
