using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class ProductDays
    {
        public int Id { get; set; }
        public string idProductName { get; set; }
        public Product Product { get; set; }
        public string idDayName { get; set; }
        public Day Day { get; set; }
        public int Weight { get; set; }
    }
}
