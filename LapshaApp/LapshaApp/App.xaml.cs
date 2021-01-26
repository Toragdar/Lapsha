using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Reflection;

namespace LapshaApp
{
    public partial class App : Application
    {        
        public App()
        {
            InitializeComponent();

            using (var db = new ApplicationContext(Constants.DbPath))
            {
                //проверка наличия БД, при ее отсутствии БД копируется
                if (!File.Exists(Constants.DbPath))
                {
                    var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;

                    using(Stream stream = assembly.GetManifestResourceStream($"LapshaApp.{Constants.DATABASE_NAME}"))
                    {
                        using (FileStream fileStream = new FileStream(Constants.DbPath, FileMode.OpenOrCreate))
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
