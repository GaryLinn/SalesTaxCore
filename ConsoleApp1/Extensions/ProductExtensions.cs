using SalesTaxCore.Factory;
using SalesTaxCore.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace SalesTaxCore.Extensions
{
    public static class ProductExtensions 
    {
        public static IProductTaxResult ToProductTaxResult(this IProduct product, decimal taxRate)
        {
            //Round it to nearest 0.05
            var tax = Math.Round(product.Price * taxRate * 20, MidpointRounding.AwayFromZero) / 20;
            //Mapping and Generating results
            return new ProductTaxResult
            {
                Name = product.Name,
                PriceAfterTax = product.Price + tax,
                Tax = tax,
                Quantity = product.Quantity,
                Unit = product.Unit,
                ImportProduct = product.ImportProduct
            };
        }
    }
}
