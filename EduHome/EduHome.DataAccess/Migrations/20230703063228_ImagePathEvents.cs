using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class ImagePathEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_speakers_eventDetails_EventDetailsId",
                table: "speakers");

            migrationBuilder.AlterColumn<int>(
                name: "EventDetailsId",
                table: "speakers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_speakers_eventDetails_EventDetailsId",
                table: "speakers",
                column: "EventDetailsId",
                principalTable: "eventDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_speakers_eventDetails_EventDetailsId",
                table: "speakers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "events");

            migrationBuilder.AlterColumn<int>(
                name: "EventDetailsId",
                table: "speakers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_speakers_eventDetails_EventDetailsId",
                table: "speakers",
                column: "EventDetailsId",
                principalTable: "eventDetails",
                principalColumn: "Id");
        }
    }
}
