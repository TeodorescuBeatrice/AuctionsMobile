using AuctionsMobile.ViewModels.Dutch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuctionsMobile.Views.Dutch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DutchItemsPage : ContentPage
    {
        DutchItemsViewModel _viewModel;
        public DutchItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new DutchItemsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this._viewModel.LoadItemsCommand.Execute(null);
        }
    }
}