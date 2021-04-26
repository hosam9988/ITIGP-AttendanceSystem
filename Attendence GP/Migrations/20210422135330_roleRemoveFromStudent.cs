using Microsoft.EntityFrameworkCore.Migrations;

namespace Attendence_GP.Migrations
{
    public partial class roleRemoveFromStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Role_RoleId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_RoleId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_RoleId",
                table: "Student",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Role_RoleId",
                table: "Student",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
