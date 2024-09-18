﻿using System.ComponentModel.DataAnnotations;

namespace Interactive_Syllabus.Models
{
    public class Lesson
    {
        [Key]
        public string LessonID { get; set; }
        public string LessonName { get; set;}
        public string? LessonDescription { get; set;}
        public int LessonCredit { get; set; }
        public int LessonAKTS { get; set; }

        public Academician academician { get; set; }
    }
}
