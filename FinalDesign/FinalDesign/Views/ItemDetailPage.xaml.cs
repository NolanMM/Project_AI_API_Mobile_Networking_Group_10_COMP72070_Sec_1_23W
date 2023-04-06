﻿using System.ComponentModel;
using Xamarin.Forms;
using FinalDesign.ViewModels;

namespace FinalDesign.Views
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
