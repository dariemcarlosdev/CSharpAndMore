using Different_Shipping_Providers.Business.Models;
using Different_Shipping_Providers.Business.Strategies.SalesTax;
using System;
using System.Collections.Generic;

namespace Different_Shipping_Providers
{
    class Program
    {
        static void Main(string[] args)
        {

            var Orders = new List<Order>();


            var order = new Order {

                //Initializing Order->ShippingDetails property.
                ShippingDetails = new ShippingDetails
                {
                    //Initializing ShippingDetails object properties.
                    OriginCountry = "Sweeden",
                    DestinationCountry = "Us",
                    DestinationState = "ny"
                },

                lineItems = new List<Item>()
            };
            

            order.lineItems.Add(new Item("dads", 3, 3.2f));
            order.lineItems.Add(new Item("xxx", 5, 8.2f));

            var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();
            if (destination == "sweeden")
            {
                order.SaleTaxStrategy = new SweedenSalesTaxStrategy();
            }

            else if (destination == "us")
            {
                order.SaleTaxStrategy = new UsSalesTaxStrategy();
            }

            Console.WriteLine("Nro Order: Total Items:{0} SaleTax:{1}$  Order Total Weight:{2} Kg", order.lineItems.Count, order.GetTax(), order.TotalWeight());

           /* var order2 = new Order{
                
                //Initializing Order->ShippingDetails property.
                ShippingDetails = new ShippingDetails
                {
                    //Initializing ShippingDetails object properties.
                    OriginCountry = "Sweeden",
                    DestinationCountry = "Us",
                    DestinationState = "ny"
                },
                lineItems = new List<Item>()
            };
            
            order2.lineItems.Add(new Item("dads", 10, 3.2f));

            Orders.Add(order1);
            Orders.Add(order2); 

            foreach (var item in Orders)
            {
                Console.WriteLine("Nro Order: Total Items:{0} SaleTax:{1}$  Order Weight:{2} Kg", item.lineItems.Count, item.GetTax(), item.TotalWeight());
            }*/
        }
    }
}
