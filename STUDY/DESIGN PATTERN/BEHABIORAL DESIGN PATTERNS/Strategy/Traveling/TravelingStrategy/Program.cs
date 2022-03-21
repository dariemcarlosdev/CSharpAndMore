using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the travel type of your choice: Auto, Bus, Taxi or Train");
            var travelingType = Console.ReadLine();
            Console.WriteLine("You have choise travel in {0}", travelingType);


            TravelContext travelingContext = null;
            travelingContext = new TravelContext();

            if ("Bus".Equals(travelingType, StringComparison.InvariantCultureIgnoreCase))
            {
                travelingContext.SetStrategy(new BusTravelStrategy());
            }

            if ("Taxi".Equals(travelingType, StringComparison.InvariantCultureIgnoreCase))
            {
                travelingContext.SetStrategy(new TraxiTravelStrategy());
            }

            if ("Train".Equals(travelingType, StringComparison.InvariantCultureIgnoreCase))
            {
                travelingContext.SetStrategy(new TrainTravelStrategy());
            }

            if ("Auto".Equals(travelingType, StringComparison.InvariantCultureIgnoreCase))
            {
                travelingContext.SetStrategy(new AutoTravelStrategy());
            }

            travelingContext.goToTheAirPort();

        }
    }
}
