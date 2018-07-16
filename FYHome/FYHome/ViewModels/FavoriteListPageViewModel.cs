using FYHome.Models;
using FYHome.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FYHome.ViewModels
{
    public class FavoriteListPageViewModel : INotifyPropertyChanged
    {
        Page _page;

        private List<Favorite> _favorite;
        public List<Favorite> Favorite
        {
            get { return _favorite; }
            set
            {
                _favorite = value;
                OnPropertyChanged("RecFilter");
            }
        }

        public FavoriteListPageViewModel(Page page)
        {
            _page = page;

            Favorite = ResidentialPropertyService.GetAllFavorites();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
