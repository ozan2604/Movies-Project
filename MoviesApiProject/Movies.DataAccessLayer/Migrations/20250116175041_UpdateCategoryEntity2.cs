using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Serie_Categories_CategoryId",
                table: "Serie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Serie",
                table: "Serie");

            migrationBuilder.RenameTable(
                name: "Serie",
                newName: "Series");

            migrationBuilder.RenameIndex(
                name: "IX_Serie_CategoryId",
                table: "Series",
                newName: "IX_Series_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Series_Categories_CategoryId",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.RenameTable(
                name: "Series",
                newName: "Serie");

            migrationBuilder.RenameIndex(
                name: "IX_Series_CategoryId",
                table: "Serie",
                newName: "IX_Serie_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serie",
                table: "Serie",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Serie_Categories_CategoryId",
                table: "Serie",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
