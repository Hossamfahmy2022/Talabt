using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talabt.Repositery.Data.Migrations
{
    /// <inheritdoc />
    public partial class changecolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "catergoryId",
                table: "products",
                newName: "CatergoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_catergoryId",
                table: "products",
                newName: "IX_products_CatergoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CatergoryId",
                table: "products",
                newName: "catergoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_CatergoryId",
                table: "products",
                newName: "IX_products_catergoryId");
        }
    }
}
