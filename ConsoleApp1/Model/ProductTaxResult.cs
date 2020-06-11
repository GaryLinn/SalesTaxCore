using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxCore.Model
{
    public class ProductTaxResult : IProductTaxResult
    {
        public string Name { get; set; }
        public decimal PriceAfterTax { get; set; }
        public decimal Tax { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public bool ImportProduct { get; set; }
    }
}
