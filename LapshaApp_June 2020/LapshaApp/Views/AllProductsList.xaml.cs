using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.EntityFrameworkCore;

namespace LapshaApp
{    
    public partial class AllProductsList : ContentPage
    {
        public const string DBFILENAME = "ProductsDB.db";
        string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);
        string dName;  
        public AllProductsList(string _dName)
        {
            dName = _dName; 
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            List<Product> buf = new List<Product>();
            buf = DataServices.GetAllProducts(dbPath);

            var sortedbuf = from u in buf
                              orderby u.productName
                              select u;

            ProductList.ItemsSource = sortedbuf;
            base.OnAppearing();
        }

        private async void CreateProduct(object sender, EventArgs e)
        {
            Product product = new Product();
            ProductPage productPage = new ProductPage();
            productPage.BindingContext = product;
            await Navigation.PushAsync(productPage);
        }
        
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            double weight;
            Product pr = new Product();
            pr = (Product)e.SelectedItem;
            string result = await DisplayPromptAsync("", "Введите вес продукта");
            Double.TryParse(result, out weight);
            
            DataServices.AddProductToDay(dbPath, pr.productName, dName, weight);

            await Navigation.PopAsync();
        }
    }
}