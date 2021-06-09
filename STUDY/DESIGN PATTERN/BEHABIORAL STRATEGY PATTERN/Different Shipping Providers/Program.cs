using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;

namespace Different_Shipping_Providers
{
    class Program
    {
        static void Main(string[] args)
        {

            var order1 = new Order{
                
                //Initializing Order->ShippingDetails property.
                ShippingDetails = new ShippingDetails
                {
                    //Initializing ShippingDetails object properties.
                    OriginCountry = "Sweeden",
                    DestinationCountry = "Sweeden"
                },
                
                lineItems = new List<Item>()
            };

            order1.lineItems.Add(new Item("dads", 3, 3.2f));
            order1.lineItems.Add(new Item("xxx", 5, 8.2f));
            

            var order2 = new Order{
                
                //Initializing Order->ShippingDetails property.
                ShippingDetails = new ShippingDetails
                {
                    //Initializing ShippingDetails object properties.
                    OriginCountry = "Us",
                    DestinationCountry = "Us"
                },

                lineItems = new List<Item>()
            };

            order2.lineItems.Add(new Item("dads", 10, 3.2f));

            //Initialazing List of Orders.
            var Orders = new List<Order>();
            Orders.Add(order1);
            Orders.Add(order2); 

            foreach (var item in Orders)
            {
                Console.WriteLine("Nro Order: Total Items:{0} SaleTax:{1}$  Order Weight:{2} Kg", item.lineItems.Count, item.GetTax(), item.TotalWeight());
            }
        }
    }
}
