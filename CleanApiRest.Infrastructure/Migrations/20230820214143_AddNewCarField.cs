using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanApiRest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCarField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReleaseDate",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Cars");
        }
    }
}
