using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MANUAL.API.Migrations
{
    public partial class Initial_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Employee",
                table: "Tasks",
                columns: new[] { "TaskId", "CompletedDate", "Description", "DueDate", "Jobs", "StartedOn" },
                values: new object[] { 1, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "dadsa", new DateTime(2022, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "dadasdas,dadsad", null });

            migrationBuilder.InsertData(
                schema: "Employee",
                table: "Tasks",
                columns: new[] { "TaskId", "CompletedDate", "Description", "DueDate", "Jobs", "StartedOn" },
                values: new object[] { 2, new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "dadsa", new DateTime(2022, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "dadsad,dadasd", null });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeNo", "LastName", "MyProperty", "Name", "TaskId" },
                values: new object[] { 1, 2222222, "DADDADAD", 0, "DASDASD54", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeNo", "LastName", "MyProperty", "Name", "TaskId" },
                values: new object[] { 2, 3333333, "fafasdsd", 0, "zasfsdffsd", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeNo", "LastName", "MyProperty", "Name", "TaskId" },
                values: new object[] { 3, 3333333, "fafasdsd", 0, "zasfsdffsd", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Employee",
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Employee",
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: 2);
        }
    }
}
