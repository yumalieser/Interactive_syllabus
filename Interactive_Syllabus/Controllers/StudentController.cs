using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interactive_Syllabus.Controllers
{
	[Authorize(Policy = "StudentOnly")]
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
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Home", "Login");
		}
	}
}
