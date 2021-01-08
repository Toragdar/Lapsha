using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public partial class WeekCarouselPage : CarouselPage
    {
        string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        public WeekCarouselPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            DayViewModel Monday = new DayViewModel(dbPath, "Monday");
            Mon.BindingContext = Monday.day;
            MondayList.ItemsSource = Monday.productList;

            DayViewModel Tuesday = new DayViewModel(dbPath, "Tuesday");
            Tue.BindingContext = Tuesday.day;
            TuesdayList.ItemsSource = Tuesday.productList;

            DayViewModel Wednesday = new DayViewModel(dbPath, "Wednesday");
            Wed.BindingContext = Wednesday.day;
            WednesdayList.ItemsSource = Wednesday.productList;

            DayViewModel Thursday = new DayViewModel(dbPath, "Thursday");
            Thu.BindingContext = Thursday.day;
            ThursdayList.ItemsSource = Thursday.productList;

            DayViewModel Friday = new DayViewModel(dbPath, "Friday");
            Fri.BindingContext = Friday.day;
            FridayList.ItemsSource = Friday.productList;

            DayViewModel Saturday = new DayViewModel(dbPath, "Saturday");
            Sat.BindingContext = Saturday.day;
            SaturdayList.ItemsSource = Saturday.productList;

            DayViewModel Sunday = new DayViewModel(dbPath, "Sunday");
            Sun.BindingContext = Sunday.day;
            SundayList.ItemsSource = Sunday.productList;

            base.OnAppearing();
        }
        private async void AddProductToMonday(object sender, EventArgs e)
        {
            Day day = (Day)Mon.BindingContext;
            AllProductsList prodList = new AllProductsList(day.dayName);
            await Navigation.PushAsync(prodList);
        }
        private async void AddProductToTuesday(object sender, EventArgs e)
        {
            Day day = (Day)Tue.BindingContext;
            AllProductsList prodList = new AllProductsList(day.dayName);
            await Navigation.PushAsync(prodList);
        }
        private async void AddProductToWednesday(object sender, EventArgs e)
        {
            Day day = (Day)Wed.BindingContext;
            AllProductsList prodList = new AllProductsList(day.dayName);
            await Navigation.PushAsync(prodList);
        }
        private async void AddProductToThursday(object sender, EventArgs e)
        {
            Day day = (Day)Thu.BindingContext;
            AllProductsList prodList = new AllProductsList(day.dayName);
            await Navigation.PushAsync(prodList);
        }
        private async void AddProductToFriday(object sender, EventArgs e)
        {
            Day day = (Day)Fri.BindingContext;
            AllProductsList prodList = new AllProductsList(day.dayName);
            await Navigation.PushAsync(prodList);
        }
        private async void AddProductToSaturday(object sender, EventArgs e)
        {
            Day day = (Day)Sat.BindingContext;
            AllProductsList prodList = new AllProductsList(day.dayName);
            await Navigation.PushAsync(prodList);
        }
        private async void AddProductToSunday(object sender, EventArgs e)
        {
            Day day = (Day)Sun.BindingContext;
            AllProductsList prodList = new AllProductsList(day.dayName);
            await Navigation.PushAsync(prodList);
        }
        private async void MondayOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Day day = (Day)Mon.BindingContext;
            Product pr = new Product();
            pr = (Product)e.SelectedItem;
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить продукт?", "Да", "Нет");
            switch (result)
            {
                case true:
                    DataServices.DeleteProductFromDay(dbPath, pr.productName, day.dayName);
                    break;
                case false:
                    break;

            }
            Refr refr = new Refr();
            await Navigation.PushAsync(refr);
            await Navigation.PopAsync();
        }
        private async void TuesdayOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Day day = (Day)Tue.BindingContext;
            Product pr = new Product();
            pr = (Product)e.SelectedItem;
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить продукт?", "Да", "Нет");
            switch (result)
            {
                case true:
                    DataServices.DeleteProductFromDay(dbPath, pr.productName, day.dayName);
                    break;
                case false:
                    break;

            }
            Refr refr = new Refr();
            await Navigation.PushAsync(refr);
            await Navigation.PopAsync();
        }
        private async void WednesdayOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Day day = (Day)Wed.BindingContext;
            Product pr = new Product();
            pr = (Product)e.SelectedItem;
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить продукт?", "Да", "Нет");
            switch (result)
            {
                case true:
                    DataServices.DeleteProductFromDay(dbPath, pr.productName, day.dayName);
                    break;
                case false:
                    break;

            }
            Refr refr = new Refr();
            await Navigation.PushAsync(refr);
            await Navigation.PopAsync();
        }
        private async void ThursdayOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Day day = (Day)Thu.BindingContext;
            Product pr = new Product();
            pr = (Product)e.SelectedItem;
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить продукт?", "Да", "Нет");
            switch (result)
            {
                case true:
                    DataServices.DeleteProductFromDay(dbPath, pr.productName, day.dayName);
                    break;
                case false:
                    break;

            }
            Refr refr = new Refr();
            await Navigation.PushAsync(refr);
            await Navigation.PopAsync();
        }
        private async void FridayOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Day day = (Day)Fri.BindingContext;
            Product pr = new Product();
            pr = (Product)e.SelectedItem;
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить продукт?", "Да", "Нет");
            switch (result)
            {
                case true:
                    DataServices.DeleteProductFromDay(dbPath, pr.productName, day.dayName);
                    break;
                case false:
                    break;

            }
            Refr refr = new Refr();
            await Navigation.PushAsync(refr);
            await Navigation.PopAsync();
        }
        private async void SaturdayOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Day day = (Day)Sat.BindingContext;
            Product pr = new Product();
            pr = (Product)e.SelectedItem;
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить продукт?", "Да", "Нет");
            switch (result)
            {
                case true:
                    DataServices.DeleteProductFromDay(dbPath, pr.productName, day.dayName);
                    break;
                case false:
                    break;

            }
            Refr refr = new Refr();
            await Navigation.PushAsync(refr);
            await Navigation.PopAsync();
        }
        private async void SundayOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Day day = (Day)Sun.BindingContext;
            Product pr = new Product();
            pr = (Product)e.SelectedItem;
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить продукт?", "Да", "Нет");
            switch (result)
            {
                case true:
                    DataServices.DeleteProductFromDay(dbPath, pr.productName, day.dayName);
                    break;
                case false:
                    break;

            }
            Refr refr = new Refr();
            await Navigation.PushAsync(refr);
            await Navigation.PopAsync();
        }
    }
}