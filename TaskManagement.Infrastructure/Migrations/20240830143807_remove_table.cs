using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TeamUser_TeamUserTeamId_TeamUserUserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TeamUser");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamUserTeamId_TeamUserUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamUserTeamId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamUserUserId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Assignments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Assignments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TeamUserTeamId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "TeamUserUserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TeamUser",
                columns: table => new
                {
                    TeamId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamUser", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TeamUser_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamUserTeamId_TeamUserUserId",
                table: "AspNetUsers",
                columns: new[] { "TeamUserTeamId", "TeamUserUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamUser_TeamId",
                table: "TeamUser",
                column: "TeamId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TeamUser_TeamUserTeamId_TeamUserUserId",
                table: "AspNetUsers",
                columns: new[] { "TeamUserTeamId", "TeamUserUserId" },
                principalTable: "TeamUser",
                principalColumns: new[] { "TeamId", "UserId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
