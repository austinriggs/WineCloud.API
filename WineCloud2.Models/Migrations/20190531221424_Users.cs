using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineCloud2.Models.Migrations
{
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BottleTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Bottles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BottleTypes_UserId",
                table: "BottleTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_UserId",
                table: "Bottles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bottles_Users_UserId",
                table: "Bottles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BottleTypes_Users_UserId",
                table: "BottleTypes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bottles_Users_UserId",
                table: "Bottles");

            migrationBuilder.DropForeignKey(
                name: "FK_BottleTypes_Users_UserId",
                table: "BottleTypes");

            migrationBuilder.DropIndex(
                name: "IX_BottleTypes_UserId",
                table: "BottleTypes");

            migrationBuilder.DropIndex(
                name: "IX_Bottles_UserId",
                table: "Bottles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BottleTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bottles");
        }
    }
}
