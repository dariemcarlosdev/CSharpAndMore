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
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configuration for seeding data for Job

            modelBuilder.Entity<Job>().HasData
                (
                new Job { JobId=1, JobName = "W23233", JobDescription = "DASDADADASD" },
                new Job { JobId= 2, JobName = "W1212S", JobDescription = "32323DSD" }
                );

        }
    }
}
