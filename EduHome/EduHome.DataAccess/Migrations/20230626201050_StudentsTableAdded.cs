using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class StudentsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Communication",
                table: "teachersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design",
                table: "teachersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentSkills",
                table: "teachersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "teachersDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Innovation",
                table: "teachersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageSkills",
                table: "teachersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "teachersDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkypeAddress",
                table: "teachersDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeamLeaderSkills",
                table: "teachersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropColumn(
                name: "Communication",
                table: "teachersDetails");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "teachersDetails");

            migrationBuilder.DropColumn(
                name: "DevelopmentSkills",
                table: "teachersDetails");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "teachersDetails");

            migrationBuilder.DropColumn(
                name: "Innovation",
                table: "teachersDetails");

            migrationBuilder.DropColumn(
                name: "LanguageSkills",
                table: "teachersDetails");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "teachersDetails");

            migrationBuilder.DropColumn(
                name: "SkypeAddress",
                table: "teachersDetails");

            migrationBuilder.DropColumn(
                name: "TeamLeaderSkills",
                table: "teachersDetails");
        }
    }
}
