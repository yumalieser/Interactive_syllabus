using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Interactive_Syllabus.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Student()
        {
            return View();
        }
		[HttpPost]
		public IActionResult Academician() 
        {
            return View();
        }

		public IActionResult ResetPassword()
		{
			return View();
		}
		public IActionResult Home_En()
		{
			return View();
		}
		public IActionResult Student_En()
		{
			return View();
		}
		public IActionResult Academician_En()
		{
			return View();
		}
		public IActionResult ResetPassword_En()
		{
			return View();
		}
	}
}