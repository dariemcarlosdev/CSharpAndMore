using System;
using System.Collections.Generic;
using System.Text;

namespace MethodDI
{
    public class EmployeeBL
    {
        private IEmployeeDAL employeeDAL;

        public List<Employee> GetEmployees(IEmployeeDAL _employeeDAL)
        {
            employeeDAL = _employeeDAL;

            return employeeDAL.SelectAllEmployees();
        }
    }
}
