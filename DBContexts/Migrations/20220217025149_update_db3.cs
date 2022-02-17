using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    public partial class update_db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidate_Email");

            migrationBuilder.AddColumn<byte[]>(
                name: "Attachment",
                table: "Candidate_Apply",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Attachment_Name",
                table: "Candidate_Apply",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentEmail",
                table: "Candidate_Apply",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccept",
                table: "Candidate_Apply",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Candidate_Apply",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Candidate",
                type: "varchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Candidate",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Candidate_ApplyId = table.Column<int>(type: "int", nullable: false),
                    InterviewTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterviewLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestPoint = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contactable = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Attachment_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interview_Candidate_Apply_Candidate_ApplyId",
                        column: x => x.Candidate_ApplyId,
                        principalTable: "Candidate_Apply",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interview_Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterViewId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interview_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_interview_Employee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interview_Employee_Interview_InterViewId",
                        column: x => x.InterViewId,
                        principalTable: "Interview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interview_Candidate_ApplyId",
                table: "Interview",
                column: "Candidate_ApplyId");

            migrationBuilder.CreateIndex(
                name: "IX_interview_Employee_EmployeeId",
                table: "interview_Employee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_interview_Employee_InterViewId",
                table: "interview_Employee",
                column: "InterViewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "interview_Employee");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Candidate_Apply");

            migrationBuilder.DropColumn(
                name: "Attachment_Name",
                table: "Candidate_Apply");

            migrationBuilder.DropColumn(
                name: "ContentEmail",
                table: "Candidate_Apply");

            migrationBuilder.DropColumn(
                name: "IsAccept",
                table: "Candidate_Apply");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Candidate_Apply");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Candidate",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Candidate",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "Candidate_Email",
                columns: table => new
                {
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    Contactable = table.Column<int>(type: "int", nullable: true),
                    ContentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterviewTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    TestPoint = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate_Email", x => x.CandidateID);
                    table.ForeignKey(
                        name: "FK_Candidate_Email_Candidate_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
