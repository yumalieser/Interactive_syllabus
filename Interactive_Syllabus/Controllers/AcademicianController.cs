using Microsoft.AspNetCore.Mvc;

namespace Interactive_Syllabus.Controllers
{
	public class AcademicianController : Controller
	{
		public IActionResult Panel()
		{
			return View();
		}
	}
}
