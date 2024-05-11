namespace Interactive_Syllabus.Models
{
    public class Objection
    {
        public int ObjectionID { get; set; }
        public string ObjectionTitle { get; set; }
        public string ObjectionContent { get; set; }
        public DateTime ObjectionCreateDate { get; set; }

        public Academician Academician { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}
