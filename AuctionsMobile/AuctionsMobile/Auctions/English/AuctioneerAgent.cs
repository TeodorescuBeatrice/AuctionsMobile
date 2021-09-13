using ActressMas;
using AuctionsMobile.Auctions;
using AuctionsMobile.Helpers;
using System;
using System.Collections.Generic;
using System.Timers;

namespace AuctionsMobile.Auctions.English
{
    public class AuctioneerAgent : BaseAgent
    {
        private List<string> _bidders;
        private string _highestBidder;
        private int _currentPrice;
        public int CurrentPrice
        {
            get => this._currentPrice;
            set => this.SetProperty(ref _currentPrice, value);
        }
        private string _finalMessage;
        public string FinalMessage
        {
            get => this._finalMessage;
            set => this.SetProperty(ref _finalMessage, value);
        }
        private Timer _timer;
        public AuctioneerAgent()
        {
            _bidders = new List<string>();
            _timer = new Timer();
            _timer.Elapsed += t_Elapsed;
            _timer.Interval = Constants.Delay;
        }

        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            Send(this.Name, "wake-up");
        }

        public override void Setup()
        {
            CurrentPrice = Constants.ReservePrice;
            Broadcast(Utils.Str("price", CurrentPrice));
            _timer.Start();
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
                        HandleBid(message.Sender);
                        break;

                    case "wake-up":
                        HandleWakeUp();
                        break;

                    default: break;
                }
            }
        }

        private void HandleBid(string sender)
        {
            _bidders.Add(sender);
        }

        private void HandleWakeUp()
        {
            if (_bidders.Count == 0) // no more bids
            {
                CurrentPrice -= Constants.Increment;
                if (CurrentPrice < Constants.ReservePrice)
                {
                    Console.WriteLine($"[{this.Name}]: Auction finished. No winner.");
                    FinalMessage = "Auction finished. No winner.";
                    Broadcast(Utils.Str("winner", "none"));
                }
                else
                {
                    Console.WriteLine($"[{this.Name}]: Auction finished. Sold to {_highestBidder} for price {CurrentPrice}.");
                    FinalMessage = $"Auction finished. Sold to {_highestBidder} for price {CurrentPrice}.";
                    Broadcast(Utils.Str("winner", _highestBidder));
                }
                _timer.Stop();
                Stop();
            }
            else if (_bidders.Count == 1) // winner
            {

                _highestBidder = _bidders[0];
                Console.WriteLine($"[{this.Name}]: Auction finished. Sold to {_highestBidder} for price {CurrentPrice}");
                FinalMessage = $"Auction finished. Sold to {_highestBidder} for price {CurrentPrice}.";
                Broadcast(Utils.Str("winner", _highestBidder));
                _timer.Stop();
                Stop();
            }
            else
            {
                _highestBidder = _bidders[0]; // first or random from the previous round, breaking ties
                CurrentPrice += Constants.Increment;

                foreach (string a in _bidders)
                    Send(a, Utils.Str("price", CurrentPrice));

                _bidders.Clear();
            }
        }
    }
}
