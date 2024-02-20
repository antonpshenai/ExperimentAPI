using ExperementsAPI.DataBase;
using ExperementsAPI.DTO;
using ExperementsAPI.Interfaces;
using ExperementsAPI.Model;
using Microsoft.EntityFrameworkCore;
using static ExperementsAPI.DTO.ResponceExperimentsStatisticDTO;


namespace ExperementsAPI.Services
{
    public class ExperimentService: IExperimentService
    {
        private readonly AppDBContext _context;
        private const double PercentageMultiplier = 100.0;

        public ExperimentService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<ResponseDTO> GetExperimentResponseAsync(string deviceToken, string experimentName)
        {
            // 1. Searching for a device for a token, when toket new - create new device
            var deviceFromDb = await _context.Devices
                .Include(d => d.DeviceExperiments)
                .FirstOrDefaultAsync(d => d.DeviceToken == deviceToken);

            var device = deviceFromDb ?? new Devices { DeviceToken = deviceToken };

            // 2. Searching experiment including values and all device experiments
            var experiment = await _context.Experiments
                .Include(e => e.ExperimentValues)
                .Include(e => e.DeviceExperiments)
                .FirstOrDefaultAsync(e => e.ExperimentName == experimentName);
            string responseValue = "";

            if (experiment != null)
            {
                // 3. Get existing experiment for device. If device with such token didn't have experiment -> create new
                var deviceExperiment = experiment.DeviceExperiments?.FirstOrDefault(de => de.DeviceId == device.Id);

                if (deviceExperiment == null)
                {
                    var experimentValues = experiment.ExperimentValues.ToList();
                    var cumulativePercentage = 0.0;
                    var randomPercentage = new Random().NextDouble() * PercentageMultiplier; // Generate a random percent
                   
                    foreach (var experimentValue in experimentValues)
                    {
                        cumulativePercentage += (double)experimentValue.ProcentValue;

                        if (randomPercentage <= cumulativePercentage)
                        {
                            var newDeviceExperiment = new DeviceExperiments
                            {
                                Device = device,
                                Experiment = experiment,
                                ExperimentValue = experimentValue
                            };
                            
                            responseValue = experimentValue.Value;
                            _context.DeviceExperiments.Add(newDeviceExperiment);
                            await _context.SaveChangesAsync(); // Save to DB

                            return CreateResponseDTO(experimentName, responseValue);
                        }
                    }
                }
                else {
                    // 4. Return Experiment Value.
                    responseValue = deviceExperiment.ExperimentValue?.Value;
                }
            }

            return CreateResponseDTO(experimentName, responseValue);
        }

        public ExperimentStatisticsDto GetExperimentStatistics()
        {
            // 1. This method for count device with experiment values for statistic. 
            var experimentStatistics = new ExperimentStatisticsDto
            {
                ExperimentCount = _context.Experiments.Count(),
                DevicesTotal = _context.Devices.Count(),
                ExperimentDetails = _context.Experiments
                    .Include(e => e.DeviceExperiments)
                    .Include(e => e.ExperimentValues)
                    .GroupBy(e => e.ExperimentName)
                    .Select(group => new ExperimentDetailDto
                    {
                        ExperimentName = group.Key,
                        Values = group.SelectMany(e => e.ExperimentValues)
                            .GroupBy(ev => ev.Value)
                            .Select(valueGroup => new ExperimentValueDetailDto
                            {
                                Value = valueGroup.Key,
                                DeviceCount = valueGroup.SelectMany(ev => ev.DeviceExperiments).Count()
                            })
                    })
            };

            return experimentStatistics;
        }

        private ResponseDTO CreateResponseDTO(string key, string value)
        {
            return new ResponseDTO()
            {
                Key = key,
                Value = value
            };
        }
    }
}
