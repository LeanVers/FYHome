using FYHome.Models;
using FYHome.ViewModels;
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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
            BindingContext = new RegisterViewModel(this);
        }

        public RegisterPage(Person person)
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel(this, person);
        }
    }
}