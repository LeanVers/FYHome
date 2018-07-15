using FYHome.Models;
using FYHome.Views.Announce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FYHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnnouncePage : TabbedPage
    {
        private ResidencialProperty _resProp;
        public ResidencialProperty ResProp { get => _resProp; set => _resProp = value; }

        public AnnouncePage ()
        {
            InitializeComponent();
            this.Children.Add(new AddressAnnouncePage() { Title = "Endereço" });
            this.Children.Add(new GeneralInfoAnnouncePage() { Title = "Info Gerais" });            
            this.Children.Add(new PhotosAnnouncePage() { Title = "Fotos" });
        }

        
    }
}