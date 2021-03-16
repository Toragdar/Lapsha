using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace LapshaApp
{
    public static class Constants
    {
        public const string DATABASE_NAME = "LapshaDB.db";

        public static string DbPath
        {
            get
            {
                var dbPath = DependencyService.Get<IPath>().GetDatabasePath(DATABASE_NAME);
                return dbPath;
            }
        }
    }
}
