using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_api.Migrations
{
    /// <inheritdoc />
    public partial class mssqlazure_migration_548 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chapter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chapter__3214EC07C3DF2C9B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserTran__3214EC075E7CC233", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChapterID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Video = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lesson__3214EC076522C6E0", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Lesson__ChapterI__5EBF139D",
                        column: x => x.ChapterID,
                        principalTable: "Chapter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    Prompt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CodeQuestion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__3214EC070D558CE1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Question__Lesson__619B8048",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProgress",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserProg__DCB8E346F122C3D8", x => new { x.QuestionID, x.UserID });
                    table.ForeignKey(
                        name: "FK__UserProgr__Quest__66603565",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ChapterID",
                table: "Lesson",
                column: "ChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_LessonID",
                table: "Question",
                column: "LessonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProgress");

            migrationBuilder.DropTable(
                name: "UserTransaction");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "Chapter");
        }
    }
}
