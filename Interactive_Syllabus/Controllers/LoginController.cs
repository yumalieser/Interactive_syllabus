using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public IActionResult Student()
        {
            return View();
        }
		[HttpPost]
		public async Task<IActionResult> Student(string email, string password)
		{
			var student = await c.Students.FirstOrDefaultAsync(x => x.StudentEmail == email && x.StudentPassword == password);

			if (student != null)
			{
				await SignInUser(student.StudentID.ToString(), student.StudentEmail, "Student");
				return RedirectToAction("Panel","Student");
			}

			ModelState.AddModelError("", "Invalid credentials");
			return View();
		}
		[HttpGet]
		public IActionResult Academician() 
        {
            return View();
        }


		[HttpPost]
		public async Task<IActionResult> Academician(string email, string password)
		{
			var academician = await c.Academicianes.FirstOrDefaultAsync(x => x.AcademicianEMail == email && x.AcademicianPassword == password);

			if (academician != null)
			{
				await SignInUser(academician.AcademicianID.ToString(), academician.AcademicianEMail, "Academician");
				return RedirectToAction("Panel", "Academician");
			}

			ModelState.AddModelError("", "Invalid credentials");
			return View();
		}

		private async Task SignInUser(string userId, string email, string role)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, userId),
				new Claim(ClaimTypes.Email, email),
				new Claim("UserType", role) // "Student" veya "Academician"
			};

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var authProperties = new AuthenticationProperties
			{
				IsPersistent = true // Kalýcý oturum için
			};

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
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