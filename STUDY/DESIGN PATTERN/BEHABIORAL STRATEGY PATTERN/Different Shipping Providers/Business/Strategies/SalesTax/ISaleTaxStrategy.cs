using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.SalesTax
{
    interface ISaleTaxStrategy
    {
        public int GetTax(Order order);
    }
}
