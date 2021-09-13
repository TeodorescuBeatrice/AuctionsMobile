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
    public partial class DutchAuctionPage : ContentPage
    {
        public DutchAuctionPage()
        {
            InitializeComponent();
            BindingContext = new DutchAuctionViewModel();
        }
    }
}