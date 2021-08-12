using System;
using System.Collections.Generic;
using System.Text;

namespace Abstr_Factory_Design_Pattern
{
    //Abstract Factory
    public abstract class AnimalFactory
    {
        public abstract IAnimal GetAnimal(string AnimalType);

        public static AnimalFactory CreateAnimalFactory(string FactoryType)
        {
            if (FactoryType == "Sea")
            {
                return new SeaAnimalFactory();
            }

            else
            {
                return new LandAnimalFactory();
            }
        }
    }
}
