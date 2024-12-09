using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kab.DemirAjans.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class ColorsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "Colors");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Colors",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Colors");

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Colors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
