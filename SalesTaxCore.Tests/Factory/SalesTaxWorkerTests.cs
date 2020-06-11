using System;
using System.Collections.Generic;
using System.Text;
using SalesTaxCore.Factory;
using Moq;
using Xunit;
using SalesTaxCore.Model;
using System.Runtime.CompilerServices;
using System.Linq;
using Xunit.Abstractions;

namespace SalesTaxCore.Tests.Factory
{
    
    public class SalesTaxWorkerTests 
    {
        ITestOutputHelper Output;

        public SalesTaxWorkerTests(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void TestSalesTaxWorker_Input1()
        {
            //Input 1
            //ARRANGE
            IProductTaxCalculator productTaxCalculator = new ProductTaxCalculator();
            ISalesTaxWorker worker = new SalesTaxWorker(productTaxCalculator);
            var products = new List<ShoppingItem>
            {
                new ShoppingItem
                {
                    Name = "book",
                    Quantity = 1,
                    Category = ProductCategory.Books,
                    Price = 12.49m,
                    ImportProduct = false,
                },
                new ShoppingItem
                {
                    Name = "music CD",
                    Quantity = 1,
                    Category = ProductCategory.Other,
                    Price = 14.99m,
                    ImportProduct = false,
                },
                new ShoppingItem
                {
                    Name = "chocolate bar",
                    Quantity = 1,
                    Category = ProductCategory.Food,
                    Price = 0.85m,
                    ImportProduct = false
                }
            };
            //ACT
            var results = worker.GenerateResults(products).ToList();

            //ASSERT
            Assert.Equal(12.49m, results[0].PriceAfterTax);
            Assert.Equal(16.49m, results[1].PriceAfterTax);
            Assert.Equal(0.85m, results[2].PriceAfterTax);

            //Extract Results
            Output.WriteLine(worker.ExtractResults(results));
        }

        [Fact]
        public void TestSalesTaxWorker_Input2()
        {
            //Input 2
            //ARRANGE
            IProductTaxCalculator productTaxCalculator = new ProductTaxCalculator();
            ISalesTaxWorker worker = new SalesTaxWorker(productTaxCalculator);
            var products = new List<ShoppingItem>
            {
                new ShoppingItem
                {
                    Name = "chocolates",
                    Quantity = 1,
                    Category = ProductCategory.Food,
                    Price = 10.00m,
                    ImportProduct = true,
                    Unit = "box"
                },
                new ShoppingItem
                {
                    Name = "perfume",
                    Quantity = 1,
                    Category = ProductCategory.Other,
                    Price = 47.50m,
                    ImportProduct = true,
                    Unit = "bottle"
                }
            };
            //ACT
            var results = worker.GenerateResults(products).ToList();

            //ASSERT
            Assert.Equal(10.50m, results[0].PriceAfterTax);
            Assert.Equal(54.65m, results[1].PriceAfterTax);

            //Extract Results
            Output.WriteLine(worker.ExtractResults(results));
        }

        [Fact]
        public void TestSalesTaxWorker_Input3()
        {
            //Input 3
            //ARRANGE
            IProductTaxCalculator productTaxCalculator = new ProductTaxCalculator();
            ISalesTaxWorker worker = new SalesTaxWorker(productTaxCalculator);
            var products = new List<ShoppingItem>
            {
                new ShoppingItem
                {
                    Name = "perfume",
                    Quantity = 1,
                    Category = ProductCategory.Other,
                    Price = 27.99m,
                    ImportProduct = true,
                    Unit = "bottle"
                },
                new ShoppingItem
                {
                    Name = "perfume",
                    Quantity = 1,
                    Category = ProductCategory.Other,
                    Price = 18.99m,
                    ImportProduct = false,
                    Unit = "bottle"
                },
                new ShoppingItem
                {
                    Name = "headche pills",
                    Quantity = 1,
                    Category = ProductCategory.MedicalProducts,
                    Price = 9.75m,
                    ImportProduct = false,
                    Unit = "packet"
                },
                new ShoppingItem
                {
                    Name = "chocolates",
                    Quantity = 1,
                    Category = ProductCategory.Food,
                    Price = 11.25m,
                    ImportProduct = true,
                    Unit = "box"
                }
            };
            //ACT
            var results = worker.GenerateResults(products).ToList();

            //ASSERT
            Assert.Equal(32.19m, results[0].PriceAfterTax);
            Assert.Equal(20.89m, results[1].PriceAfterTax);
            Assert.Equal(9.75m, results[2].PriceAfterTax);
            Assert.Equal(11.80m, results[3].PriceAfterTax);

            //Extract Results
            Output.WriteLine(worker.ExtractResults(results));
        }

    }
}
