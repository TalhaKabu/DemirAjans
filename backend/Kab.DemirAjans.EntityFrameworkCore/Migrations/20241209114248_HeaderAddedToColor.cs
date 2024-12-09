using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kab.DemirAjans.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class HeaderAddedToColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Colors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "Colors");
        }
    }
}
