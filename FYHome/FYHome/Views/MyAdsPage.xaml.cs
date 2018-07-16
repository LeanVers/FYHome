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
	public partial class MyAdsPage : ContentPage
	{
		public MyAdsPage ()
		{
			InitializeComponent ();
            BindingContext = new MyAdsPageViewModel(this);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DetailResidentialPropertyPage((ResidencialProperty)args.SelectedItem)) { Title = "Detalhes do Imóvel", BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
        }
        
    }
}