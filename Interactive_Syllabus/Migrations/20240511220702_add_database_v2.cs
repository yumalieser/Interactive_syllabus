using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interactive_Syllabus.Migrations
{
    /// <inheritdoc />
    public partial class add_database_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicianStudentsClass");

            migrationBuilder.DropTable(
                name: "AcademicianStudentsSection");

            migrationBuilder.DropTable(
                name: "StudentsClassStudentsSection");

            migrationBuilder.AddColumn<int>(
                name: "StudentsClassID",
                table: "Academicianes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsSectionID",
                table: "Academicianes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Academicianes_StudentsClassID",
                table: "Academicianes",
                column: "StudentsClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Academicianes_StudentsSectionID",
                table: "Academicianes",
                column: "StudentsSectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Academicianes_StudentsClasses_StudentsClassID",
                table: "Academicianes",
                column: "StudentsClassID",
                principalTable: "StudentsClasses",
                principalColumn: "StudentsClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Academicianes_StudentsSections_StudentsSectionID",
                table: "Academicianes",
                column: "StudentsSectionID",
                principalTable: "StudentsSections",
                principalColumn: "StudentsSectionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Academicianes_StudentsClasses_StudentsClassID",
                table: "Academicianes");

            migrationBuilder.DropForeignKey(
                name: "FK_Academicianes_StudentsSections_StudentsSectionID",
                table: "Academicianes");

            migrationBuilder.DropIndex(
                name: "IX_Academicianes_StudentsClassID",
                table: "Academicianes");

            migrationBuilder.DropIndex(
                name: "IX_Academicianes_StudentsSectionID",
                table: "Academicianes");

            migrationBuilder.DropColumn(
                name: "StudentsClassID",
                table: "Academicianes");

            migrationBuilder.DropColumn(
                name: "StudentsSectionID",
                table: "Academicianes");

            migrationBuilder.CreateTable(
                name: "AcademicianStudentsClass",
                columns: table => new
                {
                    AcademicianID = table.Column<int>(type: "int", nullable: false),
                    StudentsClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicianStudentsClass", x => new { x.AcademicianID, x.StudentsClassID });
                    table.ForeignKey(
                        name: "FK_AcademicianStudentsClass_Academicianes_AcademicianID",
                        column: x => x.AcademicianID,
                        principalTable: "Academicianes",
                        principalColumn: "AcademicianID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicianStudentsClass_StudentsClasses_StudentsClassID",
                        column: x => x.StudentsClassID,
                        principalTable: "StudentsClasses",
                        principalColumn: "StudentsClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicianStudentsSection",
                columns: table => new
                {
                    AcademicianID = table.Column<int>(type: "int", nullable: false),
                    StudentsSectionsStudentsSectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicianStudentsSection", x => new { x.AcademicianID, x.StudentsSectionsStudentsSectionID });
                    table.ForeignKey(
                        name: "FK_AcademicianStudentsSection_Academicianes_AcademicianID",
                        column: x => x.AcademicianID,
                        principalTable: "Academicianes",
                        principalColumn: "AcademicianID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicianStudentsSection_StudentsSections_StudentsSectionsStudentsSectionID",
                        column: x => x.StudentsSectionsStudentsSectionID,
                        principalTable: "StudentsSections",
                        principalColumn: "StudentsSectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsClassStudentsSection",
                columns: table => new
                {
                    StudentsClassID = table.Column<int>(type: "int", nullable: false),
                    StudentsSectionsStudentsSectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsClassStudentsSection", x => new { x.StudentsClassID, x.StudentsSectionsStudentsSectionID });
                    table.ForeignKey(
                        name: "FK_StudentsClassStudentsSection_StudentsClasses_StudentsClassID",
                        column: x => x.StudentsClassID,
                        principalTable: "StudentsClasses",
                        principalColumn: "StudentsClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsClassStudentsSection_StudentsSections_StudentsSectionsStudentsSectionID",
                        column: x => x.StudentsSectionsStudentsSectionID,
                        principalTable: "StudentsSections",
                        principalColumn: "StudentsSectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicianStudentsClass_StudentsClassID",
                table: "AcademicianStudentsClass",
                column: "StudentsClassID");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicianStudentsSection_StudentsSectionsStudentsSectionID",
                table: "AcademicianStudentsSection",
                column: "StudentsSectionsStudentsSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsClassStudentsSection_StudentsSectionsStudentsSectionID",
                table: "StudentsClassStudentsSection",
                column: "StudentsSectionsStudentsSectionID");
        }
    }
}
