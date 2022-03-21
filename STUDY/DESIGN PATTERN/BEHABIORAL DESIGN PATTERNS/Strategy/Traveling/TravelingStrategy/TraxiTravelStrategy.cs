using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingStrategy
{
    class TraxiTravelStrategy : ITravelingStrategy
    {
        public void GoToTheAirport()
        {
            Console.WriteLine("Traveler is going to Airport by Taxi and will be charged Rs 1000");
        }
    }
}
