using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        void Ship(Order order);
    }
}
