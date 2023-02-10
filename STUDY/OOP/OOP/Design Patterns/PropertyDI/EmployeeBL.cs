using OOP.Design_Patterns.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Design_Patterns.PropertyDI
{
    class EmployeeBL
    {
        //Private field
        private IEmployeeDAL employeeDAL;

        //public property
        //In Property dependency injection we need to inject the dependency object through the public property.
        //Here we use de default contructor of this class.
        //Here we need to use the public property EmployeeDataObject in order to access the instance of IEmployeeDAL.
        //we need use Property DI when we want to create the dependency as late as possible, or when it's required.
        public IEmployeeDAL employeeDataObject 
        {
            set {

                this.employeeDAL = value;
            
            }

            get {

                if (employeeDataObject==null)
                {
                    throw new Exception("Employee object is not initialized");
                }

                return employeeDAL;
            
            }
        
        }

        public List<Employee> GetAllEmployees() {

            return employeeDAL.SelectEmployee();
        
        }
    }
}
