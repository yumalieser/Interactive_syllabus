using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interactive_Syllabus.Models
{
    public class Admin
    {
        //[Column(TypeName = "varchar(10)")]
        //[Key]
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminEmail { get; set; }
    }
}
