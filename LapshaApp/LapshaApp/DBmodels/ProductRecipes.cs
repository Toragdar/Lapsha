using System;
using System.Collections.Generic;
using System.Text;

namespace LapshaApp
{
    public class ProductRecipes
    {
        public int Id { get; set; }
        public string idProductName { get; set; }
        public Product Product { get; set; }
        public string idRecipeName { get; set; }
        public Recipe Recipe { get; set; }
    }
}
