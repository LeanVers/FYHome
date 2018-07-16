using FYHome.Models;
using FYHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FYHome.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoriteListPage : ContentPage
	{
		public FavoriteListPage ()
		{
			InitializeComponent ();
            BindingContext = new FavoriteListPageViewModel(this);
        }

        private async Task ItemsListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DetailResidentialPropertyPage(((Favorite)args.SelectedItem).ResidecialProperty)) { Title = "Detalhes do Imóvel", BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
        }
    }
}