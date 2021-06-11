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
                    DestinationCountry = "Sweeden",

                },

                lineItems = new List<Item>(),
              
                //Setting our Strategy as a property on a particular Order (our Context )
                
                 SaleTaxStrategy = new SweedenSalesTaxStrategy()
                
                
                
            };

            order.lineItems.Add(new Item("dads", 3, 3.2f));
            order.lineItems.Add(new Item("xxx", 5, 8.2f));

            
            
            //var destination = order.ShippingDetails.DestinationCountry.ToLowerInvariant();

            //if (destination == "sweeden")
            //{
            //    //Setting the concrete Strategy implementation based on client desition.
            //    order.SaleTaxStrategy = new SweedenSalesTaxStrategy();
            //}

            //else if (destination == "us")
            //{   
            //    //Setting the concrete estrategy implementation based on client desition.
            //    order.SaleTaxStrategy = new UsSalesTaxStrategy();
            //}

            Console.WriteLine("Nro Order: Total Items:{0} SaleTax:{1}$  Order Total Weight:{2} Kg", order.lineItems.Count, order.GetTax(new SweedenSalesTaxStrategy()), order.TotalWeight());

           }
    }
}   


