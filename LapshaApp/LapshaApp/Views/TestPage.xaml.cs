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
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }
        private async void SaveNewProduct(object sender, EventArgs e)
        {
            popupConfirmAddition.IsVisible = true;
        }
        private async void DontSaveNewProduct(object sender, EventArgs e)
        {


        }
        private async void AddNewProductToCurrentDay(object sender, EventArgs e)
        {
            popupConfirmAddition.IsVisible = false;
            popupAddProductToDay.IsVisible = true;
        }
    }
}