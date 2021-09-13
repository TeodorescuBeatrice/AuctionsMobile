using AuctionsMobile.ViewModels.Blind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuctionsMobile.Views.Blind
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlindItemsPage : ContentPage
    {
        BlindItemsViewModel _viewModel;
        public BlindItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BlindItemsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this._viewModel.LoadItemsCommand.Execute(null);
        }
    }
}