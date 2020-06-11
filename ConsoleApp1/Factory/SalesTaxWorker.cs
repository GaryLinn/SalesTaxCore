using SalesTaxCore.Extensions;
using SalesTaxCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SalesTaxCore.Factory
{
    public class SalesTaxWorker : ISalesTaxWorker
    {
        public readonly IProductTaxCalculator ProductTaxCalculator;

        public SalesTaxWorker(IProductTaxCalculator productTaxCalculator)
        {
           ProductTaxCalculator = productTaxCalculator;
        }

        public string ExtractResults(IEnumerable<IProductTaxResult> results)
        {
            //Print Results
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var result in results)
            {
                stringBuilder.Append(result.ToExtract());
            }
            stringBuilder.Append($"Sales Tax:{results.Sum(x => x.Tax)} Total:{results.Sum(x => x.PriceAfterTax)}");
            return stringBuilder.ToString();
        }

        public IEnumerable<IProductTaxResult> GenerateResults(IEnumerable<IProduct> products)
        {
            //Generate Tax Results
            foreach(var product in products)
            {
                yield return this.ProductTaxCalculator.Process(product);
            }
        }

        public string Process(IEnumerable<IProduct> products)
        {
            //Process Product and Print out Results
            var results = this.GenerateResults(products);

            return this.ExtractResults(results);
        }
    }
}
