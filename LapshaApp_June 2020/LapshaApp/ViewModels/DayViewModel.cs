using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LapshaApp
{
    public class DayViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Day day;
        public List<Product> productList;
        public DayViewModel()
        {
            Day day = new Day();
        }
        public DayViewModel(string dbPath, string dName)
        {
            productList = new List<Product>();
            productList = DataServices.GetDaylyCalculatedProducts(dbPath, dName);
            day = DataServices.GetDay(dbPath, dName);
        }
        
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
