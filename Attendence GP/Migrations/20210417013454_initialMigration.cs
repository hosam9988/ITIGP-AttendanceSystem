using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attendence_GP.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Program_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Track_Program",
                        column: x => x.Program_id,
                        principalTable: "Program",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    Created_By = table.Column<int>(type: "int", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Emplyee_Emplyee",
                        column: x => x.Created_By,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emplyee_Role",
                        column: x => x.Role_id,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track_Action",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "date", nullable: false),
                    end = table.Column<DateTime>(type: "date", nullable: false),
                    Track_Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track_Action", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Track_Action_Track",
                        column: x => x.Track_Id,
                        principalTable: "Track",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Track_Action_ID = table.Column<int>(type: "int", nullable: false),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Emplyee",
                        column: x => x.Created_By,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Track_Action",
                        column: x => x.Track_Action_ID,
                        principalTable: "Track_Action",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    AttendAt = table.Column<TimeSpan>(type: "time", nullable: true),
                    LeaveAt = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees_1", x => new { x.Student_ID, x.Date });
                    table.ForeignKey(
                        name: "FK_Attendees_Emplyee",
                        column: x => x.Created_By,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendees_Student",
                        column: x => x.Student_ID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Student_ID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    Response_type = table.Column<bool>(type: "bit", nullable: false),
                    Response_by = table.Column<int>(type: "int", nullable: true),
                    Create_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Response_Date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Permission_Emplyee",
                        column: x => x.Response_by,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_Student",
                        column: x => x.Student_ID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_Created_By",
                table: "Attendances",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Created_By",
                table: "Employee",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Role_id",
                table: "Employee",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Response_by",
                table: "Permission",
                column: "Response_by");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Student_ID",
                table: "Permission",
                column: "Student_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Created_By",
                table: "Student",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SerialNumber",
                table: "Student",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_SSN",
                table: "Student",
                column: "SSN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_Track_Action_ID",
                table: "Student",
                column: "Track_Action_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Program_id",
                table: "Track",
                column: "Program_id");

            migrationBuilder.CreateIndex(
                name: "IX_Track_Action_Track_Id",
                table: "Track_Action",
                column: "Track_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Track_Action");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Program");
        }
    }
}
