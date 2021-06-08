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
            order1._lineItems.Add(new Item("dads", 3));
            order1._lineItems.Add(new Item("dads", 10));

            var order2 = new Order(new List<Item>());
            order2._lineItems.Add(new Item("dads", 3));
            order2._lineItems.Add(new Item("dads", 7));
            order2._lineItems.Add(new Item("dads", 10));


            Orders.Add(order1);
            Orders.Add(order2);

            foreach (var item in Orders)
            {
                Console.WriteLine("Nro Order:{0} Total Items:{1} SaleTax:{2}$",item.NroOrden, item._lineItems.Count, item.GetTax());
            }
        }
    }
}
