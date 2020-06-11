using Ninject;
using SalesTaxCore.Factory;
using SalesTaxCore.Model;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SalesTaxCore
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var worker = kernel.Get<ISalesTaxWorker>();
            //Input 1
            var input1Products = new List<ShoppingItem>
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
            //Process Input 1
            Console.WriteLine("--------------------Input 1---------------------");
            Console.WriteLine(worker.Process(input1Products));

            //Input 2
            var input2Products = new List<ShoppingItem>
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
            //Process Input 2
            Console.WriteLine("\n\n--------------------Input 2---------------------");
            Console.WriteLine(worker.Process(input2Products));

            //Input 3
            var input3Products = new List<ShoppingItem>
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
            //Process Input 3
            Console.WriteLine("\n\n--------------------Input 3---------------------");
            Console.WriteLine(worker.Process(input3Products));
            Console.WriteLine("\n\nFor input 3, the last item: 1 box of imported chocolate(Food, basic tax rate 0.1 waived),\n price is 11.25, tax rate is 0.05(import item), the tax is 0.5625 round to 0.55, total should be 11.80 instead of 11.85");

            //Input 4
            var input4Products = new List<ShoppingItem>
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
                    Name = "egg",
                    Quantity = 2.5m,
                    Category = ProductCategory.Food,
                    Price = 5.99m,
                    ImportProduct = false,
                    Unit = "dozens"
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
                    Name = "tomatoes",
                    Quantity = 1.19m,
                    Category = ProductCategory.Food,
                    Price = 2.39m,
                    ImportProduct = false,
                    Unit = "pounds"
                }
            };
            //Process Input 4
            Console.WriteLine("\n\n--------------------Input 4---------------------");
            Console.WriteLine(worker.Process(input4Products));
        }
    }
}
