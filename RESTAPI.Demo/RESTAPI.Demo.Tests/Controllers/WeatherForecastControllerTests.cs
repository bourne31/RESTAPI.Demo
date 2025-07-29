using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using RESTAPI.Demo.Controllers;
using Xunit;

namespace RESTAPI.Demo.Tests.Controllers
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public void Get_ReturnsFiveWeatherForecasts()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.NotNull(result);
            var forecasts = result.ToArray();
            Assert.Equal(5, forecasts.Length);

            foreach (var forecast in forecasts)
            {
                Assert.InRange(forecast.TemperatureC, -20, 55);
                Assert.False(string.IsNullOrEmpty(forecast.Summary));
                Assert.True(forecast.Date > DateOnly.FromDateTime(DateTime.Now));
            }
        }
    }
}

