using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kab.DemirAjans.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class SkidAndImageNameAddedToSubCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageName",
                table: "SubCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Skid",
                table: "SubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "Skid",
                table: "SubCategories");
        }
    }
}
