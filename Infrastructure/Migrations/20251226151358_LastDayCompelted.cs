using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LastDayCompelted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HobbyCompletions_HobbyId",
                table: "HobbyCompletions");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCompletedDate",
                table: "Hobbies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HobbyCompletions_HobbyId_UserId_DateCompleted",
                table: "HobbyCompletions",
                columns: new[] { "HobbyId", "UserId", "DateCompleted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HobbyCompletions_HobbyId_UserId_DateCompleted",
                table: "HobbyCompletions");

            migrationBuilder.DropColumn(
                name: "LastCompletedDate",
                table: "Hobbies");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyCompletions_HobbyId",
                table: "HobbyCompletions",
                column: "HobbyId");
        }
    }
}
