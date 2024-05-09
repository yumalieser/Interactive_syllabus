using Microsoft.AspNetCore.Mvc;

namespace Interactive_Syllabus.Controllers
{
	public class AcademicianController : Controller
	{
		[HttpPost]
		public IActionResult Panel()
		{
			return View();
		}
		public IActionResult Profile()
		{
			return View();
		}
	}
}
