using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DatingApp.API.Data;
using DatingApp.API.Model;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.UnitTests
{
    // Since We're working with In memory database for unit tests, we need to create a class to mock Context class and also add data to perform testing for Context extension methods.
    //To be clear: these unit tests do not establish a connection with SQL Server.
    public static class ContextExtensions
    {
        //Extension method to set Seed datas.
        public static void Seed(this Context dbContext)
        {
            var value1 = new Value
            {
                Name = "xasasasxsdsdsd",
                Id = 3
            };
            var value2 = new Value
            {
                Name = "fishdNew",
                Id = 4
            };
            var value3 = new Value
            {
                Name = "fishdNew",
                Id = 5
            };
            dbContext.Values.Add(value1);
            dbContext.Values.Add(value2);
            dbContext.Values.Add(value3);


            dbContext.SaveChanges();
           
            dbContext.Entry<Value>(value2).State = EntityState.Detached;

        }
    }
}
