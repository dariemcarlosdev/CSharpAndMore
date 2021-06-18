using System;

namespace ABSTRACT_MEMBERS
{
    /*
    You can not consume the non-static members directly within a static method, you need to create the object first, access to it through this object.
    you can consume directly a static members within a non-static method.
    */
    public class StaticNonStaticMethods
    {
        int x = 100;
        static int y = 40;

        public static void Add()
        {
            
            var obj = new StaticNonStaticMethods();
            Console.WriteLine("Sum is {0}.", (obj.x + y));
        } 

        public void Mul()
        {
            //This is a non-static method
            //we can access static members directly or through class name
            //we can access the non-static members directly or through this keyword            
            Console.WriteLine("Mul is {0}.", (this.x * StaticNonStaticMethods.y ));
            Console.WriteLine("Mul is {0}.", (x * y)  );
        }
    }
}