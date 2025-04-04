using System.Diagnostics;
using Examination.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination.Controllers
{
    public class HomeController : Controller
    {
        //[Route("/")]

        public IActionResult Index()
        {
            return View();
        }

        //[Route("Privacy")]

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
