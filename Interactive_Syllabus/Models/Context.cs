using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Interactive_Syllabus.Models
{
    public class Context:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=ACER-NITRO-ALI\\MSSQLSERVER01; database=SyllabusDB; integrated security=true; TrustServerCertificate=True;");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=FURKAN; database=SyllabusDB; integrated security=true; TrustServerCertificate=true");
        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Academician> Academicianes { get; set; }
        public DbSet<Syllabus> Syllabus { get; set;}
        public DbSet<Lesson> Lessons { get; set;}
        public DbSet<StudentsClass> StudentsClasses { get; set;}
        public DbSet<StudentsSection> StudentsSections { get; set;}
    }
}
