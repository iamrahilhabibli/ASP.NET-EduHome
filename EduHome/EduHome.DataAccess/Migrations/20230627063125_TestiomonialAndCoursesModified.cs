using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class TestiomonialAndCoursesModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_testimonials_CourseId",
                table: "testimonials");

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                table: "testimonials",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_testimonials_CourseId",
                table: "testimonials",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_testimonials_CourseId",
                table: "testimonials");

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                table: "testimonials",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_testimonials_CourseId",
                table: "testimonials",
                column: "CourseId",
                unique: true);
        }
    }
}
