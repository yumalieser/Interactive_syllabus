using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
    public class StudentsSection
    {
        [Key]
        public int StudentsSectionID { get; set; }
        public string StudentsSectionName { get; set; }

        public List<Student> Students { get; set; }
        public List<Academician> Academician { get; set;}
        
    }
}
