using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
    public class StudentsClass
    {
        [Key]
        public int StudentsClassID { get; set; }
        public string StudentsClassName { get; set; }

        public List<Student> Students { get; set; }

    }
}
