namespace ExperementsAPI.DTO
{
    public class ResponceExperimentsStatisticDTO

    {
        public class ExperimentStatisticsDto
        {
            public int ExperimentCount { get; set; }
            public int DevicesTotal { get; set; }
            public IEnumerable<ExperimentDetailDto> ExperimentDetails { get; set; }
        }

        public class ExperimentDetailDto
        {
            public string ExperimentName { get; set; }
            public IEnumerable<ExperimentValueDetailDto> Values { get; set; }
        }

        public class ExperimentValueDetailDto
        {
            public string Value { get; set; }
            public int DeviceCount { get; set; }
        }
    }
}
