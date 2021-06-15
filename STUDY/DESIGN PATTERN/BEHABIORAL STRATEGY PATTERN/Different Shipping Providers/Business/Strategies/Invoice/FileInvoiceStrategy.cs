using Different_Shipping_Providers.Business.Models;
using System;
using System.IO;

namespace Different_Shipping_Providers.Business.Strategies.Invoice
{
    public class FileInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using (var stream = new StreamWriter($"invoice_{Guid.NewGuid()}.txt") )
            {
                stream.Write(GenerateTextInvoice(order));
                stream.Flush();
            }
        }
    }
}