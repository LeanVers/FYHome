using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using FYHome.Models;
using FYHome.Views;
using System.ComponentModel;
using System.Collections.Generic;
using FYHome.Services;
using FYHome.Util;
using System.Globalization;

namespace FYHome.ViewModels
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        #region
        private Page page;

        private List<ResidencialProperty> _resProp;
        public List<ResidencialProperty> ResProp
        {
            get { return _resProp; }
            set
            {
                _resProp = value;
                OnPropertyChanged("ResidencialProperty");
            }
        }
        #endregion

        public ItemsViewModel(Page page)
        {
            this.page = page;
            ResProp = ResidentialPropertyService.GetResidentialProperty();
        }

        public ItemsViewModel(Page page, List<ResidencialProperty> resProp)
        {
            this.page = page;
            this.ResProp = resProp;
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