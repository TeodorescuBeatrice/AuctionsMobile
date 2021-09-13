using AuctionsMobile.ViewModels.Vickrey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuctionsMobile.Views.Vickrey
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VickreyItemsPage : ContentPage
    {
        VickreyItemsViewModel _viewModel;
        public VickreyItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new VickreyItemsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this._viewModel.LoadItemsCommand.Execute(null);
        }
    }
}