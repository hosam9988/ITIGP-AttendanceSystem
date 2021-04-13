using Microsoft.EntityFrameworkCore.Migrations;

namespace Attendence_GP.Migrations
{
    public partial class updateSSNtoBeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Student_SSN",
                table: "Student",
                column: "SSN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Student_SSN",
                table: "Student");
        }
    }
}
