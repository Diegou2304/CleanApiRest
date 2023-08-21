using CleanApiRest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanApiRest.Infrastructure.Persistence.Configuration
{
    public class CarStoreEntityTypeConfiguration : IEntityTypeConfiguration<CarStore>
    {
        public void Configure(EntityTypeBuilder<CarStore> builder)
        {
            builder
                .HasMany(c => c.Cars)
                .WithOne(c => c.CarStore);
               
        }
    }
}
