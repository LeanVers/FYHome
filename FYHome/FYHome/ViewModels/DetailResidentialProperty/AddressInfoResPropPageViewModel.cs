using FYHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FYHome.ViewModels.DetailResidentialProperty
{
    public class AddressInfoResPropPageViewModel : INotifyPropertyChanged
    {
        private Address _address;
        public Address Address
        {
            get { return _address; }
            set
            {
                _address = value;
            }
        }

        public AddressInfoResPropPageViewModel(Address address)
        {
            this.Address = address;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
