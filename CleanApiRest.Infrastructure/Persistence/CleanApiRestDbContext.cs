using CleanApiRest.Domain;
using CleanApiRest.Domain.Common;
using CleanApiRest.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;


namespace CleanApiRest.Infrastructure.Persistence
{
    public class CleanApiRestDbContext : DbContext
    {


        public CleanApiRestDbContext(DbContextOptions<CleanApiRestDbContext> options) : base(options)
        {


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }

            }

            return base.SaveChangesAsync(cancellationToken);


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