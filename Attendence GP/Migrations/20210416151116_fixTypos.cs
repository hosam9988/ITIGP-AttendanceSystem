using Microsoft.EntityFrameworkCore.Migrations;

namespace Attendence_GP.Migrations
{
    public partial class fixTypos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ttack_Action_ID",
                table: "Student",
                newName: "Track_Action_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Ttack_Action_ID",
                table: "Student",
                newName: "IX_Student_Track_Action_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Track_Action_ID",
                table: "Student",
                newName: "Ttack_Action_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Track_Action_ID",
                table: "Student",
                newName: "IX_Student_Ttack_Action_ID");
        }
    }
}
