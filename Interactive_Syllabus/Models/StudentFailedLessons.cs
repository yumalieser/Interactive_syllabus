using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
	public class StudentFailedLessons
	{
		[Key]
		public int StudentFailedLessonsID { get; set; }
		public int StudentID { get; set; }
		public Student Student { get; set; }

		public string LessonID { get; set; }
		public Lesson Lesson { get; set; }
	}
}
