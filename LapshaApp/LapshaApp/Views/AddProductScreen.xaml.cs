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
    public partial class AddProductScreen : ContentPage
    {
        public AddProductScreen()
        {
            InitializeComponent();
        }
        private async void ClearEntryField(object sender, EventArgs e)
        {

        }
        private async void SaveNewProduct(object sender, EventArgs e)
        {
            popupConfirmAddition.IsVisible = true;
            
        }
        private async void DontSaveNewProduct(object sender, EventArgs e)
        {

            //Возврат на страницу поиска
        }
        private async void AddNewProductToCurrentDay(object sender, EventArgs e)
        {
            popupConfirmAddition.IsVisible = false;
            popupAddProductToDay.IsVisible = true;
        }

        private async void DontAddNewProductToCurrentDay(object sender, EventArgs e)
        {
            popupConfirmAddition.IsVisible = false;
        }

        private async void SaveNewProductToCurrentDay(object sender, EventArgs e)
        {
            popupAddProductToDay.IsVisible = false;
        }

        private async void DontSaveNewProductToCurrentDay(object sender, EventArgs e)
        {
            popupAddProductToDay.IsVisible = false;
        }

    }
}

