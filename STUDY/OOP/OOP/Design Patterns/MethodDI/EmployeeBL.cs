using OOP.Design_Patterns.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Design_Patterns.MethodDI
{
    // In Method DI we need to supply the depedency object through a public method of the client class.
    // We need to use Method DI when the entire class does not depend on the dependency object, but a single method of the client class depends of the dependency object.
    //Advantage:
    // Allow us to develop loosely cloupled components.
    //it's very easy to swap with differents implementation of components, as long as each compoments implement the Interface type.
    class EmployeeBL
    {
        private IEmployeeDAL employeeDAL;

        public List<Employee> GetAllEmployee(IEmployeeDAL _employeeDAL) {

            employeeDAL = _employeeDAL;
            return employeeDAL.SelectEmployee();
        
        }
    }
}
