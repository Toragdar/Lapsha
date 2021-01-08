using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Product
    {
        public Product()
        {
            ProductDays = new List<ProductDay>();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<ProductDay> ProductDays { get; set; }
    }
}
