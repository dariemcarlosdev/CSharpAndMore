using System;
using System.Net.Http;
using Different_Shipping_Providers.Business.Models;

namespace Different_Shipping_Providers.Business.Strategies.Shipping
{
  public class USAPostalServiceShippingProviderStrategy : IShippingProviderStrategy
  {
    public void ShipOrder(Order order)
    {
      using (var client = new HttpClient())
      {
         //TODO: implement USA Postal Shipping Integretion

         Console.WriteLine("Order #{0} was shipped with USA Postal Service", order.NroOrden); 
      }
    }
  }
}