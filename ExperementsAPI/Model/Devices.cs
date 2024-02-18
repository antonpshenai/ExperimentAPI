using System.ComponentModel.DataAnnotations.Schema;

namespace ExperementsAPI.Model
{
    public class Devices
    {
        public int Id { get; set; }
        public string? DeviceToken { get; set; }


        public  virtual ICollection<DeviceExperiments>? DeviceExperiments { get; set; }
    }
}
