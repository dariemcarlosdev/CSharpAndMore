using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.Shipping
{
    public class FEDEXShippingProviderStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                // TO-DO Fedex Client integration.

                Console.WriteLine("Order #");
            }
        }
    }
}
