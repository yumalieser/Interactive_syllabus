using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Interactive_Syllabus.Controllers
{
    public class LoginController : Controller
    {
		Context c = new Context();
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Student()
        {
            return View();
        }
		//[HttpPost]
		//public async Task<IActionResult> Student(Student p)
		//{
		//	var bilgiler = c.Students.FirstOrDefault(x => x.StudentName == p.StudentName &&
		//	x.StudentPassword == p.StudentPassword);
		//	if (bilgiler != null)
		//	{
		//		var claims = new List<Claim>
		//		{
		//			new Claim(ClaimTypes.Name, "Admin")
		//		};
		//		var useridentity = new ClaimsIdentity(claims, "Login");
		//		ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
		//		await HttpContext.SignInAsync(principal);
		//		return RedirectToAction("Academician", "Login");
		//	}
		//	//ModelState.AddModelError(string.Empty, "Kullanýcý adý veya þifre yanlýþ.");

		//	return View();
		//}
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