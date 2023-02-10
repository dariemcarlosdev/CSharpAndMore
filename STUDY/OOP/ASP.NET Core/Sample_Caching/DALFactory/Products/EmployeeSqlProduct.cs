using Sample_Caching.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Caching_Logging.DALFactory

{
    //This is a product in Factory Method DP.    //This is a product in Factory Method DP.

    public class EmployeeSqlProduct : IDbContext
    {      
        public List<Employee> GetDbContext()
        {
            var employees = new List<Employee>() {

                new Employee()
                {
                Id = 1
                ,Name ="Employee1"
                ,Address ="Address 1"
                ,Email ="123@email.com"
                ,LastName ="Last Name 1"
                ,ProviderName = "SQL"
                },
                 new Employee()
                {
                Id = 2
                ,Name ="Employee2"
                ,Address ="Address 2"
                ,Email ="456@email.com"
                ,LastName ="Last Name 1"
                ,ProviderName="SQL"
                }
            };
            return employees;
        }
    }
}
