using Different_Shipping_Providers.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Different_Shipping_Providers.Business.Strategies.Invoice
{
     public interface IInvoiceStrategy
    {
        //Generate Invoice based on a particupar Order.
        //This method doesn´t return anything because either it send a email, calls an API or save something to our filesystem.
        public void Generate(Order order);
    }
}
