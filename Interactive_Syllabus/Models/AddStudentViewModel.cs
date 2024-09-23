namespace Interactive_Syllabus.Models
{
    public class AddStudentViewModel
    {
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPassword { get; set; }
        public int StudentClassID { get; set; }
        public int StudentsSectionID { get; set; }
    }
}
