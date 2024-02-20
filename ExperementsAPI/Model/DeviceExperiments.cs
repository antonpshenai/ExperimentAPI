using System.ComponentModel.DataAnnotations.Schema;

namespace ExperementsAPI.Model
{
    public class DeviceExperiments
    {
        public int Id { get; set; }

        public int? DeviceId { get; set; }

        public int? ExperimentId { get; set; }

        public int? ExperimentValueId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Devices? Device { get; set; }

        [ForeignKey("ExperimentId")]
        public virtual Experiments? Experiment { get; set; }

        [ForeignKey("ExperimentValueId")]
        public virtual ExperimentValues? ExperimentValue { get; set; }
    }
}
