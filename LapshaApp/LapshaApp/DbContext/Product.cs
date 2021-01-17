using System;
using System.Collections.Generic;


namespace LapshaApp
{
    public partial class Product
    {
        public Product()
        {
            ProductDays = new HashSet<ProductDay>();
            ProductRecipes = new HashSet<ProductRecipe>();
            ShopLists = new HashSet<ShopList>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double Prot { get; set; }
        public double Fat { get; set; }
        public double Carb { get; set; }
        public long Calorie { get; set; }
        public string Category { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual ICollection<ProductDay> ProductDays { get; set; }
        public virtual ICollection<ProductRecipe> ProductRecipes { get; set; }
        public virtual ICollection<ShopList> ShopLists { get; set; }
    }
}
