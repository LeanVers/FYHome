using FYHome.Models;
using FYHome.Views.DetailResidentialProperty;
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
    public partial class DetailResidentialPropertyPage : TabbedPage
    {
        public DetailResidentialPropertyPage (ResidencialProperty ResProp)
        {
            InitializeComponent();
            this.Children.Add(new GeneralInfoResPropPage(ResProp) { Title = "Info Gerais"});
            this.Children.Add(new AddressInfoResPropPage(ResProp.Address) { Title = "Endereço" });
            this.Children.Add(new PhotosResPropPage() { Title = "Fotos" });
        }

    }
}