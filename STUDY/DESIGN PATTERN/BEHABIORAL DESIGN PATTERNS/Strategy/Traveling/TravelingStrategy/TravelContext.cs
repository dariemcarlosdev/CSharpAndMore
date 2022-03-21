using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingStrategy
{
    public class TravelContext
    {
        private ITravelingStrategy Traveling;

        //public TravelContext(ITravelingStrategy traveling)
        //{
        //    Traveling = traveling;
        //}

        //The Client Will set What traveling Strategy to use by calling this method at the run time.
        public void SetStrategy( ITravelingStrategy TravelingStrategy) {

            this.Traveling = TravelingStrategy;
        
        }

        public void goToTheAirPort() {

            Traveling.GoToTheAirport();
        
        }
    }
}
