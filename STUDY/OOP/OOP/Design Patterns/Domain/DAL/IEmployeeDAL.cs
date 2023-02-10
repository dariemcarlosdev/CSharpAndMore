using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Design_Patterns.DI
{
    public interface IEmployeeDAL
    {
        public List<Employee> SelectEmployee();
    }
}
