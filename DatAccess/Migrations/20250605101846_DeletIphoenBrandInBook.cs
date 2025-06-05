using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeletIphoenBrandInBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountsCodes",
                table: "DiscountsCodes");

            //migrationBuilder.DropColumn(
            //    name: "IphoneBrandHomePage",
            //    table: "Books");

            migrationBuilder.RenameTable(
                name: "DiscountsCodes",
                newName: "DiscountCodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountCodes",
                table: "DiscountCodes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountCodes",
                table: "DiscountCodes");

            migrationBuilder.RenameTable(
                name: "DiscountCodes",
                newName: "DiscountsCodes");

            migrationBuilder.AddColumn<bool>(
                name: "IphoneBrandHomePage",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountsCodes",
                table: "DiscountsCodes",
                column: "Id");
        }
    }
}
