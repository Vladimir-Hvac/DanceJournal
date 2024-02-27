using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DanceJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNotificationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Invitations_InvitationId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "InvitationNotificationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_InvitationId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "InvitationId",
                table: "Notifications");

            migrationBuilder.CreateTable(
                name: "InvitationStatuses",
                columns: table => new
                {
                    InvitationId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_InvitationStatuses_Invitations_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvitationStatuses_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationInvitations",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "integer", nullable: false),
                    InvitationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationInvitations", x => new { x.NotificationId, x.InvitationId });
                    table.ForeignKey(
                        name: "FK_NotificationInvitations_Invitations_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationInvitations_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationStatuses",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_NotificationStatuses_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationStatuses_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvitationStatuses_InvitationId",
                table: "InvitationStatuses",
                column: "InvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationStatuses_ReceiverId",
                table: "InvitationStatuses",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationInvitations_InvitationId",
                table: "NotificationInvitations",
                column: "InvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationStatuses_NotificationId",
                table: "NotificationStatuses",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationStatuses_ReceiverId",
                table: "NotificationStatuses",
                column: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvitationStatuses");

            migrationBuilder.DropTable(
                name: "NotificationInvitations");

            migrationBuilder.DropTable(
                name: "NotificationStatuses");

            migrationBuilder.AddColumn<int>(
                name: "InvitationId",
                table: "Notifications",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvitationNotificationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvitationId = table.Column<int>(type: "integer", nullable: false),
                    NotificationId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationNotificationStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvitationNotificationStatuses_Invitations_InvitationId",
                        column: x => x.InvitationId,
                        principalTable: "Invitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvitationNotificationStatuses_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvitationNotificationStatuses_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_InvitationId",
                table: "Notifications",
                column: "InvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationNotificationStatuses_InvitationId",
                table: "InvitationNotificationStatuses",
                column: "InvitationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationNotificationStatuses_NotificationId",
                table: "InvitationNotificationStatuses",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationNotificationStatuses_ReceiverId",
                table: "InvitationNotificationStatuses",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Invitations_InvitationId",
                table: "Notifications",
                column: "InvitationId",
                principalTable: "Invitations",
                principalColumn: "Id");
        }
    }
}
