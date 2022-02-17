using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    public partial class update_mail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestPoint",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Employee",
                newName: "FullName");

            migrationBuilder.AddColumn<bool>(
                name: "IsPass",
                table: "Interview",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingRoom",
                table: "Interview",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestPoint",
                table: "Candidate_Apply",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPass",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "MeetingRoom",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "TestPoint",
                table: "Candidate_Apply");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Employee",
                newName: "LastName");

            migrationBuilder.AddColumn<int>(
                name: "TestPoint",
                table: "Interview",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
