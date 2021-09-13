using ActressMas;
using System;
using System.Collections.Generic;

namespace AuctionsMobile.Auctions.Dutch
{
    public class BidderAgent : TurnBasedAgent
    {
        private int _valuation;

        public BidderAgent(int valuation)
        {
            this._valuation = valuation;
        }
        public override void Setup()
        {
            Console.WriteLine($"[{this.Name}]: My valuation is {_valuation}");
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
                    case "price":
                        HandlePrice(Convert.ToInt32(parameters));
                        break;

                    case "winner":
                        HandleWinner(parameters);
                        break;

                    default: break;
                }
            }
        }

        private void HandlePrice(int currentPrice)
        {
            if (currentPrice <= _valuation)
                Send("auctioneer", "bid");
        }

        private void HandleWinner(string winner)
        {
            if (winner == this.Name)
                Console.WriteLine($"[{this.Name}]: I have won.");

            //  Stop();
        }
    }
}
