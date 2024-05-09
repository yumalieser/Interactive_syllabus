namespace Interactive_Syllabus.Models
{
    public class Syllabus
    {
        public int SyllabusID { get; set; }
        public string SyllabusName { get; set; }
        public int LessonTime { get; set; }
        public int LessonDay { get; set; }
        public DateTime SyllabusCreateDate { get; set; }
    }
}
