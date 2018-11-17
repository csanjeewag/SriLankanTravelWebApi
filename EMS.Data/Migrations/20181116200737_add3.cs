using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class add3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "PageDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "PageDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "PageDetails");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "PageDetails");
        }
    }
}
