using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethodTestProject
{

    public class Vehicle
    {
        public Vehicle(double _distance, double _hour, double _fuel)
        {
            this._distance = _distance;
            this._hour = _hour;
            this._fuel = _fuel;
        }

        public double _distance = 0.0;
        public double _hour = 0.0;
        public double _fuel = 0.0; 
        

        public void Averarge() {
            double average = 0.0;
            average = _distance / _fuel;
            Console.WriteLine("Vehicle average is {0:0.00}", average);
        }

        public virtual void Speed() {
            double speed = 0.00;
            speed = _distance / _hour;
            Console.WriteLine("Vehicle speed is {0:0.00}", speed);
        
        }
           
    }
}
