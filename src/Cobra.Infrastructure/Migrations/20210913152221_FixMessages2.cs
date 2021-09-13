using Microsoft.EntityFrameworkCore.Migrations;

namespace Cobra.Infrastructure.Migrations
{
    public partial class FixMessages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetUserId",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens",
                newName: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_itens_messagens_ReceiverUserId",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_buylists_itens_messagens_SenderUserId",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens",
                column: "SenderUserId");

            migrationBuilder.AddForeignKey(
                name: "cnst_messages_buylists_itens_receiver_user",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens",
                column: "ReceiverUserId",
                principalSchema: "dbo",
                principalTable: "tbl_users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "cnst_messages_buylists_itens_sender_user",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens",
                column: "SenderUserId",
                principalSchema: "dbo",
                principalTable: "tbl_users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "cnst_messages_buylists_itens_receiver_user",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens");

            migrationBuilder.DropForeignKey(
                name: "cnst_messages_buylists_itens_sender_user",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens");

            migrationBuilder.DropIndex(
                name: "IX_tbl_users_buylists_itens_messagens_ReceiverUserId",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens");

            migrationBuilder.DropIndex(
                name: "IX_tbl_users_buylists_itens_messagens_SenderUserId",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens");

            migrationBuilder.RenameColumn(
                name: "ReceiverUserId",
                schema: "dbo",
                table: "tbl_users_buylists_itens_messagens",
                newName: "TargetUserId");
        }
    }
}
