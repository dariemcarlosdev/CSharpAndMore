using System;
using System.Collections.Generic;
using System.Text;

namespace Different_Shipping_Providers.Business.Models
{
    public class Payment
    {
        public PaymentProvider PaymentProvider { get; internal set; }
    }
}
