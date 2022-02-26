using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethodTestProject.Shapes
{
    public class Shape
    {
        public Shape(double radius)
        {
            this.radius = radius;
        }

        public Shape(double length, double with)
        {
            this.length = length;
            this.with = with;
            
        }

        public double length { get; set; } = 0.00;
        public double with { get; set; } = 0.00;
        public double radius { get; set; } = 0.00;

        public virtual void Area() {

            double area = 0.00;
            area = Math.PI * Math.Pow(radius,2);
            Console.WriteLine("Area of Shape is {0:0.00}",area);
        
        }
    }
}
