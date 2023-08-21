using CleanApiRest.Domain;
using Microsoft.EntityFrameworkCore;


namespace CleanApiRest.Infrastructure
{
    public class CleanApiRestDbContext : DbContext
    {

      
        public CleanApiRestDbContext(DbContextOptions<CleanApiRestDbContext> options) : base(options)
        {


        }



        public DbSet<Car> Cars { get; set; }
        public DbSet<CarStore> CarStores { get; set; }

    }
}