using System;
using System.Collections.Generic;
using System.Text;

namespace MethodDI
{
    public interface IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees();
    }
}
