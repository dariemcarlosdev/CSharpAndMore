using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_ASP.NET_Core_App.Controllers
{
    public class ScienceStudent : IStudent
    {
        public int GetStudentCount() {

            return 30;
        }
    }
}
