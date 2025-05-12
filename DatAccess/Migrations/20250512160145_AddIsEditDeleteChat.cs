using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIsEditDeleteChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MessageChats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEdited",
                table: "MessageChats",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MessageChats");

            migrationBuilder.DropColumn(
                name: "IsEdited",
                table: "MessageChats");
        }
    }
}
