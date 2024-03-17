using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanceJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSatisfactionLimitToInvitationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SatisfactionLimit",
                table: "Invitations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SatisfactionLimit",
                table: "Invitations");
        }
    }
}
