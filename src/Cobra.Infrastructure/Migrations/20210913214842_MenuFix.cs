using Microsoft.EntityFrameworkCore.Migrations;

namespace Cobra.Infrastructure.Migrations
{
    public partial class MenuFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                schema: "dbo",
                table: "tbl_roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                schema: "dbo",
                table: "tbl_roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedPath",
                schema: "dbo",
                table: "tbl_roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "dbo",
                table: "tbl_roles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                schema: "dbo",
                table: "tbl_roles");

            migrationBuilder.DropColumn(
                name: "Label",
                schema: "dbo",
                table: "tbl_roles");

            migrationBuilder.DropColumn(
                name: "NormalizedPath",
                schema: "dbo",
                table: "tbl_roles");

            migrationBuilder.DropColumn(
                name: "Path",
                schema: "dbo",
                table: "tbl_roles");
        }
    }
}
