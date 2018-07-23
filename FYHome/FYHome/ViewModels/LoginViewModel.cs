using FYHome.Models;
using FYHome.Services;
using FYHome.Util;
using FYHome.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FYHome.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region properties
        private string _email;
        private string _passphrase;
        private string _message;
        private Page page;


        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        public string PassPhrase
        {
            get { return _passphrase; }
            set
            {
                _passphrase = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PassPhrase"));
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            }
        }

        #endregion

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel(Page page)
        {
            this.page = page;
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
        }

        private void Register()
        {
            App.Current.MainPage = new RegisterPage();
        }

        private void Login()
        {
            var user = new Person
            {
                Email = Email,
                Passphrase = PassPhrase
            };

            if (user != null && (user.Email != null && user.Passphrase != null) && (user.Email.Trim() != "" && user.Passphrase.Trim() != ""))
            {
                var userLogin = UserService.GetUser(user);
                if (userLogin == null)
                {
                    page.DisplayAlert("Alerta!", "Dados de login incorretos. Cadatsre-se no sistema ou digite dados corretos.", "OK");
                }
                else
                {
                    UserUtil.SetUserLogin(userLogin);

                    App.Current.MainPage = new MainMasterPage();

                }
            } else
            {
                page.DisplayAlert("Alerta!", "Dados de login incorretos. Cadatsre-se no sistema ou digite dados corretos.", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
