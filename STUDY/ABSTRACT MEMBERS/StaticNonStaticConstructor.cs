using System;

namespace ABSTRACT_MEMBERS
{
    public class StaticNonStaticConstructor
    {
        
        /*
        the static constructor is the fast block of code that gets executes under a class.
        No matter how many numbers of objects you created for the class the static constructor is executed only once.
        non-static constructor gets executed only when we created the object of the class and that is too for each and every object of the class.
        It is not possible to create a static constructor with parameters. This is because the static constructor is the first block of code that is going to execute under a class. 
        This static constructor called implicitly, even if parameterized there is no chance of sending the parameter values.
        */
        static StaticNonStaticConstructor()
        {
            Console.WriteLine("The static constructor is called.");
        }

        public StaticNonStaticConstructor()
        {   
            
            Console.WriteLine("The non-static constructor is called.");
        }
    }
}