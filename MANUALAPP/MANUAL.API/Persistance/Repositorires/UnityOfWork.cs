using MANUAL.API.Domain.Repository;
using MANUAL.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Data.Repositorires
{
    /* Implementing Unit of Work Pattern, which consist of this class receive our Context instance as a dependency and expose methods to Start, Complete or Abort transactions.
       UnityOfWork deals with data inconsistances when any transacction is commited to the DB. E.g:

        if we have 2 Entities with respective Repositories, we do have to maintain its intances of DbContext(__manualAPIDBContext). This could lead to problems if each DBContext has its in-memory list 
       of updates to entity records. In such situation, if one Repository's CompleteTransaction files while the other success, database inconsistency will arise.
    */





    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly ManualAPIDBContext _manualAPIDBContext;

        public ITaskRepository _taskRepository { get; }

        public IEmployeeRepository _employeeRepository { get; }

        //public ITaskRepository _taskRepository { get; }
        //public IEmployeeRepository _employeeRepository { get; }

        public UnityOfWork(ManualAPIDBContext manualAPIDBContext)
        {
            _manualAPIDBContext = manualAPIDBContext;
            _employeeRepository =  new EmployeeRepository(manualAPIDBContext);
            _taskRepository = new TaskRepository(manualAPIDBContext);
        }


        public async Task<bool> CompleteTransactionAsync()
        {
           var _completeTransaction = await _manualAPIDBContext.SaveChangesAsync();

            return  _completeTransaction > 0 ? true : false;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _manualAPIDBContext.DisposeAsync();
            }
            
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // UnityOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
             Dispose(true);
            GC.SuppressFinalize(this);
        }

        //It just the class inherit from Abstract Class BaseRepository

        //public UnityOfWork(ManualAPIDBContext manualAPIDBContext) : base(manualAPIDBContext)
        //{ 
        //}

        //public void Abort()
        //{
        //}
        ////This example only implement this Method that will only save all change into database after I finish modifiying it using the repository.

        //public async Task<bool> CompleteTransactionAsync()
        //{
        //    return await _manualAPIDBContext.SaveChangesAsync() > 0;
        //}

        //// release all allocated resources for this context when update/insert/remove were completed. 

        //public async Task Dispose()
        //{
        //    await _manualAPIDBContext.DisposeAsync();
        //}

        //public void Start()
        //{
        //}

    }
}
