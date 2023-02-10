using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Caching_Logging.DALFactory
{
    //Concrete Creator:
    //Factory subclass of Abstract Factory Class that overwrite MakeDbContext() product method. And this method returns the concret product object.
    //This subclass decide which class instanciate.
    public class OracleDContextFactory : DbContextFactory

    {

       internal override IDbContext InstantiateDbContextProduct()
        {

            IDbContext dbContextOracle = new EmployeeOracleProduct(); //The subclass decide which class instantiate.
            return dbContextOracle;
        }
    }
}
