using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Interactive_Syllabus.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Student()
        {
            return View();
        }
        public IActionResult Academician() 
        {
            return View();
        }

      

    }
}