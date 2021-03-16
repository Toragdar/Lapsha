using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class RecipeDays
    {
        public int recipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int dayId { get; set; }
        public Day Day { get; set; }

        public double weight { get; set; }
    }
}
