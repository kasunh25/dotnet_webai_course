using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NET8API.Migrations
{
    /// <inheritdoc />
    public partial class AddedToDOListsDummydata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ToDoListId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("65472640-b37b-45c1-8f0b-7bbbb9ece3f3"),
                column: "ToDoListId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("d822a934-263b-41b6-815a-adaedc5ee91e"),
                column: "ToDoListId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("de47cc9d-e09e-425a-98b9-8a44698b399b"),
                column: "ToDoListId",
                value: new Guid("c6b71925-8970-40b6-a752-87953538ab55"));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ToDoListId",
                table: "Tasks",
                column: "ToDoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ToDoLists_ToDoListId",
                table: "Tasks",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ToDoLists_ToDoListId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ToDoListId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ToDoListId",
                table: "Tasks");
        }
    }
}
