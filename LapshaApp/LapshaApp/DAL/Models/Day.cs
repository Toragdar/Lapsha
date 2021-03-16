using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public class Day
    {
        public Day()
        {
            Meals = new List<Meal>();
        }

        public long DayId { get; set; }
        public string DayName { get; set; }
        public double Prot { get; set; }
        public double Fat { get; set; }
        public double Carb { get; set; }
        public long Calorie { get; set; }

        public List<Meal> Meals { get; set; }
    }
}
