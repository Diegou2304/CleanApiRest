
using CleanApiRest.Application.Contracts;
using CleanApiRest.Domain;
using CleanApiRest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CleanApiRest.Infrastructure.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly CleanApiRestDbContext _context;
        public CarRepository(CleanApiRestDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetCarByColor(string color)
        {

            var result = await _context.Cars.AsNoTracking().Include(c => c.CarStoreId).Where(c => c.Color == color).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Car>> GetAll(string color)
        {

            var result = await _context.Cars.AsNoTracking().Include(c => c.CarStoreId).Where(c => c.Color == color).ToListAsync();
            return result;
        }
    }
}
