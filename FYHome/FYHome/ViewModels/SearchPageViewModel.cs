using FYHome.Models;
using FYHome.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FYHome.ViewModels
{
    public class SearchPageViewModel : INotifyPropertyChanged
    {
        #region Properties

        private Page page;

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged("Person");
            }
        }

        private ResidencialProperty _resProp;
        public ResidencialProperty ResProp
        {
            get { return _resProp; }
            set
            {
                _resProp = value;
                OnPropertyChanged("ResProp");
            }
        }

        private Address _address;
        public Address Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        private TypeResidencialProperty _typeResidencialProperty;
        public TypeResidencialProperty TypeResidencialProperty
        {
            get { return _typeResidencialProperty; }
            set
            {
                _typeResidencialProperty = value;
                OnPropertyChanged("TypeResidencialProperty");
            }
        }

        #endregion

        public Command SearchCommand { get; set; }

        public SearchPageViewModel(Page page)
        {
            this.page = page;
            this.Person = new Person();
            SearchCommand = new Command(Search);
        }

        #region Metods

        private async void Search()
        {
            var listResProp = ResidentialPropertyService.Search(this.Person);
            if (listResProp == null)
            {
                await page.DisplayAlert("Alerta", "Ocorreu um erro pesquisar!", "OK");
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new Views.ItemsPage(listResProp)) { Title = "Pesquisa", BarBackgroundColor = Color.FromHex("#551A8B"), BarTextColor = Color.Lavender };
            }
        }

        #endregion

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
