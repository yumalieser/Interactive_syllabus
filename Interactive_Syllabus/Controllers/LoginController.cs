using Interactive_Syllabus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Interactive_Syllabus.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

      

    }
}