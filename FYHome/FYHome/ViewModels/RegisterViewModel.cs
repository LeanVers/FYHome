using FYHome.Models;
using FYHome.Services;
using FYHome.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FYHome.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        #region Properties
               
        private string _confirmPassphrase;
        private Page page;

        public string ConfirmPassphrase
        {
            get { return _confirmPassphrase; }
            set
            {
                _confirmPassphrase = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassphrase"));
            }
        }

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

        #endregion

        public Command RegisterUserCommand { get; set; }

        public RegisterViewModel(Page page)
        {
            this.page = page;
            this.Person = new Person();
            RegisterUserCommand = new Command(RegisterUser);
        }

        public Command UpdateUserCommand { get; set; }

        public RegisterViewModel(Page page, Person person)
        {
            this.page = page;

            this.Person = person;

            UpdateUserCommand = new Command(UpdateUser);
        }

        #region Metods

        private async void RegisterUser()
        {
            if (this.Person.Passphrase != ConfirmPassphrase)
            {
                await page.DisplayAlert("Alerta","Senhas não conferem!","OK");
            }
            else
            {               

                var userLogin = UserService.PostUser(this.Person);
                if (userLogin == null)
                {
                    await page.DisplayAlert("Alerta", "Ocorreu um erro ao registrar!", "OK");
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new Views.LoginPage()) { };
                }
            }
        }

        private async void UpdateUser()
        {
            if (this.Person.Passphrase != ConfirmPassphrase)
            {
                await page.DisplayAlert("Alerta", "Senhas não conferem!", "OK");
            }
            else
            {

                var userLogin = UserService.PutUser(this.Person);
                if (userLogin == null)
                {
                    await page.DisplayAlert("Alerta", "Ocorreu um erro ao registrar!", "OK");
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new Views.LoginPage()) { };
                }
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
