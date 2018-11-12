using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class add2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_PageDetails_PageDetailsId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PageDetailsId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "PageDetailsId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageDetailId",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PageDetailId",
                table: "Images",
                column: "PageDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_PageDetails_PageDetailId",
                table: "Images",
                column: "PageDetailId",
                principalTable: "PageDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_PageDetails_PageDetailId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PageDetailId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PageDetailId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "PageDetailsId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PageDetailsId",
                table: "Images",
                column: "PageDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_PageDetails_PageDetailsId",
                table: "Images",
                column: "PageDetailsId",
                principalTable: "PageDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
