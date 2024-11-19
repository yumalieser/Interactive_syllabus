using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
    public class TechnicalElectiveCourse 
    {

		[Key] public int CourseID {get; set;}
        public string CourseName {get; set;}
    }
}
