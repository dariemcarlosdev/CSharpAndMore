using System;
using System.Collections.Generic;
using System.Text;

namespace Abstr_Factory_Design_Pattern
{
    class Dog : IAnimal
    {
        public string Speak()
        {
            return "Bark Bark";
        }
    }
}
