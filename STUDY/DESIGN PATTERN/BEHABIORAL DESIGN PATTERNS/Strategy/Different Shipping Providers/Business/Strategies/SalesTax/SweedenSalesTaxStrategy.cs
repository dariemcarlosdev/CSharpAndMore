using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.SalesTax
{
    public class SweedenSalesTaxStrategy : ISaleTaxStrategy
    {
        public int GetTaxFor(Order order)
        {
            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            var origin = order.ShippingDetails.OriginCountry.ToLowerInvariant();
            if (destination == origin)
            {
                return order.GetTotalCost() * 2;
            }

            return 0;
        }
    }
}
