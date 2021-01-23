using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class ProductDay
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DayId { get; set; }
        public Day Day { get; set; }

        public int Weight { get; set; }
    }
}
