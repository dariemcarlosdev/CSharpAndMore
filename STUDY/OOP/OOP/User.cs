using System;

namespace OOP
{
    class User {

        public string name { get; set; }
        public string pass { get; set; }
        public string address { get; set; }

        // Virtual keywords allow to define some logic in the parent classs
        // that can be overwritten in the child class to define new level of implementation.
        public virtual void Validate()
        {
            CheckName();
            CheckAddress();
        }

        //method overloading means same method with different signature.
        public virtual void Validate(bool strict) { 
        
            //our own loggic
        }
        public virtual void Validate(bool strict, int userId  )
        {
            //our own loggic
        }
        private void CheckName()
        {
            Console.WriteLine("Validate username");
        }
        private void CheckAddress()
        {
            Console.WriteLine("Validate User Address");
        }
    }
}
