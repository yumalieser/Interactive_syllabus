﻿// <auto-generated />
using System;
using Interactive_Syllabus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Interactive_Syllabus.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240921005329_mig_fix")]
    partial class mig_fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Interactive_Syllabus.Models.Academician", b =>
                {
                    b.Property<int>("AcademicianID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicianID"));

                    b.Property<string>("AcademicianDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademicianEMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademicianName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademicianPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademicianSection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentsSectionID")
                        .HasColumnType("int");

                    b.HasKey("AcademicianID");

                    b.HasIndex("StudentsSectionID");

                    b.ToTable("Academicianes");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.Lesson", b =>
                {
                    b.Property<string>("LessonID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AcademicianID")
                        .HasColumnType("int");

                    b.Property<int>("LessonAKTS")
                        .HasColumnType("int");

                    b.Property<int>("LessonCredit")
                        .HasColumnType("int");

                    b.Property<string>("LessonDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LessonID");

                    b.HasIndex("AcademicianID");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<int>("StudentClassStudentsClassID")
                        .HasColumnType("int");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentsSectionID")
                        .HasColumnType("int");

                    b.HasKey("StudentID");

                    b.HasIndex("StudentClassStudentsClassID");

                    b.HasIndex("StudentsSectionID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.StudentsClass", b =>
                {
                    b.Property<int>("StudentsClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentsClassID"));

                    b.Property<string>("StudentsClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentsClassID");

                    b.ToTable("StudentsClasses");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.StudentsSection", b =>
                {
                    b.Property<int>("StudentsSectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentsSectionID"));

                    b.Property<string>("StudentsSectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentsSectionID");

                    b.ToTable("StudentsSections");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.Syllabus", b =>
                {
                    b.Property<int>("SyllabusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SyllabusID"));

                    b.Property<int>("LessonDay")
                        .HasColumnType("int");

                    b.Property<string>("LessonID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LessonTime")
                        .HasColumnType("int");

                    b.Property<int>("StudentsClassID")
                        .HasColumnType("int");

                    b.Property<int>("StudentsSectionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SyllabusCreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SyllabusID");

                    b.HasIndex("LessonID");

                    b.HasIndex("StudentsClassID");

                    b.HasIndex("StudentsSectionID");

                    b.ToTable("Syllabus");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.Academician", b =>
                {
                    b.HasOne("Interactive_Syllabus.Models.StudentsSection", null)
                        .WithMany("Academician")
                        .HasForeignKey("StudentsSectionID");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.Lesson", b =>
                {
                    b.HasOne("Interactive_Syllabus.Models.Academician", "academician")
                        .WithMany("Lessons")
                        .HasForeignKey("AcademicianID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("academician");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.Student", b =>
                {
                    b.HasOne("Interactive_Syllabus.Models.StudentsClass", "StudentClass")
                        .WithMany("Students")
                        .HasForeignKey("StudentClassStudentsClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interactive_Syllabus.Models.StudentsSection", "StudentsSection")
                        .WithMany("Students")
                        .HasForeignKey("StudentsSectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentClass");

                    b.Navigation("StudentsSection");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.Syllabus", b =>
                {
                    b.HasOne("Interactive_Syllabus.Models.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interactive_Syllabus.Models.StudentsClass", "StudentsClass")
                        .WithMany()
                        .HasForeignKey("StudentsClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interactive_Syllabus.Models.StudentsSection", "StudentsSection")
                        .WithMany()
                        .HasForeignKey("StudentsSectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("StudentsClass");

                    b.Navigation("StudentsSection");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.Academician", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.StudentsClass", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Interactive_Syllabus.Models.StudentsSection", b =>
                {
                    b.Navigation("Academician");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
