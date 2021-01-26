using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Reflection;

namespace LapshaApp
{
    public partial class App : Application
    {
        //public const string DATABASE_NAME = "LapshaDB.db";
        public App()
        {
            InitializeComponent();

            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DATABASE_NAME);
            using (var db = new ApplicationContext(dbPath))
            {
                //проверка наличия БД, при ее отсутствии БД копируется
                if (!File.Exists(dbPath))
                {
                    var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;

                    using(Stream stream = assembly.GetManifestResourceStream($"LapshaApp.{DATABASE_NAME}"))
                    {
                        using (FileStream fileStream = new FileStream(dbPath, FileMode.OpenOrCreate))
                        {
                            stream.CopyTo(fileStream);
                            fileStream.FlushAsync();
                        }
                    }
                }
            }

                MainPage = new MainPage();
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
