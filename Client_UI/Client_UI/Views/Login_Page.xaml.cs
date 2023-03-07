using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client_UI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login_Page : ContentPage
	{
		public Login_Page ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // direct rout here use // and $
            await Navigation.PushModalAsync(new HomePage());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}