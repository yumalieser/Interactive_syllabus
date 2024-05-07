using Microsoft.AspNetCore.Mvc;

namespace Interactive_Syllabus.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult AdminLogin()
		{
			return View();
		}
	}
}
