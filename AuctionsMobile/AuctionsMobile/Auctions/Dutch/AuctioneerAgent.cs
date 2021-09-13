using ActressMas;
using AuctionsMobile.Auctions;
using AuctionsMobile.Helpers;
using System;
using System.Collections.Generic;
using System.Timers;

namespace AuctionsMobile.Auctions.Dutch
{
    public class AuctioneerAgent : BaseAgent
    {
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
            CurrentPrice = Constants.MaxPrice;
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
            Console.WriteLine($"[{this.Name}]: Auction finished. Sold to {sender} for price {CurrentPrice}");
            FinalMessage = $"Auction finished. Sold to {sender} for price {CurrentPrice}.";
            Broadcast(Utils.Str("winner", sender));
            _timer.Stop();
            Stop();
        }

        private void HandleWakeUp()
        {
            CurrentPrice -= Constants.Increment;
            if (CurrentPrice < Constants.MinPrice)
            {
                Console.WriteLine($"[{this.Name}]: Auction finished. No winner.");
                FinalMessage = "Auction finished. No winner.";
                Broadcast(Utils.Str("winner", "none"));
            }
            else
            {
                Broadcast(Utils.Str("price", CurrentPrice));
            }
        }
    }
}
