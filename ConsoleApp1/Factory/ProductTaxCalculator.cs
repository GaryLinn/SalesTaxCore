using SalesTaxCore.Extensions;
using SalesTaxCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxCore.Factory
{
    public class ProductTaxCalculator : IProductTaxCalculator
    {
        public IProductTaxResult Process(IProduct product)
        {
            //Calculate tax rate
            //TODO:Isolate the TaxRateCalculator once logic turns complex
            decimal rate = 0;
            if (product.ImportProduct)
                rate += 0.05m;
            if (product.Category == ProductCategory.Other)
                rate += 0.1m;

            return product.ToProductTaxResult(rate);
        }
    }
}
