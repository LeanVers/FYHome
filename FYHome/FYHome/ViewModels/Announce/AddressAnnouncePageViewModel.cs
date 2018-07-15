using FYHome.Models;
using FYHome.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FYHome.ViewModels.Announce
{
    public class AddressAnnouncePageViewModel : INotifyPropertyChanged
    {
        private Page _page;
        public Page Page { get => _page; set => _page = value; }

        private Address _address;
        public Address Address { get { return _address; } set { _address = value; OnPropertyChanged("Address"); } }

        public Command RegisterAddressCommand { get; set; }

        public AddressAnnouncePageViewModel(Page page)
        {
            this.Page = page;
            this.Address = new Address();
            RegisterAddressCommand = new Command(RegisterAddress);
        }

        private async void RegisterAddress()
        {
            var addr = AddressService.PostAddress(this.Address);
            if (addr == null)
            {
                await Page.DisplayAlert("Alerta", "Ocorreu um erro!", "OK");
            }
            else
            {
                await Page.DisplayAlert("Sucesso", "Cadastrado com sucesso!", "OK");
                Util.UserUtil.SetAddressId(addr.AddressId);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
