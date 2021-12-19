using OlympusMons.ViewModels;
using Xunit;

namespace OlympusMonsTests
{
    public class ApiUnitTests
    {
        [Fact]
        public void WeatherQueryPropsVM_Test()
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

            var processor = new WeatherQueryPropsVMProcessor();

            //Act
            var result = processor.WeatherQuery(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(request.City, result.Result.main.);
            Assert.Equal(request.CountryCode, result.CountryCode);
            Assert.Equal(request.Latitude, result.Latitude);
            Assert.Equal(request.Longitude, result.Longitude);
            Assert.Equal(request.Callback, result.Callback);
            Assert.Equal(request.Language, result.Language);
            Assert.Equal(request.Units, result.Units);
            Assert.Equal(request.Mode, result.Mode);
        }
    }
}