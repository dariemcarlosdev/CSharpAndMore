using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Design_Pattern
{
    //Concrete Product Class
    public class Platinium : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 35999;
        }

        public string GetCardType()
        {
            return "Platinium Plus";
        }

        public int GetCreditLimit()
        {
            return 20000;
        }
    }

}
