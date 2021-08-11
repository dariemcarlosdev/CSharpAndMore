using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Design_Pattern
{
    /*
     The Concrete Creator object overrides the factory method to return an instance of a Concrete Product.
    As we have three types of Credit Card, so we are going to create three classes
     */
    public class MoneyBackFactory : CreditCardFactory
    {
        protected override ICreditCard MakeProduct()
        {
            ICreditCard product = new MoneyBack();
            return product;
        }
    }
}
