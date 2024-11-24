using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
    public class Classroom
    {
        [Key]
        public string ClassroomID {get; set;}
        public string ClassroomName {get; set;}
        public int ClassroomCapacity {get; set;}
    }
}