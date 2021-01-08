using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Collections.Generic;

namespace LapshaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public const string DBFILENAME = "ProductsDB.db";
        public App()
        {            
            InitializeComponent();            
           
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);
            using (var db = new ApplicationContext(dbPath))
            {
                db.Database.EnsureCreated();
                if (db.Products.Count() == 0)
                    {
                        db.FirstStartFilling(dbPath);
                    }
            }
            MainPage = new NavigationPage(new WeekCarouselPage());
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
