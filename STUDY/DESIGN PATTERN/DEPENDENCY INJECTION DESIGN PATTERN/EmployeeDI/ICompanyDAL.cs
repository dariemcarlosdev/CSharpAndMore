using EmployeeDI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDI
{
    public interface ICompanyDAL
    {
        List<Employee> SelectAllEmployees();
        List<Supervisor> SelectAllSupervisors();
    }
}
