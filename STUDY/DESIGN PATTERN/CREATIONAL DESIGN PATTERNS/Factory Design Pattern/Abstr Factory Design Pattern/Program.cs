using System;

namespace Abstr_Factory_Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = null;
            AnimalFactory animalFactory = null;
            string speakSound = null;

            //Create the Sea Factory object passing the factory type Sea

            animalFactory = AnimalFactory.CreateAnimalFactory("Sea");
            Console.WriteLine("Animal Factory Type: {0}", animalFactory.GetType().Name);
            Console.WriteLine();

            //Get Octupus Animal object passing animal type Octupus.
            animal = animalFactory.GetAnimal("Octupus");
            Console.WriteLine("Animal type: {0}", animal.GetType().Name);
            speakSound = animal.Speak();
            Console.WriteLine(animal.GetType().Name + " Speak: " + speakSound);
            Console.WriteLine();

            // Get Lion Animal object by passing the animal type as Lion

            animalFactory = AnimalFactory.CreateAnimalFactory("Lion");
            Console.WriteLine("Animal Factory Type: " + animalFactory.GetType().Name);
            Console.WriteLine();

            //Get Lion Animal object passing animal type Lion.
            animal = animalFactory.GetAnimal("Lion");
            Console.WriteLine("Animal Type: " + animal.GetType().Name);
            speakSound = animal.Speak();
            Console.WriteLine(animal.GetType().Name + " Speak: " + speakSound);
        }
    }
}
