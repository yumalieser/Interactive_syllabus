using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
    public class StudentsClass
    {
        [Key]
        public int StudentsClassID { get; set; }
        public string StudentsClassName { get; set; }

        List<Student> Students { get; set; }
        List<StudentsSection> StudentsSections { get; set;}
        List<Academician> Academician { get; set; }

    }
}
