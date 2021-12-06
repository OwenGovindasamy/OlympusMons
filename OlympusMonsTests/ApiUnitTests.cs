using OlympusMons.ViewModels;
using Xunit;

namespace OlympusMonsTests
{
    public class ApiUnitTests
    {
        [Fact]
        public void Model_NotEqual_Test()
        {// test passed 
            WeatherQueryPropsVM expected = new() { Id = 2172797, City = "Durban", CountryCode = "za", Latitude = "0", Longitude = "0", Callback = "test", Language = "null", Units = "metric", Mode = "xml" };
            WeatherQueryPropsVM actual = new() { Id = 2172797, City = "", CountryCode = "", Latitude = "0", Longitude = "0", Callback = "test", Language = "null", Units = "metric", Mode = "xml" };
            Assert.NotEqual(expected, actual);

        }

        [Fact]
        public void Model_Equal_Test()
        { //test failed
            WeatherQueryPropsVM expected = new() { Id = 2172797, City = "Durban", CountryCode = "za", Latitude = "0", Longitude = "0", Callback = "test", Language = "null", Units = "metric", Mode = "xml" };
            WeatherQueryPropsVM actual = new() { Id = 2172797, City = "", CountryCode = "", Latitude = "0", Longitude = "0", Callback = "test", Language = "null", Units = "metric", Mode = "xml" };
            Assert.Equal(expected, actual);

            //Assert.Contains<WeatherQueryPropsVM>
            //    (
            //    () => new WeatherQueryPropsVM(2172797, "Durban", "za", "0", "0", "test", "null", "metric", "xml")
            //    );
        }
    }
}