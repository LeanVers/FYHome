using FYHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FYHome.ViewModels.DetailResidentialProperty
{
    public class GeneralInfoResPropPageViewModel : INotifyPropertyChanged
    {
        private ResidencialProperty _resProp;
        public ResidencialProperty ResProp
        {
            get { return _resProp; }
            set
            {
                _resProp = value;
            }
        }

        public GeneralInfoResPropPageViewModel(ResidencialProperty resProp)
        {
            this.ResProp = resProp;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
