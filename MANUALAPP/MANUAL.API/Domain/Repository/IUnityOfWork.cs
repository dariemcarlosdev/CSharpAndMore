using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.Repository
{
    /*
     unit of work in C# implementation manages in-memory database CRUD operations on entities as one transaction. So, if one of the operations is failed then the entire database operations will be rollback.
     The Unit of Work pattern is used to group one or more operations (usually database CRUD operations) into a single transaction or “unit of work” so that all operations either pass or fail as one unit.
     
    In simple words we can say that for a specific user action, say booking on a website, all the transactions like insert/update/delete and so on are done in one single transaction, rather than doing multiple database transactions. 
    This means, one unit of work here involves insert/update/delete operations, all in one single transaction so that all operations either pass or fail as one unit.
     
     */
    interface IUnityOfWork
    {
        public void Start()
        { }

        public void Abort()
        { }
        Task CompleteAsync();
    }
}
