using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SQLite.SQLite3;

namespace AIClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageToTextRespondPage : ContentPage
    {
        public ImageToTextRespondPage()
        {
            InitializeComponent();
        }
    }

}