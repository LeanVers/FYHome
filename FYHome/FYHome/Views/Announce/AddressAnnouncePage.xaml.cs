using FYHome.Models;
using FYHome.ViewModels.Announce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FYHome.Views.Announce
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddressAnnouncePage : ContentPage
	{
		public AddressAnnouncePage ()
		{
			InitializeComponent ();
            BindingContext = new AddressAnnouncePageViewModel(this);
		}
	}
}