using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public partial class Product
    {
        public Product()
        {
            ProductMeals = new HashSet<ProductMeal>();
            ProductRecipes = new HashSet<ProductRecipe>();
            ShopLists = new HashSet<ShopList>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductProt { get; set; }
        public double ProductFat { get; set; }
        public double ProductCarb { get; set; }
        public long ProductCalories { get; set; }
        public string ProductCategory { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual ICollection<ProductMeal> ProductMeals { get; set; }
        public virtual ICollection<ProductRecipe> ProductRecipes { get; set; }
        public virtual ICollection<ShopList> ShopLists { get; set; }

        public void Calculate(int weight)
        {
            double weightCoeficient = weight / 100;
            this.ProductProt = Math.Round(this.ProductProt * weightCoeficient, 1);
            this.ProductFat = Math.Round(this.ProductFat * weightCoeficient, 1);
            this.ProductCarb = Math.Round(this.ProductCarb * weightCoeficient, 1);
            this.ProductCalories = Convert.ToInt64(Math.Round(this.ProductCalories * weightCoeficient));
        }
    }
}
