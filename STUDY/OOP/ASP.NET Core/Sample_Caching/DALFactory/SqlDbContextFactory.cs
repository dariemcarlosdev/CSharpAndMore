using Sample_Caching_Logging.DALFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Caching_Logging.DALFactory
{
    //Concrete Class's Instance Creator:
    //Factory subclass of Abstract Factory Class that overwrite InstantiateDbContextProduct() Factory method.
    //And this method returns the concret product object.
    //This subclass decide which class instanciate.
    public class SqlDbContextFactory : DbContextFactory
    {
        internal override IDbContext InstantiateDbContextProduct()
        {
            IDbContext dbContextSql = new EmployeeSqlProduct();
            return dbContextSql;
        }
    }
}
