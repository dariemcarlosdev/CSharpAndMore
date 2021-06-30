using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public interface ICreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }
}
