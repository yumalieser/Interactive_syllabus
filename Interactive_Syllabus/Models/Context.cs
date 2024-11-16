using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Interactive_Syllabus.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost; database=SyllabusDB1; integrated security=true; TrustServerCertificate=True;");
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=FURKAN; database=SyllabusDB; integrated security=true; TrustServerCertificate=true");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=localhost; database=SyllabusDB; integrated security=true; TrustServerCertificate=True;");
        //}


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Academician> Academicianes { get; set; }
        public DbSet<Syllabus> Syllabus { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<StudentsClass> StudentsClasses { get; set; }
        public DbSet<StudentsSection> StudentsSections { get; set; }
        public DbSet<StudentFailedLessons> StudentFailedLessons { get; set;}
        public DbSet<TechnicalElectiveCourse> TechnicalElectiveCourses {get; set;}
    }
}
