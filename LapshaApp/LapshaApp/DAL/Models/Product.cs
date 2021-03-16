using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public class Product
    {
        public Product()
        {
            ProductMeals = new List<ProductMeal>();
            ProductRecipes = new List<ProductRecipe>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductProt { get; set; }
        public double ProductFat { get; set; }
        public double ProductCarb { get; set; }
        public long ProductCalories { get; set; }
        public string ProductCategory { get; set; }

        public List<ProductMeal> ProductMeals { get; set; }
        public List<ProductRecipe> ProductRecipes { get; set; }
        public ShopList ShopList { get; set; }
        public Recipe Recipe { get; set; }

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
