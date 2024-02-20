using ExperementsAPI.DTO;
using static ExperementsAPI.DTO.ResponceExperimentsStatisticDTO;

namespace ExperementsAPI.Interfaces
{
    public interface IExperimentService
    {
        Task<ResponseDTO> GetExperimentResponseAsync(string deviceToken, string experimentName);

        ExperimentStatisticsDto GetExperimentStatistics();
    }
}
