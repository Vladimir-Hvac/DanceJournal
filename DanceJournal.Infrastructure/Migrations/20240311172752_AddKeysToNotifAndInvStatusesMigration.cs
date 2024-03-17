using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanceJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddKeysToNotifAndInvStatusesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotificationStatuses_NotificationId",
                table: "NotificationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_InvitationStatuses_InvitationId",
                table: "InvitationStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationStatuses",
                table: "NotificationStatuses",
                columns: new[] { "NotificationId", "ReceiverId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvitationStatuses",
                table: "InvitationStatuses",
                columns: new[] { "InvitationId", "ReceiverId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationStatuses",
                table: "NotificationStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvitationStatuses",
                table: "InvitationStatuses");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationStatuses_NotificationId",
                table: "NotificationStatuses",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationStatuses_InvitationId",
                table: "InvitationStatuses",
                column: "InvitationId");
        }
    }
}
