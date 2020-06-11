using SalesTaxCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxCore.Model
{
    public interface IProduct
    {
        /// <summary>
        /// Name of Product
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Price of Product
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Product Category
        /// </summary>
        public ProductCategory  Category { get; set; }

        /// <summary>
        /// Quantity of Product
        /// </summary>
        public decimal Quantity { get; set; }
        
        /// <summary>
        /// Product Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Unit of Product ex:box bottle
        /// </summary>
        public string? Unit { get; set; }

        /// <summary>
        /// Import Product
        /// </summary>
        public bool ImportProduct { get; set; }

    }
}
