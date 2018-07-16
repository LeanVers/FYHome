using FYHome.Models;
using FYHome.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FYHome.ViewModels
{
    public class SavedSearchListPageViewModel : INotifyPropertyChanged
    {
        Page _page;

        private List<RecordFilter> _recFilter;
        public List<RecordFilter> RecFilter
        {
            get { return _recFilter; }
            set
            {
                _recFilter = value;
                OnPropertyChanged("RecFilter");
            }
        }

        public SavedSearchListPageViewModel(Page page)
        {
            _page = page;

            RecFilter = ResidentialPropertyService.GetAllSearchSaved();
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
