using System;

namespace Factory
{
    class Program

        //Example without using Factory Design Pattern Implementation.
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Card Type: ");
            string cardType = Console.ReadLine();


            //Create an empty object of type ICreditCard. Based on user selection Credit Card, we create an instance of any one three product implementation class.
            ICreditCard cardDetails = null;

            if (cardType == "Monkey")
            {
                cardDetails = new MoneyBank();
            }

            else if (cardType == "Titanium")
            {
                cardDetails = new Titanium();
            }

            else if (cardType == "Platinium")
            {
                cardDetails = new Platinium();
            }

            if (cardDetails != null)
            {
                Console.WriteLine($"CardType: {cardDetails.GetCardType()}");
                Console.WriteLine($"Card Limit: {cardDetails.GetCreditLimit()}");
                Console.WriteLine($"Card Annual Feed: {cardDetails.GetAnnualCharge()}");
            }

            else
            {
                Console.WriteLine("Invalid Card Type");
            
            }
        }
    }
}
