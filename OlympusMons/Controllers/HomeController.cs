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
        #region Dependency Injection
        private readonly ILogger<HomeController> _logger;
        private readonly IDbModule _dbModule;
        private readonly IWeatherApiModule _weatherApiModule;
        public HomeController(ILogger<HomeController> logger, IDbModule dbModule, IWeatherApiModule weatherApiModule)
        {
            _logger = logger;
            _dbModule = dbModule;
            _weatherApiModule = weatherApiModule;
        }
        #endregion Dependency Injection

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

        [HttpGet]
        public async Task<IActionResult> GetWeatherReport()
        {
            return Ok( await _weatherApiModule.GetWeatherForecastAsync("Durban", "ZA"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}