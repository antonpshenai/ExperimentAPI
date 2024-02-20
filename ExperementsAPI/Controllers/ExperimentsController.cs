using Microsoft.AspNetCore.Mvc;
using ExperementsAPI.Interfaces;

namespace ExperementsAPI.Controllers
{
    [ApiController]
    [Route("experiment")]
    public class ExperimentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExperimentsController> _logger;
        private readonly IExperimentService _experimentService;

        public ExperimentsController(ILogger<ExperimentsController> logger, IExperimentService experimentService, IConfiguration configuration)
        {
            _logger = logger;
            _experimentService = experimentService;
            _configuration = configuration;
        }

        [HttpGet("{endpointName}")]
        public async Task<IActionResult> GetExperiment([FromQuery(Name = "device-token")] string deviceToken, string endpointName)
        {
            try
            {
                //1. Find in appsettings.json if endpointName is there. If not - return NotFound
                _logger.LogInformation($"In method {nameof(GetExperiment)}");
                var experimentNameSection = _configuration.GetSection("ExperimentEndpoints")[endpointName];

                _logger.LogInformation($"Endpoint: {endpointName}. Checking for experiment name");
                if (experimentNameSection == null)
                    return NotFound($"Experiment endpoint with name '{endpointName}' not found.");

                var experimentName = experimentNameSection;

                //2. Pass device token and experiment name to service. It will create/update device and return ResponseDTO
                var response = await _experimentService.GetExperimentResponseAsync(deviceToken, experimentName);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("statistics")]
        public IActionResult GetExperimentStatistics() 
        {
            try
            {
                //1. This endpoint for view statistic from DB (due to the task 2.b)
                _logger.LogInformation($"In method {nameof(GetExperiment)}");
                var experimentStatistics = _experimentService.GetExperimentStatistics();

                return Ok(experimentStatistics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"internal server Error: {ex.Message}");
            }            
        }

    }
}