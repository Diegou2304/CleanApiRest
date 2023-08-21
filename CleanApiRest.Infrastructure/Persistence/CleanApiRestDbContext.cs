using CleanApiRest.Domain;
using CleanApiRest.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;


namespace CleanApiRest.Infrastructure.Persistence
{
    public class CleanApiRestDbContext : DbContext
    {


        public CleanApiRestDbContext(DbContextOptions<CleanApiRestDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            new CarStoreEntityTypeConfiguration().Configure(modelBuilder.Entity<CarStore>());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarStore> CarStores { get; set; }

    }
}