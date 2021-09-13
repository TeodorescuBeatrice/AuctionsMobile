using AuctionsMobile.Views;
using AuctionsMobile.Views.Blind;
using AuctionsMobile.Views.Dutch;
using AuctionsMobile.Views.English;
using AuctionsMobile.Views.Vickrey;
using Xamarin.Forms;

namespace AuctionsMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EnglishAuctionPage), typeof(EnglishAuctionPage));
            Routing.RegisterRoute(nameof(DutchAuctionPage), typeof(DutchAuctionPage));
            Routing.RegisterRoute(nameof(BlindAuctionPage), typeof(BlindAuctionPage));
            Routing.RegisterRoute(nameof(VickreyAuctionPage), typeof(VickreyAuctionPage));
        }

    }
}
