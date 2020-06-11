using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxCore.Model
{
    public class ShoppingItem : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public bool ImportProduct { get; set; }
    }
}
