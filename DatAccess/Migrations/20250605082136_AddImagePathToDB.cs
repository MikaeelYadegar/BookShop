using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "ImagePath",
            //    table: "MessageChats",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<bool>(
            //    name: "IphoneBrandHomePage",
            //    table: "Books",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ImagePath",
            //    table: "MessageChats");

            //migrationBuilder.DropColumn(
            //    name: "IphoneBrandHomePage",
            //    table: "Books");
        }
    }
}
