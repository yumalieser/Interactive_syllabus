using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
    public class StudentsSection
    {
        [Key]
        public int StudentsSectionID { get; set; }
        public int StudentsSectionNumber { get; set; }

        List<Student> Students { get; set; }
        List<StudentsClass> StudentsClass { get; set;}
        List<Academician> Academician { get; set;}
        
    }
}
