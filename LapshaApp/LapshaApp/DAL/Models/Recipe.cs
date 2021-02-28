using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public class Recipe
    {
        public Recipe()
        {
            ProductRecipes = new List<ProductRecipe>();
        }

        public long RecipeId { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public List<ProductRecipe> ProductRecipes { get; set; }
    }
}
