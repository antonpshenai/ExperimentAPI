using ExperementsAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace ExperementsAPI.DataBase
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Devices> Devices { get; set; }
        public DbSet<DeviceExperiments> DeviceExperiments { get; set; }
        public DbSet<Experiments> Experiments { get; set; }
        public DbSet<ExperimentValues> ExperimentValues { get; set; }
    }
}

