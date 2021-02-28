using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LapshaApp
{
    public class ProductTestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Product> productList;
        public Product pr;
        public ProductTestViewModel()
        {
            productList = new List<Product>();
            productList = DbDataService.GetAllProductsFromDb();
            pr = new Product();
            pr = DbDataService.GetProductFromDb("Лук");
        }
        
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
