using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class Recipe
    {
        public Recipe()
        {
            ProductRecipes = new List<ProductRecipes>();
            RecipeDays = new List<RecipeDays>();
            recipeProt = 0;
            recipeFat = 0;
            recipeCarb = 0;
            recipeCalorie = 0;
        }
        public int Id { get; set; }
        public string recipeName { get; set; }
        public double recipeProt { get; set; }
        public double recipeFat { get; set; }
        public double recipeCarb { get; set; }
        public double recipeCalorie { get; set; }

        public List<RecipeDays> RecipeDays { get; set; }
        public List<ProductRecipes> ProductRecipes { get; set; }
    }
}
