using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LapshaApp
{
    public static class DbDataService
    {
        public static Day GetDay(string _dayName)
        {
            Day buf = new Day();

            using (var db = new ApplicationContext(DependencyService.Get<IPath>().GetDatabasePath(DATABASE_NAME)))

            return buf;
        }
    }
}
