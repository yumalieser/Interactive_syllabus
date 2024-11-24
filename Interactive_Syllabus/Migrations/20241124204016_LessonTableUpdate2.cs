using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interactive_Syllabus.Migrations
{
    /// <inheritdoc />
    public partial class LessonTableUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ClassroomID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassroomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassroomCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ClassroomID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classrooms");
        }
    }
}
