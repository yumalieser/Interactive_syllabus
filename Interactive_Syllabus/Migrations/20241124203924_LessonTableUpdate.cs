using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interactive_Syllabus.Migrations
{
    /// <inheritdoc />
    public partial class LessonTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AcademicianEMail",
                table: "Academicianes",
                newName: "AcademicianEmail");

            migrationBuilder.AddColumn<int>(
                name: "LessonBaseScore",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonFailedStudentScore",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LessonHours",
                columns: table => new
                {
                    LessonHourID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonHourTime = table.Column<int>(type: "int", nullable: false),
                    LessonID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonHours", x => x.LessonHourID);
                    table.ForeignKey(
                        name: "FK_LessonHours_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "LessonID");
                });

            migrationBuilder.CreateTable(
                name: "TechnicalElectiveCourses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalElectiveCourses", x => x.CourseID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonHours_LessonID",
                table: "LessonHours",
                column: "LessonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonHours");

            migrationBuilder.DropTable(
                name: "TechnicalElectiveCourses");

            migrationBuilder.DropColumn(
                name: "LessonBaseScore",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonFailedStudentScore",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "AcademicianEmail",
                table: "Academicianes",
                newName: "AcademicianEMail");
        }
    }
}
