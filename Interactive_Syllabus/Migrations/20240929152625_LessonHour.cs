using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interactive_Syllabus.Migrations
{
    /// <inheritdoc />
    public partial class LessonHour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LessonHour",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonHour",
                table: "Lessons");
        }
    }
}
