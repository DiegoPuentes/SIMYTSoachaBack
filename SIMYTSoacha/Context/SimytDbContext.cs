using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Context
{
    public class SimytDbContext : DbContext
    {
        public SimytDbContext(DbContextOptions options) : base(options) { }
        public DbSet<People> People { get; set; }
        public DbSet<DocumentsTypes> Dtypes { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<UsersXPermissions> UsersXPermissions { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Histories> Histories { get; set; }
        public DbSet<UsersTypes> UsersTypes { get; set; }
        public DbSet<TypesContacts> TypesContacts { get; set; }
        public DbSet<TypesServices> TypesServices { get; set; }
        public DbSet<Fines> Fines { get; set; }
        public DbSet<Mimpositions> Mimpositions { get; set; }
        public DbSet<Restrictions> Restrictions { get; set; }
        public DbSet<DriverLicenses> DriverLicenses { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Ecenters> Ecenters { get; set; }
        public DbSet<Procedures> Procedures { get; set; }
        public DbSet<TypesVehicles> TypesVehicles { get; set; }
        public DbSet<TrafficLicenses> TrafficLicenses { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Infractions> Infractions { get; set; }
        public DbSet<Lines> Lines { get; set; }
        //public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Models> Models { get; set; }
        public DbSet<ModelXLine> ModelXLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersXPermissions>()
                .HasNoKey();

            modelBuilder.Entity<ModelXLine>().
                HasNoKey();
        }
    }
}
