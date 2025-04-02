using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBookIdFromComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_bookId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "bookId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_bookId",
                table: "Comments",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_bookId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "bookId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_bookId",
                table: "Comments",
                column: "bookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
