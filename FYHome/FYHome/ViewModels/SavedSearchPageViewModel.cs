using FYHome.Models;
using FYHome.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FYHome.ViewModels
{
    public class SavedSearchPageViewModel : INotifyPropertyChanged
    {

        private Page page;

        private RecordFilter _recFilter;
        public RecordFilter RecFilter { get { return _recFilter; } set { _recFilter = value; OnPropertyChanged("Address"); } }

        public Command RegisterRecFilterCommand { get; set; }

        public SavedSearchPageViewModel(Page page)
        {
            this.RecFilter = new RecordFilter();
            this.page = page;
            RegisterRecFilterCommand = new Command(RegisterRecFilter);
        }

        private async void RegisterRecFilter()
        {
            var rec = ResidentialPropertyService.PostSearch(this.RecFilter);
            if (rec == null)
            {
                await page.DisplayAlert("Alerta", "Ocorreu um erro!", "OK");
            }
            else
            {
                await page.DisplayAlert("Sucesso", "Cadastrado com sucesso!", "OK");
                App.Current.MainPage = new NavigationPage(new Views.MainMasterPage());
            }
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
