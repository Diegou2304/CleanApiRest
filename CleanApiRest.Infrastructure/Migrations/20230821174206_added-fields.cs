using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanApiRest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "CarStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "CarStores");
        }
    }
}
