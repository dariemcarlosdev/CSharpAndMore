using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.Shipping
{
    public class DHLShippingProviderStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {

            using (var client = new HttpClient())
            {
                //TO-DO DHL Client Integration.

                Console.WriteLine("Order #{0} was shipped with DHL", order.NroOrden);
            }
        }
    }
}
