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
    public partial class CarouselOfDayScreens : CarouselPage
    {
        public CarouselOfDayScreens()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            List<Product> prodList = new List<Product>();
            prodList = DbDataService.GetAllProductsFromDb();

            ProductList.ItemsSource = prodList;

            base.OnAppearing();
        }
    }
}

//< Label Text = "{Binding ProductId}" ></ Label >
// 
//                 < Label Text = "{Binding ProductName}" ></ Label >
//  
//                  < Label Text = "{Binding ProductProt}" ></ Label >
//   
//                   < Label Text = "{Binding ProductFat}" ></ Label >
//    
//                    < Label Text = "{Binding ProductCarb}" ></ Label >
//     
//                     < Label Text = "{Binding ProductCalories}" ></ Label >
//      
//                      < Label Text = "{Binding ProductCategory}" ></ Label >