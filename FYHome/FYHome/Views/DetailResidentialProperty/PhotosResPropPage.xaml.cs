using FYHome.ViewModels;
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
	public partial class PhotosResPropPage : ContentPage
	{
		public PhotosResPropPage ()
		{
			InitializeComponent ();
            BindingContext = new ItemsViewModel(this);
        }
	}
}