using ManagementApp.Application.Specifications;
using ManagementApp.Domain.Models;

namespace ManagementApp.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(IBaseSpecification<T> specification);
        Task<T> GetByIdWithSpecificationAsync(IBaseSpecification<T> specification);
        Task<int> CountAsync(IBaseSpecification<T> specification);
        void AddAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}
