﻿using Microsoft.AspNetCore.Mvc;

namespace Interactive_Syllabus.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
        public IActionResult Panel()
        {
            return View();
        }
    }
}