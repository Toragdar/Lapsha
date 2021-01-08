using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class Product
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public double prot { get; set; }
        public double fat { get; set; }
        public double carb { get; set; }
        public int calorie { get; set; }
        public int category { get; set; }
        public List<ProductDays> ProductDays { get; set; }
        public List<ProductRecipes> ProductRecipes { get; set; }
        public Product()
        {
            ProductDays = new List<ProductDays>();
            ProductRecipes = new List<ProductRecipes>();
        }
    }
}
