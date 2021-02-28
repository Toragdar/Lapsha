using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public class ProductRecipe
    {
        public long Id { get; set; }
        public long ProductWeight { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
