using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Sample_Caching.Controllers;
using Sample_Caching_Logging.DALFactory;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sample_Caching
{
    internal  class CacheServiceProvider : ICacheServiceProvider
    {
        //A static variable have the same value throughout all instances of a class.
        //SemaphoreSlim() Represents a lightweight alternative to Semaphore that limits the number of threads
        //that can access a resource or a pool of resources simultaneously.
        private static SemaphoreSlim _getUsersSemaphore;
        private readonly DbContextFactory _dbContextFactory;

        /* is not mandatory to initialize a read-only variable at the time of its declaration, they can also be initialized under the constructor.
        That means we can modify the read-only variable value only within a constructor.
        The behavior of read-only variables will be similar to the behavior of non-static variables in C#,
        i.e. initialized only after creating the instance of the class and once for each instance of the class is created.
        readonly variables are non-static by default ,so to access readonly variables we need an instance.
        and Readonly Variables are created once per Instance.*/

        //IMemoryCach() Represents a local in-memory cache whose values are not serialized.
        private readonly IMemoryCache _cache;



        //Static Constructor
        //Static Constructor
        //Executed only once
        //First block of code to be executed inside a class
        //Before Main Method body start executing, this constructor will execute
        static CacheServiceProvider()  
        {
            /*This is a static block
            we can access non static members X with the help of the object
            We can access the static member directly or through class name
            */

            //A semaphore is a data type that is used for synchronizing get access to a share resource from multiple threads.
            //Instantiate a Singleton of the Semaphore with a value of 1.
            //This means that only 1 thread can be granted access to the shared resource at a time.
            //This is a Mutex Semaphore.A Mutex is essentially a semaphore with a value of 1.
            //A Mutex(binary semaphore) cannot be released to more than one thread at the same time. As long as some thread has the mutex, the others must wait.


            _getUsersSemaphore = new SemaphoreSlim(1, 1);
            Console.WriteLine("Static Constructor initialized");
        }
        //Non-Static Constructor
        //Executed once per object
        //When we create an instance, this constructor will execute.
        public CacheServiceProvider(IMemoryCache memoryCache, DbContextFactory dbContextFactory)
        {
            //we can access the non-static members directly or through this keyword
            this._cache = memoryCache;
            this._dbContextFactory = dbContextFactory;
            Console.WriteLine("Public Constructor Initialized ");
        }

        public  async Task<List<Employee>> GetDataCachedResponseAsync() { 
            try
            {
               
               return await GetDataCachedInMemoryAsync(_getUsersSemaphore, CacheKeys.Employees);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<List<Employee>> GetDataCachedInMemoryAsync( SemaphoreSlim semaphore, string cacheKey)
        {
            var employees = new List<Employee> ();

            /// <Summary>
            /// Summary:
            ///     Gets the item associated with this key if present.           
            /// Parameters:
            ///   key:
            ///    An object identifying the requested entry.
            ///
            /// Value:
            ///    The located value or null.
            ///
            /// Returns:
            ///    True if the key was found.
            /// </Summary >
            
            // we are checking if the cache has value or not.
            bool IsAvailable = _cache.TryGetValue(cacheKey, out employees/* we would used out List<Employee> employees*/);

            //If the value is available in the cache,
            //then getting the value from the cache and send response to the user
            //else then asynchronously wait to enter the Semaphore.
            if (IsAvailable)
            {
                return employees;
            }
            try
            {
                    //Asynchronously wait to enter the Semaphore. If no-thread has been granted access to the Semaphore, 
                    //code execution will proceed, otherwise this thread has been granted access to the Semaphore, it waits here until the semaphore is released.
                    //Calling WaitAsync on the semaphore, Return a task that will be completed when the thread has been granted access to the Semaphore.
                    await semaphore.WaitAsync();//	Asynchronously waits to enter the SemaphoreSlim.

                //Once a thread has been granted access to the Semaphore,
                //recheck if the value has been populated previously for safety(Avoid concurrent thread access).
                IsAvailable = _cache.TryGetValue(cacheKey, out employees);
                if (IsAvailable)
                {
                    return employees;
                }
                //Still don’t have a value in the cache then, call the database and store the value in the cache

                var employeesContext =  _dbContextFactory.CreateDbContextProduct();
                employees = employeesContext.GetDbContext();
                var cacheOptions = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024
                };

                _cache.Set(cacheKey, employees, cacheOptions);

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                    //When the task is ready, release the semaphore.
                    //It is vital to ALWAYS release the semaphore when we are ready,
                    //or else we will end up with a Semaphore that is forever locked.
                    //This is why it is important to do the Release within a try...
                    //finally clause; program execution may crash or take a different path, this way you are guaranteed execution
                    semaphore.Release();
                
            }
            //Send response to the user.

            return employees;
        }

    }
}
    