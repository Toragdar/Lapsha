using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public partial class Meal
    {
        public Meal()
        {
            ProductMeals = new HashSet<ProductMeal>();
        }

        public long MealId { get; set; }
        public long DayId { get; set; }
        public long MealName { get; set; }
        public double MealProt { get; set; }
        public double MealFat { get; set; }
        public double MealCarb { get; set; }
        public long MealCalories { get; set; }

        public virtual Day Day { get; set; }
        public virtual ICollection<ProductMeal> ProductMeals { get; set; }
    }
}
