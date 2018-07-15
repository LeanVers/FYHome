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

        private string _name;
        private string _email;
        private string _birthday;
        private string _cpf;
        private string _phone;
        private string _passphrase;
        private string _confirmPassphrase;
        private string _message;
        private Page page;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public string Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Birthday"));
            }
        }

        public string CPF
        {
            get { return _cpf; }
            set
            {
                _cpf = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CPF"));
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Phone"));
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

        public string ConfirmPassphrase
        {
            get { return _confirmPassphrase; }
            set
            {
                _confirmPassphrase = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassphrase"));
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

        public Command RegisterUserCommand { get; set; }

        public RegisterViewModel(Page page)
        {
            this.page = page;
            RegisterUserCommand = new Command(RegisterUser);
        }

        private async void RegisterUser()
        {
            if (PassPhrase != ConfirmPassphrase)
            {
                await page.DisplayAlert("Alerta","Senhas não conferem!","OK");
            }
            else
            {
                var user = new Person
                {
                    Name = Name,
                    Email = Email,
                    BirthdayDate = DateTime.Parse(Birthday),
                    CPF = CPF,
                    Phone = Phone,
                    Passphrase = PassPhrase
                };

                var userLogin = UserService.PostUser(user);
                if (userLogin == null)
                {
                    Message = "Ocorreu um erro ao registrar";
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new Views.LoginPage()) { };
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
