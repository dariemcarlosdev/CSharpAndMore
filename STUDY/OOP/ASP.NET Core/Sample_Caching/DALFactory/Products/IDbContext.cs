using Sample_Caching.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Caching_Logging.DALFactory
{
    public interface IDbContext
    {
        //Methods that need to be implemented by Product subclasses.
        public List<Employee> GetDbContext();
    }
}
