using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MANUAL.API.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNo = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Jobs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTask",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    TasksTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTask", x => new { x.EmployeesId, x.TasksTaskId });
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Tasks_TasksTaskId",
                        column: x => x.TasksTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeNo", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, 2222222, "zzzzzzzz", "DASDASD54" },
                    { 2, 3333333, "fafasdsd", "zasfsdffsd" },
                    { 3, 3333333, "fafasdsd", "zasfsdffsd" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CompletedDate", "CreatedDate", "Description", "DueDate", "Jobs", "StartedOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "dadsa", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "dadasdas,dadsad", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "dadsa", new DateTime(2022, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "dadsad,dadasd", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_TasksTaskId",
                table: "EmployeeTask",
                column: "TasksTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTask");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
