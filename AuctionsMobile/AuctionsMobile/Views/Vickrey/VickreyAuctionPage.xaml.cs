using AuctionsMobile.ViewModels.Vickrey;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuctionsMobile.Views.Vickrey
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VickreyAuctionPage : ContentPage
    {
        public VickreyAuctionPage()
        {
            InitializeComponent();
            BindingContext = new VickreyAuctionViewModel();
        }
    }
}