using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LapshaApp
{
    public class Day
    {
        public Day()
        {
            ProductDays = new List<ProductDay>();
            RecipeDays = new List<RecipeDays>();
            totalProt = 0;
            totalFat = 0;
            totalCarb = 0;
            totalCalorie = 0;
        }
        public int Id { get; set; }
        public string dayName { get; set; }
        public double totalProt { get; set; }
        public double totalFat { get; set; }
        public double totalCarb { get; set; }
        public double totalCalorie { get; set; }

        public List<ProductDay> ProductDays { get; set; }
        public List<RecipeDays> RecipeDays { get; set; }

        public double GetProductWeight(string dbPath, string pName)
        {
            double weight = 10;
            try
            {
                using (var db = new ApplicationContext(dbPath))
                {
                    var prod = db.Products.FirstOrDefault(p => p.productName == pName);
                    var day = db.Days.FirstOrDefault(d => d.dayName == this.dayName);
                    
                    var productDays = db.ProductDays.Find(prod.Id, day.Id);
                    weight = productDays.weight;
                }
            }
            catch (Exception e)
            {

            }
            return weight;            
        }
    }    
}
