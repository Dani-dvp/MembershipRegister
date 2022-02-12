using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MembershipRegister.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Customers_winnerId",
                table: "Competitions");

            migrationBuilder.DropIndex(
                name: "IX_Competitions_winnerId",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Competitions");

            migrationBuilder.DropColumn(
                name: "winnerId",
                table: "Competitions");

            migrationBuilder.RenameColumn(
                name: "lsastName",
                table: "Customers",
                newName: "paidFor");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "winner",
                table: "Competitions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "winner",
                table: "Competitions");

            migrationBuilder.RenameColumn(
                name: "paidFor",
                table: "Customers",
                newName: "lsastName");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Competitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "winnerId",
                table: "Competitions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_winnerId",
                table: "Competitions",
                column: "winnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Customers_winnerId",
                table: "Competitions",
                column: "winnerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
