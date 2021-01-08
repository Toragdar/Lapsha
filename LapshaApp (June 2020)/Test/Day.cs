using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class Day
    {
        public Day()
        {
            ProductDays = new List<ProductDay>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDay> ProductDays { get; set; }

        public double GetProductWeight(string dbPath, string pName)
        {
            double weight = 10;
            try
            {
                using (var db = new TestContext(dbPath))
                {
                    var prod = db.Products.FirstOrDefault(p => p.Name == pName);
                    var day = db.Days.FirstOrDefault(d => d.Name == this.Name);

                    if (prod != null && day != null)
                    {
                        var productDays = day.ProductDays.FirstOrDefault(pd => pd.ProductId == prod.Id);
                        return productDays.Weight;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return weight;
        }
    }
}
