using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViseVault.Models;

namespace ViseVault.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Home/Index
        public IActionResult Index()
        {
            return View(); // Return the Index view
        }

        // GET: Home/Privacy
        public IActionResult Privacy()
        {
            return View(); // Return the Privacy view
        }

        // GET: Home/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); // Return the Error view with ErrorViewModel
        }
    }
}
