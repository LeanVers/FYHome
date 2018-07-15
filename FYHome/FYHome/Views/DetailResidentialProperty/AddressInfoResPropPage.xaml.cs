using FYHome.Models;
using FYHome.ViewModels;
using FYHome.ViewModels.DetailResidentialProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FYHome.Views.DetailResidentialProperty
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddressInfoResPropPage : ContentPage
	{
		public AddressInfoResPropPage (Address address)
		{
			InitializeComponent ();
            BindingContext = new AddressInfoResPropPageViewModel(address);
        }
	}
}