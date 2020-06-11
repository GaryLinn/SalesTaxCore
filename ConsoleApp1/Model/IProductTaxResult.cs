using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxCore.Model
{
    public interface IProductTaxResult
    {
        /// <summary>
        /// Name of Product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of Product After Tax
        /// </summary>
        public decimal PriceAfterTax { get; set; }

        /// <summary>
        /// Tax of Product
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Quantity of Product
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Unit of Product ex:box bottle
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Import Product
        /// </summary>
        public bool ImportProduct { get; set; } 
    }
}
