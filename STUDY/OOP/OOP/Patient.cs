using System;

namespace OOP
{
    class Patient : User {

        public Doctor Doctorwhowilltreat { get; set; }
        public override void Validate()
        {
            Console.WriteLine("Validate Doctor user name and adress.");
            base.Validate();
        }

        public override void Validate(bool strict)
        {
            //our own loggic.
            base.Validate(strict);
        }
    }
}
