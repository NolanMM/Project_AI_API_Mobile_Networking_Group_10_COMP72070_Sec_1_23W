using ClientSide.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClientSide.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}