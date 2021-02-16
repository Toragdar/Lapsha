using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public partial class Day
    {
        public Day()
        {
            Meals = new HashSet<Meal>();
        }

        public long DayId { get; set; }
        public string DayName { get; set; }
        public double Prot { get; set; }
        public double Fat { get; set; }
        public double Carb { get; set; }
        public long Calorie { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
