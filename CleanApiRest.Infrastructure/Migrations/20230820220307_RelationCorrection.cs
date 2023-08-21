using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanApiRest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarStores_Cars_CarId",
                table: "CarStores");

            migrationBuilder.DropIndex(
                name: "IX_CarStores_CarId",
                table: "CarStores");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarStoreId",
                table: "Cars",
                column: "CarStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarStores_CarStoreId",
                table: "Cars",
                column: "CarStoreId",
                principalTable: "CarStores",
                principalColumn: "CarStoreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarStores_CarStoreId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarStoreId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_CarStores_CarId",
                table: "CarStores",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarStores_Cars_CarId",
                table: "CarStores",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
