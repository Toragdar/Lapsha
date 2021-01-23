using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public partial class Recipe
    {
        public Recipe()
        {
            ProductRecipes = new HashSet<ProductRecipe>();
        }

        public long RecipeId { get; set; }
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<ProductRecipe> ProductRecipes { get; set; }
    }
}
