using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethodTestProject.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double length, double with) : base(length, with)
        {
        }

        public override void Area(){

            double area = 0.00;
            area = length * with;
            Console.WriteLine("Area Rectangle is: {0:0.0}",area);
        }
    }
}
