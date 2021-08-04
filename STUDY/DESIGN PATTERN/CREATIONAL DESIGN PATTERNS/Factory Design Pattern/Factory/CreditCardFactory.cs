using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    //Factory Class and take the responsibility for creating and return the appropiate product Object. 
    class CreditCardFactory
    {
        //This static method based on the value parameter received, it will create one of the credit card object and store that object in the super class reference variable. 
        public static ICreditCard GetCreditCard(string cardType)
        {

            ICreditCard carDetails = null;

            if (cardType == "MoneyBack")
            {
                carDetails = new MoneyBank();
            }

            else if (cardType =="Titanium")
            {
                carDetails = new Titanium();
            }

            else if (cardType =="Platinium")
            {
                carDetails = new Platinium();
            }

            return carDetails;
        
        }
    }
}
