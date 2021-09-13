using AuctionsMobile.ViewModels.English;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuctionsMobile.Views.English
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnglishItemsPage : ContentPage
    {
        EnglishItemsViewModel _viewModel;
        public EnglishItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EnglishItemsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this._viewModel.LoadItemsCommand.Execute(null);
        }
    }
}