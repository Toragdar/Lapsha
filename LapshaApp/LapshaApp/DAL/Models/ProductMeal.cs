using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public class ProductMeal
    {
        //public long Id { get; set; }
        public long ProductWeight { get; set; }

        public long MealId { get; set; }
        public Meal Meal { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
