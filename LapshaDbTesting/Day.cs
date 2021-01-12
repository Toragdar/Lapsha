using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaDbTesting
{
    public partial class Day
    {
        public Day()
        {
            ProductDays = new HashSet<ProductDay>();
        }

        public long DayId { get; set; }
        public string DayName { get; set; }
        public double? Prot { get; set; }
        public double? Fat { get; set; }
        public double? Carb { get; set; }
        public long? Calorie { get; set; }

        public virtual ICollection<ProductDay> ProductDays { get; set; }
    }
}
