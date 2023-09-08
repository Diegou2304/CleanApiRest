using CleanApiRest.Domain;


namespace CleanApiRest.Application.Contracts
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<IEnumerable<Car>> GetCarByColor(string color);
        Task<Car> GetCarById(int id);
    }
}
