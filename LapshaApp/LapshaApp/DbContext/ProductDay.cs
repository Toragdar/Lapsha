using System;
using System.Collections.Generic;


namespace LapshaApp
{
    public partial class ProductDay
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long DayId { get; set; }
        public long Weight { get; set; }

        public virtual Day Day { get; set; }
        public virtual Product Product { get; set; }
    }
}
