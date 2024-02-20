using ExperementsAPI.Controllers;
using ExperementsAPI.DTO;
using ExperementsAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace ExpetimentsAPITest.UnitTests.Controllers
{
    public class ExperimentsControllerTest
    {
        private ExperimentsController _controller;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<ILogger<ExperimentsController>> _mockLogger;
        private Mock<IExperimentService> _mockExperimentService;

        public ExperimentsControllerTest()
        {
            _mockLogger = new Mock<ILogger<ExperimentsController>>();
            _mockConfiguration = new Mock<IConfiguration>();
            _mockExperimentService = new Mock<IExperimentService>();

            _controller = new ExperimentsController(_mockLogger.Object, _mockExperimentService.Object, _mockConfiguration.Object);
        }

        [Fact]
        public async Task GetExperimentWithValidEndpoint()
        {
            _mockConfiguration.Setup(config => config.GetSection("ExperimentEndpoints")["button-color"]).Returns("button_color");
            _mockExperimentService.Setup(service => service.GetExperimentResponseAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new ResponseDTO());

            var result = await _controller.GetExperiment("deviceToken", "button-color");

            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsType<ResponseDTO>(okResult?.Value);
        }

        [Fact]
        public async Task GetExperimentWithNotValidEndpoint()
        {
            _mockConfiguration.Setup(config => config.GetSection("ExperimentEndpoints")["cats"]).Returns((string)null);

            var result = await _controller.GetExperiment("deviceToken", "cats");

            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.Equal($"Experiment endpoint with name 'cats' not found.", notFoundResult?.Value);
        }

    }
}
