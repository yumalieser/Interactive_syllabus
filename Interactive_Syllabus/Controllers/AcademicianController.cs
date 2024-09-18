using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interactive_Syllabus.Controllers
{
	public class AcademicianController : Controller
	{
		Context _context = new Context();
		public IActionResult Panel()
		{
			return View();
		}
		public IActionResult Profile()
		{
			return View();
		}
        [HttpGet]
        public IActionResult Students()
		{
			var ogrenciListele = _context.Students.ToList();
			return View(ogrenciListele);
		}
		public IActionResult Syllabus()
		{
			return View();
		}
		public IActionResult Objections()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Lessons()
		{
			var dersListele = _context.Lessons.ToList();
			return View(dersListele);
		}
	}
}
