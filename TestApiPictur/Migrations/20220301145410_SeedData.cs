using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApiPictur.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pictur",
                columns: new[] { "PicturId", "Leter", "Title" },
                values: new object[] { 1, "xin chao", "hello" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pictur",
                keyColumn: "PicturId",
                keyValue: 1);
        }
    }
}
