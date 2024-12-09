using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kab.DemirAjans.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class productChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Products",
                newName: "PrintExp");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(750)",
                oldMaxLength: 750);

            migrationBuilder.AddColumn<string>(
                name: "GroupCode",
                table: "Products",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupCode",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PrintExp",
                table: "Products",
                newName: "Color");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(750)",
                oldMaxLength: 750,
                oldNullable: true);
        }
    }
}
