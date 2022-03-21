using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingStrategy
{
    class TrainTravelStrategy : ITravelingStrategy
    {
        public void GoToTheAirport()
        {
            Console.WriteLine("Traveler is going to Airport by Train and will be charged Rs 200");
        }
    }
}
