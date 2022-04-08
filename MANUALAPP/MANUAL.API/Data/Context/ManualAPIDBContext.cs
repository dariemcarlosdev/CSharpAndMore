using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using MANUAL.API.Models;
using Microsoft.EntityFrameworkCore; //use DbContext for EF Core
using EF6 = System.Data.Entity; // use EF6.DbContext for the EF6 version

namespace MANUAL.API.Persistence.Context
{
    public class ManualAPIDBContext : DbContext
    {
        public ManualAPIDBContext(DbContextOptions<ManualAPIDBContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configuration for seeding data for Job
            //modelBuilder.Entity<Models.Task>().HasData(
            //    new Models.Task() { TaskId = 1, CompletedDate = DateTime.Parse("03/12/2022"), CreatedDate = DateTime.Now, Description = "dadsa", DueDate = DateTime.Parse("03/23/22"), Jobs = "dadasdas,dadsad", StartedOn = DateTime.Parse("03/23/22") },
            //    new Models.Task() { TaskId = 2, CompletedDate = DateTime.Parse("02/12/2022"), CreatedDate = DateTime.Now, Description = "dadsa", DueDate = DateTime.Parse("02/23/22"), Jobs = "dadsad,dadasd", StartedOn = DateTime.Parse("03/23/22") }
            //    );
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee() { EmployeeId = 1, EmployeeNo = 2222222, LastName = "DADDADAD", Name = "DASDASD54"},
            //    new Employee() { EmployeeId = 2, EmployeeNo = 3333333, LastName = "fafasdsd", Name = "zasfsdffsd"},
            //    new Employee() { EmployeeId = 3, EmployeeNo = 3333333, LastName = "fafasdsd", Name = "zasfsdffsd"}
            //    );

            //Creating join table with FLUENT.API
        }
    }
}
