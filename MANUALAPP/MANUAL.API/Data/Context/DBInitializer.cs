using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MANUAL.API.Domain.Models;
using Task = MANUAL.API.Domain.Models.Task;

namespace MANUAL.API.Persistence.Context
{
    public static class DBInitializer
    {
        //Create automatic migration
        public static void Initialize(ManualAPIDBContext context) {
            context.Database.Migrate();

        }

        public static void SeedDdata(ManualAPIDBContext context) {

            //Seeding Employees TABLE.

            var Employee1 = new Employee {EmployeeId=1, Name="dadsad",LastName="dads", EmployeeNo= 232123 };
            var Employee2 = new Employee { EmployeeId = 2, Name = "dadsad", LastName = "dads", EmployeeNo = 232123 };

            var Task1 = new Task { TaskId = 1, CompletedDate=DateTime.Now, CreatedDate=DateTime.Now, Description="dadsd", DueDate=DateTime.Now,StartedOn=DateTime.Now };
            var Task2 = new Task { TaskId = 2, CompletedDate = DateTime.Now, CreatedDate = DateTime.Now, Description = "dadsd", DueDate = DateTime.Now, StartedOn = DateTime.Now };


            //Seeding Task TABLE.



            context.SaveChanges();
        }
    }
}
