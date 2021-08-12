namespace Abstr_Factory_Design_Pattern
{
    internal class SeaAnimalFactory : AnimalFactory
    {
        public override IAnimal GetAnimal(string AnimalType)
        {
            if (AnimalType.Equals("Octupus"))
            {
                return new Octupus();
            }

            else if (AnimalType.Equals("Shark"))
            {
                return new Shark();
            }

            else return null;
        }
    }
}