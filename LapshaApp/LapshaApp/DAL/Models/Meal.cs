using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public class Meal
    {
        public Meal()
        {
            ProductMeals = new List<ProductMeal>();
        }

        public long MealId { get; set; }
        public long MealName { get; set; }
        public double MealProt { get; set; }
        public double MealFat { get; set; }
        public double MealCarb { get; set; }
        public long MealCalories { get; set; }

        public long DayId { get; set; }
        public Day Day { get; set; }
        public List<ProductMeal> ProductMeals { get; set; }
    }
}
