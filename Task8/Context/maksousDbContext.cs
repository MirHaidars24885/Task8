using Microsoft.EntityFrameworkCore;
using Task8.Models;

namespace Task8.Context
{
    public class maksousDbContext : DbContext
    {
        public maksousDbContext(DbContextOptions<maksousDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<ClientTrip> ClientTrips { get; set; }
        public DbSet<CountryTrip> CountryTrips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Define your model configurations here
        }
    }
}