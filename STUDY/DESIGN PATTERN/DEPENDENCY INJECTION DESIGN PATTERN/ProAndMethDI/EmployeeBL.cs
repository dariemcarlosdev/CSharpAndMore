using System;
using System.Collections.Generic;
using System.Text;



namespace PropertyDI
{
    public class EmployeeBL
    {
        //field
        private  IEmployeeDAL _employeeDAL;

        //how we can implement the Property or you can say setter dependency injection in C#.

        //We are injecting the dependency object troughout the public property employeeDataObject. This property allow to access the instance of IEmployeeID
        public IEmployeeDAL employeeDataObject
        {
            //we are setting the object through the setter property, we can call this as Setter Dependency Injection in C#.
            set
            {
                _employeeDAL = value;
            }

            get 
            {
                if (employeeDataObject == null)
                {
                    throw new Exception("The Employee object is not initialized");
                }

                else
                {
                    return _employeeDAL;
                }
            }
        }

        public List<Employee> GetEmployees() 
        
        {

            return _employeeDAL.SelectAllEmployees();
        
        }
    }
}
