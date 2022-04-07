using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Persistence.Context
{
    public static class DBInitializer
    {
        //Create automatic migration
        public static void Initialize(ManualAPIDBContext context) 
        {
            context.Database.Migrate();
        }
    }
}
