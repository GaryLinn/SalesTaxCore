using SalesTaxCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxCore.Extensions
{
    public static class ProductTaxResultExtensions
    {
        public static string ToExtract(this IProductTaxResult result)
        {
            //Print single product receipt item
            return $"{result.Quantity} {(result.ImportProduct?"imported ":"")}{(string.IsNullOrWhiteSpace(result.Unit)?"":result.Unit+" of ")}{result.Name}: {result.PriceAfterTax}\n";
        }
    }
}
