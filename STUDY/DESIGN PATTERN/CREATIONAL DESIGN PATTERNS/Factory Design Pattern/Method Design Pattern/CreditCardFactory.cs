using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Design_Pattern
{
    /*
     The Abstract Creator declares the factory method, which returns an object of type Product. As per the definition, we need to create an abstract class or interface for creating the object. 
    So, let us create an abstract class that will be our factory class with a publicly exposed method.
     */
    public abstract class CreditCardFactory
    {
        protected abstract ICreditCard MakeProduct();

        //public exposed method.(Factory method)
        //The CreateProduct() method internally calls the MakeProduct() method of the subclass which will create the product instance and return that instance.
        public ICreditCard CreateProduct() 
        {

            return this.MakeProduct();
        
        }
    }
}
