using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
    public class Academician
    {
        [Key]
        public int AcademicianID { get; set; } //AcademicianID akademisyenin kendi benzersiz numarasıdır.
        public string AcademicianName { get; set;}
        public string? AcademicianDescription { get; set;}
        public string AcademicianSection { get; set;}
        public string AcademicianPassword { get; set;}
        public string AcademicianEMail { get; set;}
        
        public List<Lesson> Lessons { get; set;}
    }
}
