using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<TestProduct> TestProducts { get => GetTestProducts(); }
        public SearchScreen()
        {            
            InitializeComponent();
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            
            base.OnAppearing();
        }
        private async void ClearEntryField(object sender, EventArgs e)
        {

        }
        private async void CreateNewProduct(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddProductScreen());
        }
        private async void AddNewProductToCurrentDay(object sender, EventArgs e)
        {
            popupAddProductToDay.IsVisible = true;
        }
        private async void SaveNewProductToCurrentDay(object sender, EventArgs e)
        {
            Products.SelectedItem = null;
            popupAddProductToDay.IsVisible = false;
        }

        private async void DontSaveNewProductToCurrentDay(object sender, EventArgs e)
        {
            Products.SelectedItem = null;
            popupAddProductToDay.IsVisible = false;
        }

        #region MockData

        private ObservableCollection<TestProduct> GetTestProducts()
        {
            ObservableCollection<TestProduct> testProducts = new ObservableCollection<TestProduct>
            {
                new TestProduct {ProductName = "Potato", ProductProt = 15, ProductFat = 5, ProductCarb = 50, ProductCallories = 55},
                new TestProduct {ProductName = "Tomato", ProductProt = 10, ProductFat = 2, ProductCarb = 15, ProductCallories = 55},
                new TestProduct {ProductName = "Egg", ProductProt = 15, ProductFat = 5, ProductCarb = 50, ProductCallories = 55},
                new TestProduct {ProductName = "Salad", ProductProt = 10, ProductFat = 2, ProductCarb = 15, ProductCallories = 55},
                new TestProduct {ProductName = "Bread", ProductProt = 10, ProductFat = 2, ProductCarb = 15, ProductCallories = 55},
                new TestProduct {ProductName = "Meat", ProductProt = 10, ProductFat = 2, ProductCarb = 15, ProductCallories = 55},
                new TestProduct {ProductName = "Cucumber", ProductProt = 10, ProductFat = 2, ProductCarb = 15, ProductCallories = 55},
                new TestProduct {ProductName = "Onion", ProductProt = 10, ProductFat = 2, ProductCarb = 15, ProductCallories = 55},
                new TestProduct {ProductName = "Milk", ProductProt = 10, ProductFat = 2, ProductCarb = 15, ProductCallories = 55},
                new TestProduct {ProductName = "Sugar", ProductProt = 10, ProductFat = 2, ProductCarb = 15, ProductCallories = 55}
            };

            return testProducts;
        }

        public class TestProduct
        {
            public string ProductName { get; set; }
            public double ProductProt { get; set; }
            public double ProductFat { get; set; }
            public double ProductCarb { get; set; }
            public int ProductCallories { get; set; }
            public TestProduct()
            {
                ProductProt = 0;
                ProductFat = 0;
                ProductCarb = 0;
                ProductCallories = 0;
            }
        }

        #endregion
    }
}