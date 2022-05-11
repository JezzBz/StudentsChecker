using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsChecker.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "SubjectStudent",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Admitted",
                table: "Students",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "SubjectStudent");

            migrationBuilder.DropColumn(
                name: "Admitted",
                table: "Students");
        }
    }
}
