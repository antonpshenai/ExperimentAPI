using Microsoft.AspNetCore.Mvc;

namespace ExperementsAPI.Controllers
{
    [ApiController]
    [Route("experiment")]
    public class ExperimentsController : ControllerBase
    {
       

        private readonly ILogger<ExperimentsController> _logger;

        public ExperimentsController(ILogger<ExperimentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{endpointName}")]
        public IActionResult GetExperiment([FromQuery] string deviceToken)
        {
            var experimentName = "color_button";

            return OkObjectResult();
        }
    }
}