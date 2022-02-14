using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    public partial class update_candidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVFile",
                table: "Candidate");

            migrationBuilder.AddColumn<string>(
                name: "CVFileName",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVFileName",
                table: "Candidate");

            migrationBuilder.AddColumn<byte[]>(
                name: "CVFile",
                table: "Candidate",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
