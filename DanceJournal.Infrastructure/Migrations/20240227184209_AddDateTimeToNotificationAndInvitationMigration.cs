using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanceJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateTimeToNotificationAndInvitationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Invitations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_LessonId",
                table: "Invitations",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_Lessons_LessonId",
                table: "Invitations",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_Lessons_LessonId",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_LessonId",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Invitations");
        }
    }
}
