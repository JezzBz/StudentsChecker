using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsChecker.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherFcs",
                table: "SubjectStudent",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherFcs",
                table: "SubjectStudent");
        }
    }
}
