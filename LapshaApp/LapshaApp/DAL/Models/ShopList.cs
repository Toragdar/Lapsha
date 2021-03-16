using System;
using System.Collections.Generic;

#nullable disable

namespace LapshaApp
{
    public class ShopList
    {
        public long Id { get; set; }
        public long ProductWeight { get; set; }
        public long BuyCheck { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
