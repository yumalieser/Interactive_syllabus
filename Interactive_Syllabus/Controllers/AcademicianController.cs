using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interactive_Syllabus.Controllers
{
	[Authorize(Policy = "AcademicianOnly")]
	public class AcademicianController : Controller
	{
		Context _context = new Context();
		public IActionResult Panel()
		{
			return View();
		}

		/* PROFİL İŞLEMLERİ */
		public IActionResult Profile()
		{
			return View();
		}

		/* ÖĞRENCİ İŞLEMLERİ */
        [HttpGet]
        public IActionResult Students()
		{
			var ogrenciListele = _context.Students.ToList();
			return View(ogrenciListele);
		}
        [HttpGet]
        public IActionResult AddStudent()
        {
			ViewBag.Class = _context.StudentsClasses.ToList();
			ViewBag.Sections = _context.StudentsSections.ToList();
			return View();
        }
        [HttpGet]
        public IActionResult AddMultipleStudent()
        {
            return View();
        }

		/* DERS PROGRAMI İŞLEMLERİ */
        public IActionResult Syllabus()
		{
			return View();
		}
		public IActionResult Objections()
		{
			return View();
		}

		/* DERS İŞLEMLERİ */
		[HttpGet]
		public IActionResult Lessons()
		{
			var dersListele = _context.Lessons.ToList();
			return View(dersListele);
		}
        [HttpGet]
        public IActionResult AddLesson()
        {
			ViewBag.Academicianes = _context.Academicianes.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult AddMultipleLesson()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Home", "Login");
		}
	}
}
