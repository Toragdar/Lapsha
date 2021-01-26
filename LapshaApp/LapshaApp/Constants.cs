using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LapshaApp
{
    public static class Constants
    {
        public const string DATABASE_NAME = "LapshaDB.db";

        public static string DbPath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DATABASE_NAME);
            }
        }
    }
}
