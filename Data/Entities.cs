using Jerbaco.Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jerbaco.Flights.Data
{
    public class Entities : DbContext
    {
        public Entities(DbContextOptions<Entities> options) : base(options)
        {

        }

        public DbSet<Passenger> Passengers => Set<Passenger>();

        public DbSet<Flight> Flights => Set<Flight>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().HasKey(p => p.Email);

            modelBuilder.Entity<Flight>()
                .Property(p => p.RemainingNumberOfSeats)
                .IsConcurrencyToken();

            modelBuilder.Entity<Flight>().OwnsOne(f => f.Departure);
            modelBuilder.Entity<Flight>().OwnsOne(f => f.Arrival);
        }
    }
}
