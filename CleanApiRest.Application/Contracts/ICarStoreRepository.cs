using CleanApiRest.Domain;

namespace CleanApiRest.Application.Contracts
{
    public interface ICarStoreRepository : IGenericRepository<CarStore>
    { 
        Task<CarStore> GetCarStoreById(int id);
    }
}
