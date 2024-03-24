using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanceJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToSubsciptionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SubscriptionTypes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SubscriptionTypes");
        }
    }
}
