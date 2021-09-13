using ActressMas;
using System;
using System.Collections.Generic;

namespace AuctionsMobile.Auctions.Blind
{
    public class BidderAgent : TurnBasedAgent
    {
        private int _valuation;

        public BidderAgent(int val)
        {
            _valuation = val;
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
                    case "start":
                        HandleStart();
                        break;

                    case "winner":
                        HandleWinner(parameters);
                        break;

                    default:
                        break;
                }
            }
        }

        private void HandleStart()
        {
            Send("auctioneer", $"bid {_valuation}");
        }

        private void HandleWinner(string winner)
        {
            if (winner == this.Name)
                Console.WriteLine($"[{this.Name}]: I have won.");

            Stop();
        }
    }
}
