using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SalesTaxCore.Extensions;
using SalesTaxCore.Model;

namespace SalesTaxCore.Tests.Extensions
{
    public class ProductTaxResultExtensionTests
    {
        [Theory]
        [InlineData(0.8, 0.05, 0.05)]//0.04
        [InlineData(0.4, 0.05, 0.0)]//0.02
        [InlineData(0.5, 0.05, 0.05)]//0.025
        [InlineData(47.5, 0.15, 7.15)]//7.125
        public void TestToProductResultExtensions(decimal price, decimal rate, decimal tax)
        {
            //ARRANGE
            var product = new ShoppingItem
            {
                Name = "Chocolate",
                Price = price,
                Category = ProductCategory.Other,
                Quantity = 2,
                Description = "111",
                ImportProduct = true,
                Unit = ""
            };

            //ACT
            var result = product.ToProductTaxResult(rate);

            //ASSERT
            Assert.Equal(tax, result.Tax);
        }
            
    }
}
