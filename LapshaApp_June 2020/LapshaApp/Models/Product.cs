using System;
using System.Collections.Generic;

namespace LapshaApp
{    
    public partial class Product
    {
        public Product()
        {
            ProductDays = new List<ProductDay>();
            ProductRecipes = new List<ProductRecipes>();
        }
        public int Id { get; set; }
        public string productName { get; set; }
        public double prot { get; set; }
        public double fat { get; set; }
        public double carb { get; set; }
        public double calorie { get; set; }
        public double weight { get; set; }
        public List<ProductDay> ProductDays { get; set; }
        public List<ProductRecipes> ProductRecipes { get; set; }

        public void Calculate(double Weight)
        {
            double WeightCoef = Weight / 100;
            this.prot *= WeightCoef;
            this.fat *= WeightCoef;
            this.carb *= WeightCoef;
            this.calorie *= WeightCoef;
        }
    }
}
