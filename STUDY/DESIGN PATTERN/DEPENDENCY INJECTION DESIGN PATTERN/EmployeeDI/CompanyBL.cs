using EmployeeDI.DAL;
using EmployeeDI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDI
{
    //INJECTOR CLASS
    public class CompanyBL
    {
        //EmployeeBL Depend of CompanyDAL 
        public ICompanyDAL companyDAL;

        //Constructor Injector
        public CompanyBL(ICompanyDAL companyDAL)
        {
            this.companyDAL = companyDAL;
        }

        //public List<Employee> GetAllEmployee() {

        //    //Here I create an instance of employeeDAL and then invoke SelectAllEmployees() method in EmployeeDAL call.

        //    //This represent a tigh coupling because employeeDAL is tighly coupled to EmployeeBL, if employeeDAL changes, then  EmployeeBL also needs to change.
        //    var employeeDAL = new EmployeeDAL();
        //    return employeeDAL.SelectAllEmployees();

        //------------------CLASS MODIFIED  FOR MAKING IT ABLE TO IMPLEMENT DI (code above commented)------

        public List<Employee> GetAllEmployees() {

            return companyDAL.SelectAllEmployees();
        
        }

        public List<Supervisor> GetAllSupervisors() {

            return companyDAL.SelectAllSupervisors();
        
        }
    }
}
