using CleanApiRest.Domain;
using CleanApiRest.Infrastructure.Persistence;
using CleanApiRest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanApiRest.Application.Contracts
{
    public class CarStoreRepository : GenericRepository<CarStore>, ICarStoreRepository
    {
        private readonly CleanApiRestDbContext _context;
        public CarStoreRepository(CleanApiRestDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CarStore> GetCarStoreById(int id)
        {
            return await _context.CarStores!.Include(d => d.Cars).FirstOrDefaultAsync(c => c.CarStoreId == id);
        }

      
    }
}
