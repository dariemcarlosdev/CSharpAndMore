using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingStrategy
{
    class BusTravelStrategy : ITravelingStrategy
    {
        public void GoToTheAirport()
        {
            Console.WriteLine("Traveler is going to Airport by bus and will be charged Rs 300");
        }
    }
}
