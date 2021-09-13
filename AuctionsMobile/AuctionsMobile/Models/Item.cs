using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AuctionsMobile.Helpers;
using AuctionsMobile.ViewModels;
using AuctionsMobile.ViewModels.Blind;
using AuctionsMobile.ViewModels.Dutch;
using AuctionsMobile.ViewModels.English;
using AuctionsMobile.ViewModels.Vickrey;
using AuctionsMobile.Views;
using AuctionsMobile.Views.Blind;
using AuctionsMobile.Views.Dutch;
using AuctionsMobile.Views.English;
using AuctionsMobile.Views.Vickrey;
using Xamarin.Forms;

namespace AuctionsMobile.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public AuctionType AuctionType { get; set; }
        public ICommand ItemTappedCommand { get; set; }
        public Item()
        {
            this.ItemTappedCommand = new Command(async() => await this.ItemTappedHandler());
        }

        private async Task ItemTappedHandler()
        {
            switch (AuctionType)
            {
                case AuctionType.English: 
                    await Shell.Current.GoToAsync($"{nameof(EnglishAuctionPage)}?{nameof(EnglishAuctionViewModel.ItemId)}={this.Id}");
                    break;
                case AuctionType.Dutch:
                    await Shell.Current.GoToAsync($"{nameof(DutchAuctionPage)}?{nameof(DutchAuctionViewModel.ItemId)}={this.Id}");
                    break;
                case AuctionType.Blind:
                    await Shell.Current.GoToAsync($"{nameof(BlindAuctionPage)}?{nameof(BlindAuctionViewModel.ItemId)}={this.Id}");
                    break;
                case AuctionType.Vickrey:
                    await Shell.Current.GoToAsync($"{nameof(VickreyAuctionPage)}?{nameof(VickreyAuctionViewModel.ItemId)}={this.Id}");
                    break;
                default: break;
            }
           
        }
    }
}