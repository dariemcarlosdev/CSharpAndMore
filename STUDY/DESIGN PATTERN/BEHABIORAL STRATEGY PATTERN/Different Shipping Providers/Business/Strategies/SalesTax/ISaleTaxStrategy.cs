using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.SalesTax
{
    public interface ISaleTaxStrategy
    {
        public int GetTaxFor(Order order);
    }
}
