using System;
using System.Collections.Generic;

#nullable disable

namespace DbTesting
{
    public partial class ProductRecipe
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? RecipeId { get; set; }
        public long? Weight { get; set; }

        public virtual Product Product { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
