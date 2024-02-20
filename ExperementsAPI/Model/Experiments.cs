namespace ExperementsAPI.Model
{
    public class Experiments
    {
        public int Id { get; set; }
        public string? ExperimentName { get; set; }

        public virtual ICollection<DeviceExperiments>? DeviceExperiments { get; set; }

        public virtual ICollection<ExperimentValues>? ExperimentValues { get; set; }

    }
}
