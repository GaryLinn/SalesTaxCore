using Ninject.Modules;
using SalesTaxCore.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxCore
{
    public class NinjectBindings :NinjectModule
    {
        public override void Load()
        {
            Bind<ISalesTaxWorker>().To<SalesTaxWorker>();
            Bind<IProductTaxCalculator>().To<ProductTaxCalculator>();
        }
    }
}
