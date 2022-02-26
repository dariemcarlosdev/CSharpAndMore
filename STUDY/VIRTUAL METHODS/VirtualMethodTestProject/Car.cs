using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethodTestProject
{

    public class Car : Vehicle
    {
        public Car(double _distance, double _hour, double _fuel) : base(_distance, _hour, _fuel)
        {
        }

        public void Average()
        {

            double average = 0.00;
            average = _distance / _fuel;
            Console.WriteLine("The Car average is {0:0.00}",average);

        }

        public override void Speed()
        {
            double speed = 0.00;
            speed = _distance / (_hour*2);
            Console.WriteLine("The Car speed is {0:0.00}", speed);

        }
    }
}
