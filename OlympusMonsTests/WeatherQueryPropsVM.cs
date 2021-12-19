using OlympusMons.Interfaces;
using OlympusMons.Models;
using OlympusMons.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympusMonsTests
{
    public class WeatherQueryPropsVMProcessor
    {
        private readonly IWeatherApiModule _weatherApiModule;

        public WeatherQueryPropsVMProcessor(IWeatherApiModule weatherApiModule)
        {
            _weatherApiModule = weatherApiModule;
        }

        internal async Task<WeatherReport> WeatherQuery (WeatherQueryPropsVM request)
        {
            return await _weatherApiModule.GetWeatherForecastAsync(request);
        }
    }
}
