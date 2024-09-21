namespace Interactive_Syllabus.Models
{
	public class StudentFailedLessons
	{
		public int StudentID { get; set; }
		public Student Student { get; set; }

		public int LessonID { get; set; }
		public Lesson Lesson { get; set; }
	}
}
