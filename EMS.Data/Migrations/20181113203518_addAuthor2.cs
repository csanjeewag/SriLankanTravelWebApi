using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class addAuthor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "PageDetails",
                newName: "User");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "PageDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageDetails_User",
                table: "PageDetails",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_PageDetails_Users_User",
                table: "PageDetails",
                column: "User",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageDetails_Users_User",
                table: "PageDetails");

            migrationBuilder.DropIndex(
                name: "IX_PageDetails_User",
                table: "PageDetails");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "PageDetails",
                newName: "UserEmail");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "PageDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
