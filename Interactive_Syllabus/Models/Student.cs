using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; } //StudentID Öğrencinin kendi benzersiz öğrenci numarasıdır.
        public string StudentName { get; set;}
        public string StudentSurname { get; set;}
        public string StudentEmail { get; set;}
        public string StudentPassword { get; set;}
        public StudentsClass StudentClass { get; set;}
        public StudentsSection StudentsSection { get; set;}
    }
}
