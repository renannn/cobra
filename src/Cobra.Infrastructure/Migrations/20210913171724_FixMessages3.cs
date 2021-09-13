using Microsoft.EntityFrameworkCore.Migrations;

namespace Cobra.Infrastructure.Migrations
{
    public partial class FixMessages3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_users_tokens",
                schema: "dbo",
                table: "tbl_users_tokens");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "tbl_users_tokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "dbo",
                table: "tbl_users_tokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "id_token",
                schema: "dbo",
                table: "tbl_users_tokens",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_tokens_UserId",
                schema: "dbo",
                table: "tbl_users_tokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "id_token",
                schema: "dbo",
                table: "tbl_users_tokens");

            migrationBuilder.DropIndex(
                name: "IX_tbl_users_tokens_UserId",
                schema: "dbo",
                table: "tbl_users_tokens");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "tbl_users_tokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "dbo",
                table: "tbl_users_tokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_users_tokens",
                schema: "dbo",
                table: "tbl_users_tokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });
        }
    }
}
