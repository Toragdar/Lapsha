using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LapshaApp
{
    [DesignTimeVisible(false)]
    public partial class MainScreen : ContentPage
    {
        public MainScreen()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        public ObservableCollection<TestDay> TestDays { get => GetTestDays(); }

        private ObservableCollection<TestDay> GetTestDays()
        {
            return new ObservableCollection<TestDay>
            {
                new TestDay{DayName = "Monday", TestProducts = new ObservableCollection<TestProduct>
                    {
                        new TestProduct {ProductName = "Potato", ProductWeight = 100},
                        new TestProduct {ProductName = "Tomato", ProductWeight = 150}
                    }
                },
                new TestDay{DayName = "Tuesday", TestProducts = new ObservableCollection<TestProduct>
                    {
                        new TestProduct {ProductName = "Egg", ProductWeight = 50},
                        new TestProduct {ProductName = "Salad", ProductWeight = 200}
                    }
                }
            };
        }
        public class TestDay
        {
            public string DayName { get; set; }
            public ObservableCollection<TestProduct> TestProducts { get; set; }

        }
        public class TestProduct
        {
            public string ProductName { get; set; }
            public int ProductWeight { get; set; }
        }
    }
}
