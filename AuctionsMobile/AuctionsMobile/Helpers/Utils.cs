using ActressMas;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionsMobile.Helpers
{
    public class Utils
    {
        public static string Str(object p1, object p2)
        {
            return string.Format("{0} {1}", p1, p2);
        }

        //public static void InitAgents(AuctionType auctionType)
        //{
        //    var env = new TurnBasedEnvironment(0, 200);

        //    for (int i = 1; i <= Constants.NoBidders; i++)
        //    {
        //        int agentValuation = Constants.MinPrice + Constants.RandNoGen.Next(Constants.MaxPrice - Constants.MinPrice);
        //        var bidderAgent = CreateBidder(auctionType, agentValuation);// new BidderAgent(agentValuation);
        //        env.Add(bidderAgent, string.Format("bidder{0:D2}", i));
        //    }

        //    var auctioneerAgent = CreateAuctioneer(auctionType); // new AuctioneerAgent();
        //    env.Add(auctioneerAgent, "auctioneer");

        //    env.Start();
        //}

        //public static TurnBasedAgent CreateBidder(AuctionType auctionType, int valuation)
        //{
        //    switch (auctionType)
        //    {
        //        case AuctionType.Blind: return new Auctions.Blind.BidderAgent(valuation);
        //        //case AuctionType.Dutch: return new Dutch.BidderAgent(valuation);
        //        //case AuctionType.English: return new English.BidderAgent(valuation);
        //        //case AuctionType.Vickrey: return new Vickrey.BidderAgent(valuation);
        //        default: return null;
        //    }
        //}

        //public static TurnBasedAgent CreateAuctioneer(AuctionType auctionType)
        //{
        //    switch (auctionType)
        //    {
        //        case AuctionType.Blind: return new Auctions.Blind.AuctioneerAgent();
        //        //case AuctionType.Dutch: return new Dutch.AuctioneerAgent();
        //        //case AuctionType.English: return new English.AuctioneerAgent();
        //        //case AuctionType.Vickrey: return new Vickrey.AuctioneerAgent();
        //        default: return null;
        //    }
        //}
    }
}
