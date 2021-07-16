using System.Data.Entity.ModelConfiguration;

namespace DAL
{
    public class FlightConfig : EntityTypeConfiguration<Flight>
    {
        public FlightConfig()
        {
            HasKey(f => f.Number); // set primary key

            // One to Many
            HasRequired(f => f.DispatchCity)
                .WithMany(c => c.FlightsFrom)
                .HasForeignKey(f => f.DispatchCityId)
                .WillCascadeOnDelete(false);

            HasRequired(f => f.ArrivalCity)
                .WithMany(c => c.FlightsTo)
                .HasForeignKey(f => f.ArrivalCityId)
                .WillCascadeOnDelete(false);

            // Many to Many
            HasMany(f => f.Clients).WithMany(c => c.Flights);
        }
    }
}

