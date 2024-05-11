﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interactive_Syllabus.Migrations
{
    /// <inheritdoc />
    public partial class add_database_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academicianes",
                columns: table => new
                {
                    AcademicianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicianDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicianSection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicianPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicianEMail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academicianes", x => x.AcademicianID);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "StudentsClasses",
                columns: table => new
                {
                    StudentsClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentsClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsClasses", x => x.StudentsClassID);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSections",
                columns: table => new
                {
                    StudentsSectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentsSectionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSections", x => x.StudentsSectionID);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonCredit = table.Column<int>(type: "int", nullable: false),
                    LessonAKTS = table.Column<int>(type: "int", nullable: false),
                    AcademicianID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonID);
                    table.ForeignKey(
                        name: "FK_Lessons_Academicianes_AcademicianID",
                        column: x => x.AcademicianID,
                        principalTable: "Academicianes",
                        principalColumn: "AcademicianID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentPassword = table.Column<int>(type: "int", nullable: false),
                    StudentClassStudentsClassID = table.Column<int>(type: "int", nullable: false),
                    StudentsSectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_StudentsClasses_StudentClassStudentsClassID",
                        column: x => x.StudentClassStudentsClassID,
                        principalTable: "StudentsClasses",
                        principalColumn: "StudentsClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_StudentsSections_StudentsSectionID",
                        column: x => x.StudentsSectionID,
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

            migrationBuilder.CreateTable(
                name: "Syllabus",
                columns: table => new
                {
                    SyllabusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonTime = table.Column<int>(type: "int", nullable: false),
                    LessonDay = table.Column<int>(type: "int", nullable: false),
                    SyllabusCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentsClassID = table.Column<int>(type: "int", nullable: false),
                    StudentsSectionID = table.Column<int>(type: "int", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabus", x => x.SyllabusID);
                    table.ForeignKey(
                        name: "FK_Syllabus_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Syllabus_StudentsClasses_StudentsClassID",
                        column: x => x.StudentsClassID,
                        principalTable: "StudentsClasses",
                        principalColumn: "StudentsClassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Syllabus_StudentsSections_StudentsSectionID",
                        column: x => x.StudentsSectionID,
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
                name: "IX_Lessons_AcademicianID",
                table: "Lessons",
                column: "AcademicianID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentClassStudentsClassID",
                table: "Students",
                column: "StudentClassStudentsClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentsSectionID",
                table: "Students",
                column: "StudentsSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsClassStudentsSection_StudentsSectionsStudentsSectionID",
                table: "StudentsClassStudentsSection",
                column: "StudentsSectionsStudentsSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabus_LessonID",
                table: "Syllabus",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabus_StudentsClassID",
                table: "Syllabus",
                column: "StudentsClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabus_StudentsSectionID",
                table: "Syllabus",
                column: "StudentsSectionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicianStudentsClass");

            migrationBuilder.DropTable(
                name: "AcademicianStudentsSection");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudentsClassStudentsSection");

            migrationBuilder.DropTable(
                name: "Syllabus");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "StudentsClasses");

            migrationBuilder.DropTable(
                name: "StudentsSections");

            migrationBuilder.DropTable(
                name: "Academicianes");
        }
    }
}
