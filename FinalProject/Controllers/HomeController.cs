using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {

      

        public IActionResult Index(int islog)
        {
            if (User.Identity.IsAuthenticated)
            {
                string LogId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            return View();
            
        }
        public IActionResult Backe()
        {
            
            return View();

        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}