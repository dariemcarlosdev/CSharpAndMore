using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MANUAL.API.Domain.Models;
using TaskEntity = MANUAL.API.Domain.Models.TaskEntity;

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

            var Employee1 = new EmployeeEntity { Name="dadsad",LastName="dads", EmployeeNo= 232123 };
            var Employee2 = new EmployeeEntity {  Name = "dadsad", LastName = "dads", EmployeeNo = 232123 };

            var Task1 = new TaskEntity {  CompletedDate=  DateTime.Now, DateOfTaskCreation= Convert.ToDateTime(DateTime.Now.ToString("MM-dd-yyyy")), Description="dadsd", DueDate=DateTime.Now,StartedOn=DateTime.Now, Jobs="dadsad, dadsa" };
            var Task2 = new TaskEntity {  CompletedDate = DateTime.Now, DateOfTaskCreation = Convert.ToDateTime(DateTime.Now.ToString("MM-dd-yyyy")), Description = "dadsd", DueDate = DateTime.Now, StartedOn = DateTime.Now, Jobs = "dadsad, dadsa" };


            //Seeding Task TABLE.

            var EmployeeTask = new EmployeeTaskEntity()  { Employee = Employee1, Task =Task1};
            var EmployeeTask1 = new EmployeeTaskEntity() { Employee = Employee1, Task = Task2 };
            var EmployeeTask3 = new EmployeeTaskEntity() { Employee = Employee2, Task = Task2 };


            context.EmployeeTasks.Add(EmployeeTask);
            context.EmployeeTasks.Add(EmployeeTask1);
            context.EmployeeTasks.Add(EmployeeTask3);



            context.SaveChanges();
        }
    }
}
