using SalesTaxCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxCore.Factory
{
    public interface ISalesTaxWorker
    {
        public string Process(IEnumerable<IProduct> products);

        public IEnumerable<IProductTaxResult> GenerateResults(IEnumerable<IProduct> products);

        public string ExtractResults(IEnumerable<IProductTaxResult> results);
    }
}
