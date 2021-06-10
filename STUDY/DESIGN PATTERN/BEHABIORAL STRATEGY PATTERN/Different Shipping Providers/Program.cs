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
                    DestinationCountry = "Sweeden"
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

           }
    }
}   


