using AuctionsMobile.ViewModels.English;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuctionsMobile.Views.English
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnglishAuctionPage : ContentPage
    {
        public EnglishAuctionPage()
        {
            InitializeComponent();
            BindingContext = new EnglishAuctionViewModel();
        }
    }
}