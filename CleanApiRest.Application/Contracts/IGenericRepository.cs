using CleanApiRest.Domain.Common;

namespace CleanApiRest.Application.Contracts
{
    public interface IGenericRepository<T>  where T : BaseDomainModel
    {
        Task GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetByCreatedByAsync(string creator);
      

    }
}
