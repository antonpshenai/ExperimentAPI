using ExperementsAPI.DataBase;
using ExperementsAPI.DTO;
using ExperementsAPI.Model;
using ExperementsAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ExpetimentsAPITest.UnitTests.Services
{
    public class ExperimentServiceTest
    {
        private readonly DbContextOptions<AppDBContext> _dbContextOptions;

        public ExperimentServiceTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetExperimentResponseAsyncReturnsResponseDTO()
        {
            using (var context = new AppDBContext(_dbContextOptions))
            {
                var service = new ExperimentService(context);

                var result = await service.GetExperimentResponseAsync("newDeviceToken", "experimentName");

                Assert.IsType<ResponseDTO>(result);
                Assert.NotNull(result.Key);
                Assert.NotNull(result.Value);
            }
        }

        [Fact]
        public void GetExperimentStatisticsReturnsExperimentStatisticsDto()
        {
            using (var context = new AppDBContext(_dbContextOptions))
            {
                var service = new ExperimentService(context);
                SampleDatabase(context);

                var result = service.GetExperimentStatistics();

                Assert.IsType<ResponceExperimentsStatisticDTO.ExperimentStatisticsDto>(result);
                Assert.Equal(2, result.ExperimentCount);
                Assert.Equal(3, result.DevicesTotal);
                Assert.NotNull(result.ExperimentDetails);
                Assert.Equal(2, result.ExperimentDetails.Count());
            }
        }

        private void SampleDatabase(AppDBContext context)
        {
            var experiment1 = new Experiments { ExperimentName = "button_color" };
            var experiment2 = new Experiments { ExperimentName = "price" };

            var device1 = new Devices { DeviceToken = "test4412" };
            var device2 = new Devices { DeviceToken = "test4413" };
            var device3 = new Devices { DeviceToken = "test4414" };

            var experimentValue1 = new ExperimentValues { Value = "#FF0000", ProcentValue = 100 };
            var experimentValue2 = new ExperimentValues { Value = "10", ProcentValue = 100 };

            var deviceExperiment1 = new DeviceExperiments { Device = device1, Experiment = experiment1, ExperimentValue = experimentValue1 };
            var deviceExperiment2 = new DeviceExperiments { Device = device2, Experiment = experiment1, ExperimentValue = experimentValue2 };
            var deviceExperiment3 = new DeviceExperiments { Device = device3, Experiment = experiment2, ExperimentValue = experimentValue1 };

            context.AddRange(experiment1, experiment2);
            context.AddRange(device1, device2, device3);
            context.AddRange(experimentValue1, experimentValue2);
            context.AddRange(deviceExperiment1, deviceExperiment2, deviceExperiment3);
            context.SaveChanges();
        }
    }
}
