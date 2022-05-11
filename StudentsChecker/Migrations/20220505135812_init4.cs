using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsChecker.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "SubjectStudent",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStudent_TeacherId",
                table: "SubjectStudent",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectStudent_Teachers_TeacherId",
                table: "SubjectStudent",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectStudent_Teachers_TeacherId",
                table: "SubjectStudent");

            migrationBuilder.DropIndex(
                name: "IX_SubjectStudent_TeacherId",
                table: "SubjectStudent");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "SubjectStudent");
        }
    }
}
