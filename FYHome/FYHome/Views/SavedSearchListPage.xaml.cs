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
	public partial class SavedSearchListPage : ContentPage
	{
		public SavedSearchListPage ()
		{
			InitializeComponent ();
            BindingContext = new SavedSearchListPageViewModel(this);
        }

        private async Task ToolbarItem_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SavedSearchPage()) { Title = "Cadastrar Pesquisa", BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
        }
    }
}