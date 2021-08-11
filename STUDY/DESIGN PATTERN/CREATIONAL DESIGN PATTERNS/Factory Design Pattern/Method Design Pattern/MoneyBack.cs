using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Design_Pattern
{
    //Product Class
    public class MoneyBack : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 455677;
        }

        public string GetCardType()
        {
            return "MoneyBack";
        }

        public int GetCreditLimit()
        {
            return 222222;
        }
    }
}
