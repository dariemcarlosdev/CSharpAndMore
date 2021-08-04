using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    //Product
    public class Titanium : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 300;
        }

        public string GetCardType()
        {
            return "Titanium";
        }

        public int GetCreditLimit()
        {
            return 200;
        }
    }
}
