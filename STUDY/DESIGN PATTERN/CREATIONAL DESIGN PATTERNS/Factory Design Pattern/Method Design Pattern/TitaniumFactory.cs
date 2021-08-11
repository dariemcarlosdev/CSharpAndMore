using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Design_Pattern
{
    public class TitaniumFactory : CreditCardFactory
    {
        protected override ICreditCard MakeProduct()
        {
            ICreditCard product = new Titanium();
            return product;
        }
    }
}
