using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class RecipeDays
    {
        public int Id { get; set; }
        public string idDayName { get; set; }
        public Day Day { get; set; }
        public string idRecipeName { get; set; }
        public Recipe Recipe { get; set; }
    }
}
