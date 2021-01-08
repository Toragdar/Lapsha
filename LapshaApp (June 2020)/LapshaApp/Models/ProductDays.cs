using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class ProductDay
    {
        public int productId { get; set; }
        public Product Product { get; set; }

        public int dayId { get; set; }
        public Day Day { get; set; }

        public double weight { get; set; }
    }
}
