using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class MoneyBank : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 500;
        }

        public string GetCardType()
        {
            return "MoneyBank";
        }

        public int GetCreditLimit()
        {
            return 1000;
        }
    }
}
