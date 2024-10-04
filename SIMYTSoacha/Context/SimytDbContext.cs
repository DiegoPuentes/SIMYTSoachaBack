using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Context
{
    public class SimytDbContext : DbContext
    {
        internal IEnumerable<object> People;

        public SimytDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<People> peoples { get; set; }
        public DbSet<Requests> requests { get; set; }
        public DbSet<Managers> managers { get; set; }
        public DbSet<Fines> fines { get; set; }
        public DbSet<Mimpositions> mimpositions { get; set; }
        public DbSet<Restrictions> restrictions { get; set; }
        public DbSet<DriverLicenses> driverLicenses { get; set; }
        public DbSet<States> states { get; set; }
        public DbSet<TypesServices> typesServices { get; set; }
        public DbSet<Procedures> procedures { get; set; }
        public DbSet<TrafficLicenses> trafficLicenses { get;set; }
        public DbSet<UsersTypes> usersTypes { get; set; }
        public DbSet<Histories> histories { get; set; }
        public DbSet<Matches> matches { get; set; }
    }
}
