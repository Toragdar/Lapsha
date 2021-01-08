using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class ProductRecipes
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; }
        public int recipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
