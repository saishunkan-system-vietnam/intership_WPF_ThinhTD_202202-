using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    public partial class update_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Presenter");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Presenter");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Candidate");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Candidate",
                newName: "TitleID");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Presenter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Candidate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Candidate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_TitleID",
                table: "Candidate",
                column: "TitleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Titles_TitleID",
                table: "Candidate",
                column: "TitleID",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Titles_TitleID",
                table: "Candidate");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_TitleID",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Presenter");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Candidate");

            migrationBuilder.RenameColumn(
                name: "TitleID",
                table: "Candidate",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Presenter",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Presenter",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Candidate",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Candidate",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }
    }
}
