using AuctionsMobile.ViewModels.Blind;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuctionsMobile.Views.Blind
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlindAuctionPage : ContentPage
    {
        public BlindAuctionPage()
        {
            InitializeComponent();
            BindingContext = new BlindAuctionViewModel();
        }
    }
}