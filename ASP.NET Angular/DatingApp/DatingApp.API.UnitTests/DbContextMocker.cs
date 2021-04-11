using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.API.UnitTests
{
    public static class ContextMocker
    {
        public static Context GetContext()
        {
            
            //Create options for DbContext instance
            /*
            Usually, the in-memory provider is used when we write integration tests,
            This way we don’t need to connect to a real database to test the application.
            */
            var dbContextOptions = new DbContextOptionsBuilder<Context>().
            UseInMemoryDatabase(Guid.NewGuid().ToString()/*databaseName: dbName*/).
            UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).
            EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true).Options;

            //Create instance of DbContext
            var dbContext = new Context(dbContextOptions);
            
            dbContext.Seed();

            return dbContext;
        }

    }
}
