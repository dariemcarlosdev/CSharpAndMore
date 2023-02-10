using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.Repository
{
    /*
     * REF: https://enlear.academy/repository-pattern-and-unit-of-work-with-asp-net-core-web-api-6802e1aa4f78
     *      https://www.c-sharpcorner.com/article/implementing-unit-of-work-and-repository-pattern-with-dependency-injection-in-n/
     *      
     unit of work in C# implementation manages in-memory database CRUD operations on entities as one transaction. So, if one of the operations is failed then the entire database operations will be rollback.
     The Unit of Work pattern is used to group one or more operations (usually database CRUD operations) into a single transaction or “unit of work” so that all operations either pass or fail as one unit.
     
    In simple words we can say that for a specific user action, say booking on a website, all the transactions like insert/update/delete and so on are done in one single transaction, rather than doing multiple database transactions. 
    This means, one unit of work here involves insert/update/delete operations, all in one single transaction so that all operations either pass or fail as one unit.

     Implementing Unit of Work Pattern, which consist of this class receive our Context instance as a dependency and expose method Complete transaction.

     The Unit of Work holds all the entities(Task,Employee) involved in a Business logic into a single transaction/operation using the same DbContext instantance and they either commits the transaction or rolls it back/fails.
     
    Benefits of Unit Of Work (UoW):
    
    - Reduce the Duplicate queries and codes.
    - Could increase the loosely couple with DI in the application
    - Easy to do unit testing or test-driven development (TDD)
    - Increase the abstraction level and maintain the business logic separately. 
     
     */
    public interface IUnityOfWork : IDisposable
        {

        ITaskRepository _taskRepository { get; }
        IEmployeeRepository _employeeRepository { get; }

        public Task<bool> CompleteTransactionAsync();

        }
}
