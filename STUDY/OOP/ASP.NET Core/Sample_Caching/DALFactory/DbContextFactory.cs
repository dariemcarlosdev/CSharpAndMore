using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Caching_Logging.DALFactory
{
    //This is my creator Factory Class, that declare the factory method.

    //Creator: Factory Class Method: Create and return an instance of the product, but subclasses will decide what product class instantiate.
    public abstract class DbContextFactory
    {
        //abstract methods.
        internal abstract IDbContext InstantiateDbContextProduct(); //Create an Instance of Product-- an Object.

        public IDbContext CreateDbContextProduct() { //Creator method: Return an Instance of Product-- an Object.
            //"this" is used to reference the current instance of a class, or an object itself, if you will
            return this.InstantiateDbContextProduct();
        }

    }
}
