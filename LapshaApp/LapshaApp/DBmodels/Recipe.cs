using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class Recipe
    {
        public int Id { get; set; }
        public string recipeName { get; set; }
        public double prot { get; set; }
        public double fat { get; set; }
        public double carb { get; set; }
        public int calorie { get; set; }
        public List<ProductRecipes> ProductRecipes { get; set; }
        public Recipe()
        {
            ProductRecipes = new List<ProductRecipes>();
        }
    }
}
