using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp
{
    class School
    {
        public School()
        {
        }

        public School( int schoolNumber, string schoolName, string principalName, string address)
        {
            SchoolNumber = schoolNumber;
            SchoolName = schoolName;
            PrincipalName = principalName;
            Address = address;
        }

        public int SchoolNumber { get; set; }
        public string SchoolName { get; set; }
        public string PrincipalName { get; set; }
        public string Address { get; set; }

    }
}
