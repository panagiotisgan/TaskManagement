using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Tasks_TaskId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTask_Tasks_TaskId",
                table: "UserTask");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTask_TaskId",
                table: "UserTask");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TaskId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "UserTask",
                newName: "AssignmentId");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Logs",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_TaskId",
                table: "Logs",
                newName: "IX_Logs_AssignmentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 22, 14, 24, 31, 776, DateTimeKind.Utc).AddTicks(6225));

            migrationBuilder.AddColumn<long>(
                name: "AssignmentId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SeverityLevel = table.Column<int>(type: "int", nullable: false),
                    NeedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attachements = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AssignmentId",
                table: "Comments",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_Id",
                table: "Assignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Assignments_AssignmentId",
                table: "Comments",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Assignments_AssignmentId",
                table: "Logs",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Assignments_AssignmentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Assignments_AssignmentId",
                table: "Logs");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AssignmentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "UserTask",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "Logs",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_AssignmentId",
                table: "Logs",
                newName: "IX_Logs_TaskId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 22, 14, 24, 31, 776, DateTimeKind.Utc).AddTicks(6225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "TaskId",
                table: "Comments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachements = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NeedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    SeverityLevel = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTask_TaskId",
                table: "UserTask",
                column: "TaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskId",
                table: "Comments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Id",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Tasks_TaskId",
                table: "Logs",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTask_Tasks_TaskId",
                table: "UserTask",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
