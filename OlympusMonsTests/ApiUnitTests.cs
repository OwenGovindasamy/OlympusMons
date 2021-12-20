using OlympusMons.ViewModels;
using System.Threading.Tasks;
using Xunit;

namespace OlympusMonsTests
{
    public class ApiUnitTests
    {
        private readonly WeatherQueryPropsVMProcessor _processor;

        public ApiUnitTests(WeatherQueryPropsVMProcessor processor)
        {
            _processor = processor;
        }

        [Fact]
        public async Task WeatherQueryPropsVM_Test()
        {
            //Arrange
            var request = new WeatherQueryPropsVM
            {
                Id = 2172797,
                City = "Durban",
                CountryCode = "za",
                Latitude = "0",
                Longitude = "0",
                Callback = "test",
                Language = "null",
                Units = "metric",
                Mode = "xml"
            };

            //Act
            var result = await _processor.WeatherQuery(request);

            //Assert
            Assert.NotNull(result);
            //Assert.Equal(request.City, result?.name);
            //Assert.Equal(request.CountryCode, result?.sys?.country);
            //Assert.Equal(request.Latitude, result?.coord?.lat.ToString());
            //Assert.Equal(request.Longitude, result?.coord?.lon.ToString());
        }
    }
}