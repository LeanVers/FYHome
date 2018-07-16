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
    public partial class MainMasterPage : MasterDetailPage
    {
        public MainMasterPage()
        {
            InitializeComponent();
        }

        private async void GoAnnouncePage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AnnouncePage()) { Title="Anunciar", BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
            IsPresented = false;
        }

        private async void GoMyAdsPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MyAdsPage()) { Title = "Meus Anúncios", BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
            IsPresented = false;
        }
        
        private async void GoFavoritePage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new FavoriteListPage()) { Title = "Favoritos", BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
            IsPresented = false;
        }

        private async void GoSavedSearchPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SavedSearchListPage()) { Title = "Pesquisa Salva", BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
            IsPresented = false;
        }

        private async void GoProfilePage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RegisterPage(Util.UserUtil.GetUserLogin())) { BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
            IsPresented = false;
        }

        private async void GoAboutPage(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AboutPage()) { BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender });
            IsPresented = false;
        }
    }
}