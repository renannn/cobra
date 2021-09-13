using Microsoft.EntityFrameworkCore.Migrations;

namespace Cobra.Infrastructure.Migrations
{
    public partial class FixMessages1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetUserId",
                schema: "dbo",
                table: "tbl_users_messages",
                newName: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_messages_ReceiverUserId",
                schema: "dbo",
                table: "tbl_users_messages",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_messages_SenderUserId",
                schema: "dbo",
                table: "tbl_users_messages",
                column: "SenderUserId");

            migrationBuilder.AddForeignKey(
                name: "cnst_users_messages_receiver_user",
                schema: "dbo",
                table: "tbl_users_messages",
                column: "ReceiverUserId",
                principalSchema: "dbo",
                principalTable: "tbl_users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "cnst_users_messages_sender_user",
                schema: "dbo",
                table: "tbl_users_messages",
                column: "SenderUserId",
                principalSchema: "dbo",
                principalTable: "tbl_users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "cnst_users_messages_receiver_user",
                schema: "dbo",
                table: "tbl_users_messages");

            migrationBuilder.DropForeignKey(
                name: "cnst_users_messages_sender_user",
                schema: "dbo",
                table: "tbl_users_messages");

            migrationBuilder.DropIndex(
                name: "IX_tbl_users_messages_ReceiverUserId",
                schema: "dbo",
                table: "tbl_users_messages");

            migrationBuilder.DropIndex(
                name: "IX_tbl_users_messages_SenderUserId",
                schema: "dbo",
                table: "tbl_users_messages");

            migrationBuilder.RenameColumn(
                name: "ReceiverUserId",
                schema: "dbo",
                table: "tbl_users_messages",
                newName: "TargetUserId");
        }
    }
}
