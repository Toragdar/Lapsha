using System;
using System.Collections.Generic;

#nullable disable

namespace DbTesting
{
    public partial class ProductMeal
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long MealId { get; set; }
        public long ProductWeight { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Product Product { get; set; }
    }
}
