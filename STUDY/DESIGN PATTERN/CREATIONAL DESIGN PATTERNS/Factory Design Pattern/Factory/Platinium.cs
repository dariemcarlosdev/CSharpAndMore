using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class Platinium : ICreditCard
    {
        public int GetAnnualCharge()
        {
            return 400;
        }

        public string GetCardType()
        {
            return "Platinium";
        }

        public int GetCreditLimit()
        {
            return 500;
        }
    }
}
