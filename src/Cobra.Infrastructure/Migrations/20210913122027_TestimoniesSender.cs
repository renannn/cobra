using Microsoft.EntityFrameworkCore.Migrations;

namespace Cobra.Infrastructure.Migrations
{
    public partial class TestimoniesSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_testimonies_SenderUserId",
                schema: "dbo",
                table: "tbl_user_testimonies",
                column: "SenderUserId");

            migrationBuilder.AddForeignKey(
                name: "cnst_testimonies_sender_user",
                schema: "dbo",
                table: "tbl_user_testimonies",
                column: "SenderUserId",
                principalSchema: "dbo",
                principalTable: "tbl_users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "cnst_testimonies_sender_user",
                schema: "dbo",
                table: "tbl_user_testimonies");

            migrationBuilder.DropIndex(
                name: "IX_tbl_user_testimonies_SenderUserId",
                schema: "dbo",
                table: "tbl_user_testimonies");
        }
    }
}
