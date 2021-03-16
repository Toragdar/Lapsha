using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class ProductRecipes
    {
        public int productId { get; set; }
        public Product Product { get; set; }

        public int recipeId { get; set; }
        public Recipe Recipe { get; set; }

        public double weight { get; set; }
    }
}
