using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class ProductDays
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public Product Product { get; set; }
        public int dayId { get; set; }
        public Day Day { get; set; }
        public int weight { get; set; }
    }
}
