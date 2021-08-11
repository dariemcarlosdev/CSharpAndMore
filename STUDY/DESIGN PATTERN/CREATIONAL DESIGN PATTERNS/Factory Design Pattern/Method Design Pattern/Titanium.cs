using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Design_Pattern
{

    public class Titanium : ICreditCard
    {  
        //Product Class
        public int GetAnnualCharge()
        {
            return 343434;
        }

        public string GetCardType()
        { 
            return "Titanium";
        }

        public int GetCreditLimit()
        {
            return 455555;
        }
    }
}
