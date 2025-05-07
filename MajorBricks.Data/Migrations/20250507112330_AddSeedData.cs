using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MajorBricks.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Lego" });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "Id", "ArticleNumber", "ManufacturerId", "Name", "PartCount", "Year" },
                values: new object[] { 1, "75192", 1, "Millennium Falcon", 7541, 2018 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
