using Microsoft.EntityFrameworkCore.Migrations;

namespace music_restapi.Migrations
{
    public partial class ChangeTableAndSeedSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "Language", "Title" },
                values: new object[] { 1, "2:30", "Eng", "A" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "Language", "Title" },
                values: new object[] { 2, "3:00", "Viet", "B" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Songs");
        }
    }
}
