using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using MANUAL.API.Domain.Models;
using Microsoft.EntityFrameworkCore; //use DbContext for EF Core
using EF6 = System.Data.Entity; // use EF6.DbContext for the EF6 version
using Task = MANUAL.API.Domain.Models.Task; //To avoid name convention name with Threading.Task.

namespace MANUAL.API.Persistence.Context
{
    public class ManualAPIDBContext : DbContext
    {
        public ManualAPIDBContext(DbContextOptions<ManualAPIDBContext> options) : base(options)
        {

        }

        //if you want to access EmployeeTasks data via the Employee or Task entities.For querying EmployeeTask data directly, I added  DbSet for the join table  EmployeeTasks to this context

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // both sides of the many-to-many relationship are configured using the HasOne, WithMany and HasForeignKey Fluent API methods.

            modelBuilder.Entity<EmployeeTask>()
                .HasKey( et => new { et.EmployeeId, et.TaskId });

            modelBuilder.Entity<EmployeeTask>().HasOne(et => et.Task).WithMany(t => t .EmployeeTasks).HasForeignKey(et => et.TaskId);
            modelBuilder.Entity<EmployeeTask>().HasOne(et => et.Employee).WithMany(e => e.EmployeeTasks).HasForeignKey(et => et.EmployeeId);
            

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
