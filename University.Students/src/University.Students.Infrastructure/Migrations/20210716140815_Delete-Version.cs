using Microsoft.EntityFrameworkCore.Migrations;

namespace University.Students.Infrastructure.Migrations
{
    public partial class DeleteVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "dbo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "dbo",
                table: "Enrollments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Version",
                schema: "dbo",
                table: "Students",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Version",
                schema: "dbo",
                table: "Enrollments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
