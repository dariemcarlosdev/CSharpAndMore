using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaUnitTest
{
    public class Reservation
    {
        public  User MadeBy { get; set; }

        public bool CanBeCancelledBy(User user)
        {
            //if (user.isAdmin)
            //{
            //    return true;
            //}

            //if (MadeBy == user)
            //{
            //    return true;
            //}

            //Refactoring the Method and run the Unit Test to inspect if something is broken when it was refactored.

            //if (user.isAdmin || MadeBy == user)
            //{
            //    return true;
            //}

            //return false;

            //Another refactoring code step to make the code cleaner.

            return (user.isAdmin || MadeBy == user);

        }


    }
}
