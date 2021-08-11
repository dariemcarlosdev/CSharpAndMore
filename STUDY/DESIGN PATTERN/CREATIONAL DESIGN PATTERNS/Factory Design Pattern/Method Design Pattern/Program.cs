using System;

namespace Factory_Method_Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Consuming the Factory Method in the Client Code:
            //

            ICreditCard platinium = new PlatiniumFactory().CreateProduct();
            if (platinium != null)
            {
                Console.WriteLine("Card Type is: {1}", platinium.GetCardType());
                Console.WriteLine("Card Limit is: {1}", platinium.GetCreditLimit());
                Console.WriteLine("Unnual charge is: {1}", platinium.GetAnnualCharge());
            }
            else
            {
                Console.WriteLine("Invalid Credit Card Type");
            }

            Console.WriteLine("------------------");

            ICreditCard titanium = new TitaniumFactory().CreateProduct();
            if (titanium != null)
            {
                Console.WriteLine("Card Tyoe is: {1}", titanium.GetCardType());
                Console.WriteLine("Card Limit is: {1}", titanium.GetCreditLimit());
                Console.WriteLine("Annual charge is: {1}", titanium.GetAnnualCharge()); 
            }

            else
            {
                Console.WriteLine("Invalid Credit Card Type");
            }

            Console.WriteLine("------------------");
        }
    }
}
