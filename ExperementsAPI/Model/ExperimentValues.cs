using System.ComponentModel.DataAnnotations.Schema;

namespace ExperementsAPI.Model
{
    public class ExperimentValues 
    {
        public  int Id { get; set; }
        
        public string? Value { get; set; }

        public double? ProcentValue { get; set;}

        public int ExperimentId { get; set; }


        [ForeignKey("ExperimentId")]
        public virtual Experiments? Experiments { get; set; }

        public virtual ICollection<DeviceExperiments>? DeviceExperiments { get; set; }
    }
}
