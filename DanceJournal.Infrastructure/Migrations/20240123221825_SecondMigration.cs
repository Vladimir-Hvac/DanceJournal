using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DanceJournal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonTypes_Levels_LevelId",
                table: "LessonTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonTypes_Rooms_RoomId",
                table: "LessonTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonTypes_Users_UserId",
                table: "LessonTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonUsers_LessonTypes_LessonId",
                table: "LessonUsers");

            migrationBuilder.DropIndex(
                name: "IX_LessonTypes_LevelId",
                table: "LessonTypes");

            migrationBuilder.DropIndex(
                name: "IX_LessonTypes_RoomId",
                table: "LessonTypes");

            migrationBuilder.DropIndex(
                name: "IX_LessonTypes_UserId",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "Finish",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "Lesson_Id",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "LessonTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LessonTypes");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LessonTypes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonTypeId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Finish = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LevelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_LessonTypes_LessonTypeId",
                        column: x => x.LessonTypeId,
                        principalTable: "LessonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonTypeId",
                table: "Lessons",
                column: "LessonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LevelId",
                table: "Lessons",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_RoomId",
                table: "Lessons",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_UserId",
                table: "Lessons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonUsers_Lessons_LessonId",
                table: "LessonUsers",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonUsers_Lessons_LessonId",
                table: "LessonUsers");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LessonTypes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "LessonTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Finish",
                table: "LessonTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lesson_Id",
                table: "LessonTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "LessonTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "LessonTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "LessonTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LessonTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonTypes_LevelId",
                table: "LessonTypes",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTypes_RoomId",
                table: "LessonTypes",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTypes_UserId",
                table: "LessonTypes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTypes_Levels_LevelId",
                table: "LessonTypes",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTypes_Rooms_RoomId",
                table: "LessonTypes",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonTypes_Users_UserId",
                table: "LessonTypes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonUsers_LessonTypes_LessonId",
                table: "LessonUsers",
                column: "LessonId",
                principalTable: "LessonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
