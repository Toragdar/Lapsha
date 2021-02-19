using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Reflection;
using System.Linq;

namespace LapshaApp
{
    public partial class App : Application
    {        
        public App()
        {
            InitializeComponent();

            try
            {
                using (var db = new ApplicationContext(Constants.DbPath))
                {
                    db.Database.EnsureCreated();

                    if (db.Products.Count() == 0)
                    {
                        //Заполненение БД
                    }
                }
            }
            catch (Exception)
            {

            }

            MainPage = new NavigationPage(new CarouselOfDayScreens());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
