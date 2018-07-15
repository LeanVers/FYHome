using FYHome.Models;
using FYHome.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FYHome.ViewModels.Announce
{   

    public class GeneralInfoAnnouncePageViewModel : INotifyPropertyChanged
    {
        private Page _page;
        public Page Page { get => _page; set => _page = value; }

        private ResidencialProperty _resProp;
        public ResidencialProperty ResProp { get { return _resProp; } set { _resProp = value; OnPropertyChanged("ResProp"); } }

        private TypeResidencialProperty _typeResProp;
        public TypeResidencialProperty TypeResProp { get { return _typeResProp; } set { _typeResProp = value; OnPropertyChanged("TypeResProp"); } }

        public Command RegisterResPropCommand { get; set; }

        public GeneralInfoAnnouncePageViewModel(Page page)
        {
            this.Page = page;
            ResProp = new ResidencialProperty();
            TypeResProp = new TypeResidencialProperty();
            RegisterResPropCommand = new Command(RegisterResProp);
        }

        private async void RegisterResProp()
        {

            this.ResProp.PersonId = Util.UserUtil.GetUserLogin().PersonId;

            if (this.TypeResProp.TypeResidencialPropertyId == -1)
            {
                await Page.DisplayAlert("Alerta", "Tipo de Imóvel não selecionado!", "OK");
            }
            else if (Util.UserUtil.GetAddressId() != 0)
            {
                this.ResProp.AddressId = Util.UserUtil.GetAddressId();

                var resid = ResidentialPropertyService.PostResidencialProperty(this.ResProp);
                if (resid == null)
                {
                    await Page.DisplayAlert("Alerta", "Ocorreu um erro!", "OK");
                }
                else
                {
                    await Page.DisplayAlert("Sucesso", "Cadastrado com sucesso!", "OK");
                    App.Current.MainPage = new NavigationPage(new Views.MainMasterPage()) { };
                }
            } else
            {
                await Page.DisplayAlert("Alerta", "Cadastre o endereço!", "OK");
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
