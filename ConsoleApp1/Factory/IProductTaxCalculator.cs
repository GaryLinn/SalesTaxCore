using SalesTaxCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxCore.Factory
{
    public interface IProductTaxCalculator
    {
        public IProductTaxResult Process(IProduct product);
    }
}
