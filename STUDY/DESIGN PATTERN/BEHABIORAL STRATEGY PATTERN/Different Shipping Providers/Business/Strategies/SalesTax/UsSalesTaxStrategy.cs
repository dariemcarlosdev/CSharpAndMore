using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.SalesTax
{
    public class UsSalesTaxStrategy : ISaleTaxStrategy
    {
        public int GetTaxFor(Order order)
        {
            switch (order.ShippingDetails.DestinationState.ToLowerInvariant())
            {
                case "la": return order.GetTotalCost() * 5;
                case "ny": return order.GetTotalCost() * 1;
                default: return 0;

            }
        }
    }
}
