using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FYHome.Models;
using FYHome.Views;
using FYHome.ViewModels;

namespace FYHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel(this);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DetailResidentialPropertyPage((ResidencialProperty)args.SelectedItem)) {Title = "Detalhes do Imóvel", BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}