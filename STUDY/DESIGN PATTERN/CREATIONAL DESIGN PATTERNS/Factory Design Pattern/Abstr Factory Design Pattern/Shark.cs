using System;
using System.Collections.Generic;
using System.Text;

namespace Abstr_Factory_Design_Pattern
{
    class Shark : IAnimal
    {
        public string Speak()
        {
            return "Cannot Speak";
        }
    }
}
