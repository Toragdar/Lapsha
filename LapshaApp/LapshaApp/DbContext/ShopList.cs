using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public partial class ShopList
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long ProductWeight { get; set; }
        public long BuyCheck { get; set; }

        public virtual Product Product { get; set; }
    }
}
