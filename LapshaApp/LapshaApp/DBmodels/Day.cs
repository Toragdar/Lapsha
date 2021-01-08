using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class Day
    {
        public int Id { get; set; }
        public string dayName { get; set; }
        public double prot { get; set; }
        public double fat { get; set; }
        public double carb { get; set; }
        public int calorie { get; set; }
        public List<ProductDays> ProductDays { get; set; }
        public Day()
        {
            ProductDays = new List<ProductDays>();
        }
    }
}
