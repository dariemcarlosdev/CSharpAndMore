using System;
using System.Collections.Generic;
using System.Text;

namespace Abstr_Factory_Design_Pattern
{
    class Cat : IAnimal
    {
        public string Speak()
        {
            return "Meow";
        }
    }
}
