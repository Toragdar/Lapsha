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
    public partial class ProductsTest : ContentPage
    {
        public ProductsTest()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            ProductTestViewModel TestViewModel = new ProductTestViewModel();
            TestLabel.BindingContext = TestViewModel.pr.ProductName;

            base.OnAppearing();
        }
    }
}