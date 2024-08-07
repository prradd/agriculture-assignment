using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignments.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    IsRepeating = table.Column<bool>(nullable: false),
                    TaskTypeId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    CompleteDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_TaskTypeId",
                table: "ToDoItems",
                column: "TaskTypeId");

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "משימה אישית" });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "משימת עבודה" });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "משימת לימודים" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DropTable(
                name: "TaskTypes");
        }
    }
}
