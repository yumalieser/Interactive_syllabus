namespace Interactive_Syllabus.Models
{
    public class Syllabus
    {
        public int SyllabusID { get; set; }
        public int LessonTime { get; set; }
        public int LessonDay { get; set; }
        public DateTime SyllabusCreateDate { get; set; }

        public StudentsClass StudentsClass { get; set; }
        public StudentsSection StudentsSection { get; set; }
        public Lesson Lesson { get; set; }
    }
}
