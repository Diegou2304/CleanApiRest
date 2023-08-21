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



           modelBuilder.Entity<CarStore>().HasData(
          new CarStore
          {
              CarStoreId = 1,
              Name = "Toyota Automotors",
              Address = "5th Street Boulebard Avenue",
              City = "Miami",
              OwnerName = "Michael Maguire",
              CountryName = "UnitedStates"
          });

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    CarId = 1,
                
                    Color = "Green",
                    Brand = "Toyota",
                    CarStoreId = 1
                });

            new CarStoreEntityTypeConfiguration()
               .Configure(modelBuilder.Entity<CarStore>());
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarStore> CarStores { get; set; }
    
    }
}