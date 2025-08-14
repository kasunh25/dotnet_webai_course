using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NET8API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "ActualHours", "EstimatedHours", "Status", "TaskName", "ToDoListId" },
                values: new object[,]
                {
                    { new Guid("65472640-b37b-45c1-8f0b-7bbbb9ece3f3"), 0.75, 0.5, "In Progress", "Water the plants", null },
                    { new Guid("d822a934-263b-41b6-815a-adaedc5ee91e"), 1.5, 1.5, "Paused", "Do laundry", null },
                    { new Guid("de47cc9d-e09e-425a-98b9-8a44698b399b"), 0.75, 1.0, "Done", "wash Dishes", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("65472640-b37b-45c1-8f0b-7bbbb9ece3f3"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("d822a934-263b-41b6-815a-adaedc5ee91e"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("de47cc9d-e09e-425a-98b9-8a44698b399b"));
        }
    }
}
