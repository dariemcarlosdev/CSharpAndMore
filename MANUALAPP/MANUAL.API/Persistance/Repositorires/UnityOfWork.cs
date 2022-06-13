using MANUAL.API.Domain.Repository;
using MANUAL.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Data.Repositorires
{
    //Implementing Unit of Work Pattern, which consist of this class receive our Context instance as a dependency and expose methods to Start, Complete or Abort transactions.
    public class UnityOfWork :   IUnityOfWork
    {
        private readonly ManualAPIDBContext _manualAPIDBContext;

        public UnityOfWork(ManualAPIDBContext manualAPIDBContext)
        {
            _manualAPIDBContext = manualAPIDBContext;
        }

        //It just the class inherit from Abstract Class BaseRepository

        //public UnityOfWork(ManualAPIDBContext manualAPIDBContext) : base(manualAPIDBContext)
        //{ 
        //}

        public void Abort()
        {
        }
        //This example only implement this Method that will only save all change into database after I finish modifiying it using the repository.

        public async Task SaveAsync()
        {
            await _manualAPIDBContext.SaveChangesAsync();
        }
        
        // release all allocated resources for this context when update/insert/remove were completed. 

        public async Task Dispose()
        {
            await _manualAPIDBContext.DisposeAsync();
        }

        public void Start()
        {
        }
    }
}
