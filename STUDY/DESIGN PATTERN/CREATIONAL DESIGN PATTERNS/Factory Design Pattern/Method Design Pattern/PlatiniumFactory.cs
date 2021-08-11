using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Design_Pattern
{
    //Implement Abstract CreditCardFactory class.
   public class PlatiniumFactory : CreditCardFactory
    {
        protected override ICreditCard MakeProduct()
        {
            ICreditCard product = new Platinium();
            return product;
        }
    }
}
