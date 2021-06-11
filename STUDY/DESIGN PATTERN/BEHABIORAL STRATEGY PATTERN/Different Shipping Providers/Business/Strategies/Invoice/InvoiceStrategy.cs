using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.Invoice
{
    //I add an abstract base class that allows to create the basic implementation of IInvoiceStrategy.
    //But we want to require whoever´s inheriting from InvoiceStrategy need to implement(override) the genereted method.
    //Which still means that all of them are going to implement the interface for a IInvoiceStrategy.
    public abstract class InvoiceStrategy : IInvoiceStrategy
    {
        //abstract method.
        public abstract void Generate(Order order);

        //Share functionality that I want across all my different invoice strategies is the capability to represent our invoice as a String.
        public string GenerateTextInvoice(Order order) {

            var invoice = $"INVOICE DATE: {DateTimeOffset.Now}{Environment.NewLine}";
            invoice += $"NAME|PRICE|WEIGHT{Environment.NewLine}";
            foreach (var item in order.lineItems)
            {
                invoice += $"{item.ItemName}|{item.ItemCost}|{item.ItemWeight}";
            }

            invoice += Environment.NewLine + Environment.NewLine;

            var tax = order.GetTax();
            var total = order.GetTotalCost() + tax;

            invoice += $"TAX TOTAL: {tax}{Environment.NewLine}";
            invoice += $"TOTAL: {total}{Environment.NewLine}";

            return invoice;
        
        }

    }
}
