using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyDI
{
    public interface IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees();
    }
}
