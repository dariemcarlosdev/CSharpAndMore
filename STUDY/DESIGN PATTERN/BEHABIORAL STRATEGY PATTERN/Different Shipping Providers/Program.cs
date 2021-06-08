using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;

namespace Different_Shipping_Providers
{
    class Program
    {
        static void Main(string[] args)
        {

            var Orders = new List<Order>();

            var order1 = new Order(new List<Item>());
            order1._lineItems.Add(new Item("dads", 3, 3.2f));
            order1._lineItems.Add(new Item("dads", 10, 3.2f));

            var order2 = new Order(new List<Item>());
            order2._lineItems.Add(new Item("dads", 3, 0.2f));
            order2._lineItems.Add(new Item("dads", 7, 3.2f));
            order2._lineItems.Add(new Item("dads", 10, 0.4f));


            Orders.Add(order1);
            Orders.Add(order2);

            foreach (var order in Orders)
            {
                Console.WriteLine("Nro Order:{0} Total Items:{1} SaleTax:{2}$  Order Weight:{3} Kg",order.NroOrden, order._lineItems.Count, order.GetTax(), order.TotalWeight());
            }
        }
    }
}
