using ActressMas;
using AuctionsMobile.Auctions.Dutch;
using AuctionsMobile.Helpers;
using AuctionsMobile.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuctionsMobile.ViewModels.Dutch
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class DutchAuctionViewModel : BaseViewModel
    {
        private Item _currentItem;
        public Item CurrentItem
        {
            get => this._currentItem;
            set => this.SetProperty(ref _currentItem, value);
        }
        private string itemId;
        public string ItemId
        {
            get => this.itemId;
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        private AuctioneerAgent _auctioneerAgent;
        public AuctioneerAgent AuctioneerAgent
        {
            get => this._auctioneerAgent;
            set => this.SetProperty(ref _auctioneerAgent, value);
        }
        public Command StartAuctionCommand { get; set; }
        public DutchAuctionViewModel()
        {
            this.StartAuctionCommand = new Command(async () => await this.StartAuction());
            this.AuctioneerAgent = new AuctioneerAgent();
        }
        public async void LoadItemId(string itemId)
        {
            try
            {
                CurrentItem = await DataStore.GetItemAsync(itemId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public async Task StartAuction()
        {
            try
            {
                await Task.Run(() =>
                {
                    IsBusy = true;
                    var env = new TurnBasedEnvironment(0, 200);

                    for (int i = 1; i <= Constants.NoBidders; i++)
                    {
                        int agentValuation = Constants.MinPrice + Constants.RandNoGen.Next(Constants.MaxPrice - Constants.MinPrice);
                        var bidderAgent = new BidderAgent(agentValuation);
                        env.Add(bidderAgent, string.Format("bidder{0:D2}", i));
                    }

                    AuctioneerAgent = new AuctioneerAgent();
                    env.Add(AuctioneerAgent, "auctioneer");

                    env.Start();
                    IsBusy = false;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                IsBusy = false;
            }
        }
    }
}
