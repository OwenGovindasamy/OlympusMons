using Microsoft.AspNetCore.Mvc;
using OlympusMons.Logic;
using OlympusMons.Models;
using OlympusMons.Interfaces;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace OlympusMons.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbModule _dbModule;
        public HomeController(ILogger<HomeController> logger, IDbModule dbModule)
        {
            _logger = logger;
            _dbModule = dbModule;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        } 

        public IActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertTest(Test test)
        {
            return Ok(_dbModule.insertTest(test));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}