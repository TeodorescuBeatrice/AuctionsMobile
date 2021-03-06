using AuctionsMobile.Helpers;
using AuctionsMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionsMobile.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="", AuctionType = AuctionType.Dutch },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="", AuctionType = AuctionType.English },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="", AuctionType = AuctionType.Blind },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="", AuctionType = AuctionType.Vickrey },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="", AuctionType = AuctionType.English },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="", AuctionType = AuctionType.Blind }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(AuctionType auctionType, bool forceRefresh = false)
        {
            return await Task.FromResult(items.Where(x => x.AuctionType == auctionType));
        }
    }
}