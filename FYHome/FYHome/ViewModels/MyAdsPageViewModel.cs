using FYHome.Models;
using FYHome.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FYHome.ViewModels
{
    public class MyAdsPageViewModel : INotifyPropertyChanged
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

        public MyAdsPageViewModel(Page page)
        {
            this.page = page;
            int personId = Util.UserUtil.GetUserLogin().PersonId;
            ResProp = ResidentialPropertyService.GetResidentialPropertyByPersonId(personId);
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
