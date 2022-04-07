﻿// <auto-generated />
using System;
using MANUAL.API.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MANUAL.API.Migrations
{
    [DbContext(typeof(ManualAPIDBContext))]
    [Migration("20220407184402_Initial_2")]
    partial class Initial_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MANUAL.API.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeNo")
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeNo = 2222222,
                            LastName = "DADDADAD",
                            MyProperty = 0,
                            Name = "DASDASD54",
                            TaskId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmployeeNo = 3333333,
                            LastName = "fafasdsd",
                            MyProperty = 0,
                            Name = "zasfsdffsd",
                            TaskId = 1
                        },
                        new
                        {
                            Id = 3,
                            EmployeeNo = 3333333,
                            LastName = "fafasdsd",
                            MyProperty = 0,
                            Name = "zasfsdffsd",
                            TaskId = 2
                        });
                });

            modelBuilder.Entity("MANUAL.API.Models.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Jobs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks", "Employee");

                    b.HasData(
                        new
                        {
                            TaskId = 1,
                            CompletedDate = new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "dadsa",
                            DueDate = new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Jobs = "dadasdas,dadsad"
                        },
                        new
                        {
                            TaskId = 2,
                            CompletedDate = new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "dadsa",
                            DueDate = new DateTime(2022, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Jobs = "dadsad,dadasd"
                        });
                });

            modelBuilder.Entity("MANUAL.API.Models.Employee", b =>
                {
                    b.HasOne("MANUAL.API.Models.Task", "Task")
                        .WithMany("Employees")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("MANUAL.API.Models.Task", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
