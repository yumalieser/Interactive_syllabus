namespace Interactive_Syllabus.Models
{
    public class LessonViewModel
    {
        public string LessonID { get; set; }
        public string LessonName { get; set; }
        public int LessonCredit { get; set; }
        public int LessonAKTS { get; set; }
        public string LessonDescription { get; set; }
        public int LessonAcademicianID { get; set; } // ForeignKey olarak akademisyen
    }
}
