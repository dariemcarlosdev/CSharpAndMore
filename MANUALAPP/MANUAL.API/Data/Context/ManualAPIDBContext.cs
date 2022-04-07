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
            modelBuilder.Entity<Models.Task>().HasData(
                new Models.Task() {TaskId=1,CompletedDate =  DateTime.Parse("03/12/2022") , CreatedDate = DateTime.Parse("03/02/22"),Description = "dadsa", DueDate= DateTime.Parse("03/23/22"), Jobs="dadasdas,dadsad"},
                new Models.Task() { TaskId=2,CompletedDate = DateTime.Parse("02/12/2022"), CreatedDate = DateTime.Parse("02/02/22"), Description = "dadsa", DueDate = DateTime.Parse("02/23/22"), Jobs = "dadsad,dadasd" }
                ) ;
            modelBuilder.Entity<Employee>().HasData(
                new Employee() {Id=1, EmployeeNo = 2222222, LastName="DADDADAD", Name="DASDASD54", TaskId=1},
                new Employee() { Id=2,EmployeeNo = 3333333, LastName ="fafasdsd", Name = "zasfsdffsd", TaskId = 1 },
                new Employee() { Id=3,EmployeeNo = 3333333, LastName = "fafasdsd", Name = "zasfsdffsd", TaskId = 2 }
                ) ;
         

        }
    }
}
