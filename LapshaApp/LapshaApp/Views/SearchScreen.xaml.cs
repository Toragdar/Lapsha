using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LapshaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchScreen : ContentPage
    {
        public SearchScreen()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private async void ClearEntryField(object sender, EventArgs e)
        {

        }
    }
}