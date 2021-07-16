using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public class AirlinesDbContext : DbContext
    {
        public AirlinesDbContext()
            : base("name=AirlinesDbContext")
        {
            Database.SetInitializer(new AirlineDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().Property(c => c.Name).IsRequired()
                                                               .HasMaxLength(100);
            // Zero or One to Many
            modelBuilder.Entity<Airplane>().HasOptional(a => a.Country)
                                           .WithMany(c => c.Airplanes)
                                           .HasForeignKey(a => a.CountryId);

            // Add Configuration Classes
            modelBuilder.Configurations.Add(new FlightConfig());
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Type> Types { get; set; }
    }
}

