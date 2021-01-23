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
    public partial class ProductPage : ContentPage
    {
        public const string DBFILENAME = "ProductsDB.db";
        string dbPath;
        public ProductPage()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);
        }
        private async void SaveProduct(object sender, EventArgs e)  
        {
            var product = (Product)BindingContext;
            if (!String.IsNullOrEmpty(product.productName))
            {
                DataServices.AddProductToDB(dbPath, product);
            }
            await Navigation.PopAsync();
        }
    }
}