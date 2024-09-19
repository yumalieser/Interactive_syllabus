using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interactive_Syllabus.Controllers
{
	public class StudentController : Controller
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
