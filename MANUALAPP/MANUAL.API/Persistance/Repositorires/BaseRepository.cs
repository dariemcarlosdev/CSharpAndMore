using MANUAL.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Data.Repositorires
{
    public abstract class BaseRepository
    {
        /*
        This class is just an abstract class that all our repositories I will inherit from. 
        
        */
        protected readonly ManualAPIDBContext _manualAPIDBContext;

        protected BaseRepository(ManualAPIDBContext manualAPIDBContext)
        {
            _manualAPIDBContext = manualAPIDBContext;
        }

        protected BaseRepository()
        {
            _manualAPIDBContext = new ManualAPIDBContext();
        }
    }
}
