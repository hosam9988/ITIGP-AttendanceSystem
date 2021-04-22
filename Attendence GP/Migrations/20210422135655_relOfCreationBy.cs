using Microsoft.EntityFrameworkCore.Migrations;

namespace Attendence_GP.Migrations
{
    public partial class relOfCreationBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_CreatedByNavigationId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CreatedByNavigationId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatedByNavigationId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CreatedBy",
                table: "Employee",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_CreatedBy",
                table: "Employee",
                column: "CreatedBy",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_CreatedBy",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CreatedBy",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByNavigationId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CreatedByNavigationId",
                table: "Employee",
                column: "CreatedByNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_CreatedByNavigationId",
                table: "Employee",
                column: "CreatedByNavigationId",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
