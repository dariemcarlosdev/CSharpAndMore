using Different_Shipping_Providers.Business.Models;
using Different_Shipping_Providers.Business.Strategies.Invoice;
using Different_Shipping_Providers.Business.Strategies.SalesTax;
using Different_Shipping_Providers.Business.Strategies.Shipping;
using System;
using System.Collections.Generic;

namespace Different_Shipping_Providers
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Input

            Console.WriteLine("Select origin country: ");
            var origin = Console.ReadLine().Trim();


            Console.WriteLine("Select destination country: ");
            var destination = Console.ReadLine().Trim();

            Console.WriteLine("Choose one of the following shipping providers.");
            Console.WriteLine("1. DHL");
            Console.WriteLine("2. FEDEX");
            Console.WriteLine("3. USA Postal Service");
            Console.WriteLine("Select shipping provider: ");
            var provider = Convert.ToInt32(Console.ReadLine().Trim());


            Console.WriteLine("Choice one of the following invoice delivery options.");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. File(Download Later)");
            Console.WriteLine("Select shipping provider: ");
            var invoiceOptions = Convert.ToInt32(Console.ReadLine().Trim());
            #endregion


            var Orders = new List<Order>();
            


            var order = new Order {

                //Initializing Order->ShippingDetails property.
                ShippingDetails = new ShippingDetails
                {
                    //Initializing ShippingDetails object properties.
                    OriginCountry = origin,
                    DestinationCountry = destination,

                },

                lineItems = new List<Item>(),

                SelectedPayments = new List<Payment>(),
              
                //Setting our Strategy as a property on a particular Order (our Context )
                
                 SaleTaxStrategy = GetSalesTaxStrategyFor(origin),
                 ShippingStrategy = GetShippingStrategyFor(provider),
                 InvoiceStrategy = GetInvoiceStrategyFor(invoiceOptions)
                
                
                
            };

            order.SelectedPayments.Add(new Payment { PaymentProvider = PaymentProvider.Invoice });

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
            //Adding a concrete implementation of InvoiceStrategy. 
            //order.InvoiceStrategy = new FileInvoiceStrategy();
            order.FinalizeOrder();

           }

        private static IInvoiceStrategy GetInvoiceStrategyFor(int invoiceOptions)
        {
            switch (invoiceOptions)
            {
                case 1: return new EmailInvoiceStrategy();
                case 2: return new FileInvoiceStrategy();
                default: throw new Exception("Unsupported invoice option.");
            }
        }

        private static IShippingStrategy GetShippingStrategyFor(int provider)
        {
            switch (provider)
            {
                case 1: return new DHLShippingProviderStrategy();
                case 2: return new FEDEXShippingProviderStrategy();
                case 3: return new USAPostalServiceShippingProviderStrategy();
                default: throw new Exception("Unsupported shipping method.");
            }
        }

        private static ISaleTaxStrategy GetSalesTaxStrategyFor(string origin)
        {
            if (origin.ToLowerInvariant() == "sweeden")
            {
                return new SweedenSalesTaxStrategy();
            }

            else if (origin.ToLowerInvariant() == "us")
            {

                return new UsSalesTaxStrategy();
            }

            else
            {
                throw new Exception("Unsupported reion");
            }
        }
    }
}   


 