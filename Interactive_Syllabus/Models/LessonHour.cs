namespace Interactive_Syllabus.Models
{
    public class LessonHour
    {
        public int LessonHourID {get; set;}
        public int LessonHourTime {get; set;}

        public Lesson Lesson {get; set;}
    }
}