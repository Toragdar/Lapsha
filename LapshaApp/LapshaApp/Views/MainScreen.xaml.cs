using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LapshaApp
{
    public partial class MainScreen : ContentPage
    {
        public MainScreen()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        public ObservableCollection<TestDay> TestDays { get => GetTestDays(); }
        public class TestDay
        {
            public string Name { get; set; }
        }
    }
}
