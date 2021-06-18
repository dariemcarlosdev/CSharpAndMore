namespace ABSTRACT_MEMBERS
{
    /*
    A static class can contain only static members in it. It is not possible to create an instance of a static class,because it contains only static members.
     and as we know we can access the static members of a class by using the class name. 

    In this example both method for converting temperature will no change at all and hence we can use an Static Class with static methods which the conversion for us.
    */
    public static class StaticClass
    {
        public static double CelciusToFahrenheit(string TempCelcius)
        {
            
            double celcius = double.Parse(TempCelcius);

            double fahrenheit = (celcius * 9 / 5) + 32; 

            return fahrenheit;
        }

        public static double FahrenheitToCelcius(string TempFahrenheit)
        {
            double fahrenheit = double.Parse(TempFahrenheit);
            double celcious = (fahrenheit - 32) * 5 / 9;
            return celcious;
        }
    }

}