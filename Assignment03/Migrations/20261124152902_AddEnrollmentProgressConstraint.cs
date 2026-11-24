using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment03.Migrations
{
    public partial class AddEnrollmentProgressConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Enrollment_Progress",
                table: "Enrollments",
                sql: "[Progress] >= 0 AND [Progress] <= 100");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Enrollment_Progress",
                table: "Enrollments");
        }
    }
}
