using IdentityMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var claims = User.Claims.Select(c => $"{c.Type}: {c.Value}").ToList();

            return View();
        }

        public IActionResult Privacy()
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
