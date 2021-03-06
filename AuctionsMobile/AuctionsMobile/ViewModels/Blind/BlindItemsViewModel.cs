using AuctionsMobile.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuctionsMobile.ViewModels.Blind
{
    public class BlindItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public BlindItemsViewModel()
        {
            Title = "Join an auction";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(Helpers.AuctionType.Blind, true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
