using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Sample_Caching.Controllers
{   
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ICacheServiceProvider _cacheProvider;
        //The ILogger interface has a generic type, and we use the generic type to specify the class type that we are writing logs to.
        private readonly ILogger<EmployeeController> _logger;

        private static readonly Stopwatch timer = new Stopwatch();

        //inject ILogger<HomeController> interface in the constructor of EmployeeController, 
        //we can log information using the LogInformation method.
        public EmployeeController(ICacheServiceProvider cacheProvider,[NotNull] ILogger<EmployeeController> logger) { //Attribute [NotNull] specify that output is not null, even the corresponding type allows it.

            _cacheProvider = cacheProvider;
            _logger = logger;
            
           
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("GetAllEmployees")]

        //An asynchronous tasks can complete in the background(the process or thread is not busy or blocked) and notifies when it is completed so that
        //you can move to the next task before the previous task completes.
        /*
         Async Programming can be used for the long-running task blocking code . Whenever there is a blocking piece of code that can run independently 
        of the rest of the process then in that case we can run that code as an async task. 
        This async task mode will run that piece of code on a different thread instead of the main thread 
        and the main thread can be free to keep the application in the responding state.

         Examples for long-running tasks in programming can be like reading or writing a file,
        HTTP calls to an external third party API, making database calls over the network, 
        some heavy computations on the data, writing application logs to a file etc.
         */
        public async Task<ActionResult> GetAllEmployeeAsync(){ //async it allows us to call this function asynchronously 

             timer.Start();
            _logger.LogInformation("Program Start - {0}", timer.Elapsed.ToString());
            try
            {
                _logger.LogInformation("\n Running API end point {endpoint} {veb}.", "/api/Employees/GetAllEmployees","HTTP GET REQUEST");
                //My HTTP get verbs method GetAllEmployeeAsync() that calls here GetDataCachedResponseAsync() async method,
                //awaits the GetDataCachedResponseAsync() method. So GetDataCachedResponseAsync() gets called,
                //and we reach all employees from this Async method.

                //var employees = await _cacheProvider.GetDataCachedResponseAsync();//Await: When we want to call an async function asynchronously then we use this await keyword.


                var employees = _cacheProvider.GetDataCachedResponseAsync();
                _logger.LogInformation("\n Task {0} has started - started time: {1}.", employees.Id.ToString(), timer.Elapsed.ToString());
                //I'm using Ilogger instance to log relevant events in EmployeeController.

                await employees;
                _logger.LogInformation("\n Awaiting TaskId:{0}", employees.Id.ToString());
                if (employees.IsCompleted)
                {
                    _logger.LogTrace("\n Async method GetDataCachedResponseAsync() Ended.", timer.Elapsed.ToString());
                    _logger.LogInformation("Task {0} has been completed - ended time: {1}.", employees.Id.ToString(), timer.Elapsed.ToString());
                }
                timer.Stop();
                _logger.LogInformation("\n Program End - {0}", timer.Elapsed.ToString());
                return Ok(employees);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                //IsEnabled Method– To check if a particular log level is enabled or not

                return new ContentResult()
                {
                    Content = "\n Error:" + e.Message + " .",
                    ContentType = "application/json",
                    StatusCode = 500,
                };


            }
        }

    
    }
}
