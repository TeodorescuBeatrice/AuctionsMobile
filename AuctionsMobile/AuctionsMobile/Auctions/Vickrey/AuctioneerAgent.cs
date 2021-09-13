using ActressMas;
using AuctionsMobile.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuctionsMobile.Auctions.Vickrey
{
    class Bid
    {
        public string Bidder { get; set; }
        public int BidValue { get; set; }

        public Bid(string bidder, int bidValue)
        {
            Bidder = bidder;
            BidValue = bidValue;
        }
    }
    public class AuctioneerAgent : BaseAgent
    {
        private List<Bid> _bids;
        private string _finalMessage;
        public string FinalMessage
        {
            get => this._finalMessage;
            set => this.SetProperty(ref _finalMessage, value);
        }
        public AuctioneerAgent()
        {
            _bids = new List<Bid>();
        }

        public override void Setup()
        {
            Broadcast("start");
        }

        public override void Act(Queue<Message> messages)
        {
            if (messages.Count > 0)
            {
                Message message = messages.Dequeue();
                Console.WriteLine($"\t{message.Format()}");
                message.Parse(out string action, out string parameters);

                switch (action)
                {
                    case "bid":
                        HandleBid(message.Sender, Convert.ToInt32(parameters));
                        break;

                    default:
                        break;
                }
            }
        }
        private void HandleBid(string sender, int price)
        {
            _bids.Add(new Bid(sender, price));

            if (_bids.Count() == Constants.NoBidders)
                HandleFinish();
        }

        private void HandleFinish()
        {
            var bids = _bids.Where(x => x.BidValue >= Constants.ReservePrice).OrderByDescending(x => x.BidValue).ToList();
            var bidValues = bids.Select(x => x.BidValue).ToList();

            if (_bids.Count() == 0) // no bids above reserve price
            {
                Console.WriteLine("[auctioneer]: Auction finished. No winner.");
                FinalMessage = "Auction finished. No winner.";
                Broadcast("winner none");
            }
            else
            {
                int winningPrice = bidValues[1]; // second price
                var highestBidder = bids.FirstOrDefault().Bidder;
                Console.WriteLine($"[auctioneer]: Auction finished. Sold to {highestBidder} for price {winningPrice}.");
                FinalMessage = $"Auction finished. Sold to {highestBidder} for price {winningPrice}.";
                Broadcast($"winner {highestBidder}");
            }

            Stop();
        }
    }
}
