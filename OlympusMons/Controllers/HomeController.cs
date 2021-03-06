using Microsoft.AspNetCore.Mvc;
using OlympusMons.Logic;
using OlympusMons.Models;
using OlympusMons.Interfaces;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using OlympusMons.ViewModels;

namespace OlympusMons.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        #region Dependency Injection
        private readonly ILogger<HomeController> _logger;
        private readonly IDbModule _dbModule;
        private readonly IWeatherApiModule _weatherApiModule;
        private readonly IHelpers _helpers;
        public HomeController(ILogger<HomeController> logger, IDbModule dbModule, IWeatherApiModule weatherApiModule, IHelpers helpers)
        {
            _logger = logger;
            _dbModule = dbModule;
            _weatherApiModule = weatherApiModule;
            _helpers = helpers;
        }
        #endregion Dependency Injection

        public async Task<IActionResult> Index(WeatherReport? model)
        {
            return View(await _weatherApiModule.GetWeatherForecastAsync(_helpers.PopulateWeatherPropsVM_SampleData()));
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
        public async Task<IActionResult> GetWeatherReport(WeatherQueryPropsVM Vm)
        {
            return Ok(await _weatherApiModule.GetWeatherForecastAsync(Vm));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}